using System;
using SalaryLibrary;

namespace Salary.NET
{
	class SalaryTypeItem
	{
		private SalaryType _type = null;

		public SalaryType Type { get { return this._type; } }

		public SalaryTypeItem(SalaryType type)
		{
			this._type = type;
		}

		public override string ToString()
		{
			return string.Format("({0}) {1}", this._type.Number, this._type.Name);
		}
	}
}
