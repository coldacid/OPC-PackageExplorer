namespace PackageExplorer.Core.AddInModel
{
	using System;
	using System.Collections.Generic;
	using PackageExplorer.Core.AddInModel.Codons;
	using PackageExplorer.Core.AddInModel.Conditions;

	public class Extension
	{
        string _path;
		List<ICodon> _codons = new List<ICodon>();
		
        public string Path
		{
			get{ return _path;}
		}

		public IEnumerable<ICodon> Codons
		{
			get{ return _codons; }
		}

        public Extension(string path)
		{
			_path = path;
		}

		public void AddCodon(ICodon codon)
		{
			_codons.Add(codon);
		}
	}
}