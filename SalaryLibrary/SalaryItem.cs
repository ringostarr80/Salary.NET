using System;

namespace SalaryLibrary
{
	public class SalaryItem : ICloneable
	{
		private double _amount = 0.0;

		/// <summary>
		/// Betrag
		/// </summary>
		public double Amount { get { return this._amount; } set { this._amount = value; } }

		public SalaryItem(double amount)
		{
			this.Amount = amount;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public override bool Equals(object obj)
		{
			if(obj == null) {
				return false;
			}

			var s = obj as SalaryItem;
			if((object)s == null) {
				return false;
			}

			return this == s;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static bool operator ==(SalaryItem a, SalaryItem b)
		{
			if(Object.ReferenceEquals(a, b)) {
				return true;
			}

			if(((object)a == null) || ((object)b == null)) {
				return false;
			}

			if (a.Amount != b.Amount) {
				return false;
			}

			return true;
		}

		public static bool operator !=(SalaryItem a, SalaryItem b)
		{
			return !(a == b);
		}
	}
}
