namespace PackageExplorer.AddIns.ValidationInspector
{
    using System;
    using System.Xml.Schema;
    using System.Xml;
    using System.IO;
    using System.Collections.Generic;
    using PackageExplorer.Core;
    using PackageExplorer.ObjectModel;
    using PackageExplorer.Core.Services;
    using System.Text;
    using PackageExplorer.Services;
    using System.Threading;
    using WinApp = System.Windows.Forms.Application;

    public partial class DefaultValidationService
        : ServiceBase, IValidationService
    {
        delegate void ValidationMessageCallback(ValidationEventArgs e);

        ValidationSettings _validationSettings = null;
        Queue<ValidationJob> _validationObjects = null;
        Thread _validationThread = null;
        bool _running = false;
        IMethodInvocationService _methodInvocationService = null;
        List<string> _validationPackages;

        internal static string ValidationPackageFolder
        {
            get { return Path.Combine(WinApp.StartupPath, "AddIns\\ValidationPackages"); }
        }


        public IEnumerable<string> ValidationPackages
        {
            get { return _validationPackages; }
        }

        IMethodInvocationService InvocationService
        {
            get
            {
                if (_methodInvocationService == null)
                {
                    _methodInvocationService = ServiceManager.GetService<IMethodInvocationService>();
                }
                return _methodInvocationService;
            }
        }

        public DefaultValidationService()
        {
            _validationObjects = new Queue<ValidationJob>();
            _validationPackages = new List<string>();
        }

        public void Validate(Document document)
        {
            lock (_validationObjects)
            {
                ValidationPackage package = CreateValidationPackage();
                string[] customSchemas = null;
                if (_validationSettings.CustomSchemaPaths != null)
                {
                    customSchemas = new string[_validationSettings.CustomSchemaPaths.Count];
                    _validationSettings.CustomSchemaPaths.CopyTo(customSchemas, 0);
                }
                else
                {
                    customSchemas = new string[0];
                }
                _validationObjects.Enqueue(
                    new DocumentValidationJob()
                    {
                        Document = document,
                        Package = package,
                        sendMessage = SendValidationMessage,
                        CustomSchemaPaths = customSchemas,
                        ShowInformationMessages = _validationSettings.ShowInformationMessages
                    });
            }            
            _validationThread.Interrupt();
        }

        public void Validate(DocumentPart documentPart)
        {
            lock (_validationObjects)
            {
                ValidationPackage package = CreateValidationPackage();
                string[] customSchemas = null;
                if (_validationSettings.CustomSchemaPaths != null)
                {
                    customSchemas = new string[_validationSettings.CustomSchemaPaths.Count];
                    _validationSettings.CustomSchemaPaths.CopyTo(customSchemas, 0);
                }
                else
                {
                    customSchemas = new string[0];
                }
                _validationObjects.Enqueue(
                    new DocumentPartValidationJob()
                    {
                        Package = package,
                        DocumentPart = documentPart,
                        CustomSchemaPaths = customSchemas,
                        sendMessage = SendValidationMessage,
                        ShowInformationMessages= _validationSettings.ShowInformationMessages
                    });
            } 
            _validationThread.Interrupt();
        }

        public override void InitializeService()
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            ISelectionService selectionService = ServiceManager.GetService<ISelectionService>();
            _validationSettings = settingsService.GetSettings<ValidationSettings>();
            // get to app dir
            string validationPackageFolder = ValidationPackageFolder;
            if (Directory.Exists(validationPackageFolder))
            {
                foreach (string validationPackage in Directory.GetFiles(
                    ValidationPackageFolder, "*.zip"))
                {
                    _validationPackages.Add(Path.GetFileNameWithoutExtension(validationPackage));
                }
            }
            string selectedPackage = _validationSettings.ActiveValidationPackage;
            if ((selectedPackage == null || _validationPackages.Contains(selectedPackage) == false) &&
                _validationPackages.Count > 0)
            {
                selectedPackage = _validationPackages[0];
                _validationSettings.ActiveValidationPackage = selectedPackage;
            }
            selectionService.SetSelectionForGroup("ValidationPackage", selectedPackage);
            _validationThread = new Thread(ValidationThreadMethod);
            _validationThread.IsBackground = true;
            _validationThread.Start();
            
            base.InitializeService();
        }

        public override void ShutdownService()
        {
            _running = false;
            if (_validationThread.Join(new TimeSpan(0, 1, 0)))
            {
                _validationThread.Abort();
            }
            _validationThread = null;
            base.ShutdownService();
        }

        void SendValidationMessage(string message)
        {            
            SafeOnValidationMessage(new ValidationEventArgs(message));
        }

        ValidationPackage CreateValidationPackage()
        {
            string activePackage = _validationSettings.ActiveValidationPackage;
            string path = String.Format("AddIns\\ValidationPackages\\{0}.zip", activePackage);
            path = Path.Combine(WinApp.StartupPath, path);
            return new ValidationPackage()
            {
                FileName = path,
                Name = activePackage
            };
        }

        void ValidationThreadMethod()
        {
            _running = true;
            while (_running)
            {
                ValidationJob validationObject = null;
                lock (_validationObjects)
                {
                    if (_validationObjects.Count > 0)
                    {
                        validationObject = _validationObjects.Dequeue();
                    }
                }
                if (validationObject != null)
                {
                    using (validationObject.Package)
                    {
                        validationObject.Execute();
                    }
                }
                else
                {
                    try
                    {
                        Thread.Sleep(2000);
                    }
                    catch (ThreadInterruptedException)
                    {
                    }
                }
            }
        }

        void SafeOnValidationMessage(ValidationEventArgs e)
        {
            InvocationService.Invoke(
                new ValidationMessageCallback(OnValidationMessage), e);
        }

        void OnValidationMessage(ValidationEventArgs e)
        {
            EventHandler<ValidationEventArgs> handler = ValidationMessage;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ValidationEventArgs> ValidationMessage;
    }
}
