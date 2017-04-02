using System;
using System.Xml;

namespace SalaryLibrary
{
	public class SalaryType : ICloneable
	{
		private object _id = null;
		private uint _number = 0;
		private string _name = string.Empty;
		private bool _discountOnNetWage = false;

		public object Id { get { return this._id; }
			set {
				this._id = value ?? throw new ArgumentException("SalaryType.Id cannot be null!");
			}
		}

		public uint Number { get { return this._number; } set { this._number = value; } }

		public string Name { get { return this._name; } set { this._name = value.Trim(); } }

		public bool DiscountOnNetWage { get { return this._discountOnNetWage; } set { this._discountOnNetWage = value; } }

		public SalaryType(object id, uint number, string name, bool discountOnNetWage = false)
		{
			this.Id = id;
			this.Number = number;
			this.Name = name;
			this.DiscountOnNetWage = discountOnNetWage;
		}

		public SalaryType(XmlNode node)
		{
			var idAttr = node.Attributes.GetNamedItem("id");
			var numberAttr = node.Attributes.GetNamedItem("number");
			var nameAttr = node.Attributes.GetNamedItem("name");
			var discountOnNetWageAttr = node.Attributes.GetNamedItem("discount-on-net-wage");
			if (idAttr == null) {
				throw new FormatException("Expected attribute 'id'.");
			}
			if (numberAttr == null) {
				throw new FormatException("Expected attribute 'number'.");
			}
			if (nameAttr == null) {
				throw new FormatException("Expected attribute 'name'.");
			}
			this.Id = Convert.ToUInt32(idAttr.Value);
			this.Number = Convert.ToUInt32(numberAttr.Value);
			this.Name = nameAttr.Value.Trim();
			if(discountOnNetWageAttr != null) {
				switch(discountOnNetWageAttr.Value.Trim()) {
					case "1":
					case "true":
					case "yes":
						this.DiscountOnNetWage = true;
						break;

					case "0":
					case "false":
					case "no":
					case "":
						this.DiscountOnNetWage = false;
						break;
				}
			}
		}

		public override string ToString()
		{
			return string.Format("{0} ({1})", this.Number, this.Name);
		}

		public object Clone()
		{
			var clone = (SalaryType)this.MemberwiseClone();
			
			return clone;
		}

		public override bool Equals(object obj)
		{
			if (obj == null) {
				return false;
			}

			var s = obj as SalaryType;
			if ((object)s == null) {
				return false;
			}

			return this == s;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static bool operator ==(SalaryType a, SalaryType b)
		{
			if (object.ReferenceEquals(a, b)) {
				return true;
			}

			if (((object)a == null) || ((object)b == null)) {
				return false;
			}

			var aType = a.Id.GetType().ToString();
			var bType = b.Id.GetType().ToString();
			if (aType != bType) {
				switch(aType) {
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.UInt16":
					case "System.UInt32":
					case "System.UInt64":
						a.Id = Convert.ToUInt64(a.Id);
						aType = "UInt64";
						break;
				}
				switch (bType) {
					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.UInt16":
					case "System.UInt32":
					case "System.UInt64":
						b.Id = Convert.ToUInt64(b.Id);
						bType = "UInt64";
						break;
				}
			}
			if (aType != bType) {
				return false;
			}

			switch (aType) {
				case "UInt64":
					if ((ulong)a.Id != (ulong)b.Id) {
						return false;
					}
					break;

				default:
					//Console.WriteLine("unhandled Id-type: " + a.Id.GetType().ToString());
					break;
			}
			if (a.Number != b.Number) {
				return false;
			}
			if (a.Name != b.Name) {
				return false;
			}
			if (a.DiscountOnNetWage != b.DiscountOnNetWage) {
				return false;
			}

			return true;
		}

		public static bool operator !=(SalaryType a, SalaryType b)
		{
			return !(a == b);
		}
	}
}
