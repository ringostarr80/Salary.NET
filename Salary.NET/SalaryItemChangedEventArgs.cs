using System;
using SalaryLibrary;

namespace Salary.NET
{
	public class SalaryItemChangedEventArgs : EventArgs
	{
		private SalaryType _salaryType;
		private double _amount;

		public SalaryType SalaryType { get { return this._salaryType; } }
		public double Amount { get { return this._amount; } }

		public SalaryItemChangedEventArgs(SalaryType salaryType, double amount)
		{
			this._salaryType = salaryType;
			this._amount = amount;
		}
	}
}