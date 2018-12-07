using System;
using System.IO.Packaging;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace PackageExplorer.ObjectModel
{
    public class DocumentSignatureManager
    {
        PackageDigitalSignatureManager _signatureManager = null;
        Document _document = null;

        public bool IsSigned
        {
            get { return _signatureManager.IsSigned; }
        }

        public IEnumerable<PackageDigitalSignature> Signatures
        {
            get
            {
                List<PackageDigitalSignature> signatures = new List<PackageDigitalSignature>();
                foreach (PackageDigitalSignature signature in _signatureManager.Signatures)
                {
                    signatures.Add(signature);
                }
                return signatures;
            }
        }

        public DocumentSignatureManager(Document document)
        {
            _document = document;
            _signatureManager = new PackageDigitalSignatureManager(document.Package);
            _signatureManager.CertificateOption = CertificateEmbeddingOption.InSignaturePart;
        }

        public VerifyResult VerifySignatures()
        {
            return _signatureManager.VerifySignatures(false);
        }

        public void Sign(X509Certificate2 certificate)
        {
            List<Uri> partsToSign = new List<Uri>();
            List<PackageRelationshipSelector> relationshipsToSign =
                new List<PackageRelationshipSelector>();
            List<Uri> finishedItems = new List<Uri>();
            foreach (PackageRelationship relationship in
                _document.Package.GetRelationships())
            {
                AddSignableItems(relationship,
                    partsToSign, relationshipsToSign);
            }
            _signatureManager.Sign(partsToSign, certificate, relationshipsToSign);
            _document.MarkDirty();
        }

        void AddSignableItems(
            PackageRelationship relationship,
            List<Uri> partsToSign,
            List<PackageRelationshipSelector> relationshipsToSign)
        {
            PackageRelationshipSelector selector =
                new PackageRelationshipSelector(
                    relationship.SourceUri,
                    PackageRelationshipSelectorType.Id,
                    relationship.Id);
            relationshipsToSign.Add(selector);
            if (relationship.TargetMode == TargetMode.Internal)
            {
                PackagePart part = relationship.Package.GetPart(
                    PackUriHelper.ResolvePartUri(
                        relationship.SourceUri, relationship.TargetUri));
                if (partsToSign.Contains(part.Uri) == false)
                {
                    partsToSign.Add(part.Uri);
                    foreach (PackageRelationship childRelationship in
                        part.GetRelationships())
                    {
                        AddSignableItems(childRelationship,
                            partsToSign, relationshipsToSign);
                    }
                }
            }
        }
    }
}
