using System;

namespace SalaryLibrary
{
	public class SalaryItem
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
	}
}
