using System;

namespace SalaryLibrary
{
	public class Employer
	{
		protected object _id = null;
		protected string _name = string.Empty;

		public object Id
		{
			get { return this._id; }
			set {
				this._id = value ?? throw new ArgumentException("Employer.Id cannot be null!");
			}
		}

		public string Name { get { return this._name; } set { this._name = value.Trim(); } }

		public Employer(string name)
		{
			this.Name = name;
		}

		public Employer(object id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}
