using System;
using SalaryLibrary;

namespace Salary.NET
{
	class SalaryTypeItem
	{
		private SalaryType _type = SalaryType.AbzugVWL;

		public SalaryType Type { get { return this._type; } }

		public SalaryTypeItem(SalaryType type)
		{
			this._type = type;
		}

		public override string ToString()
		{
			var text = "(" + (int)this._type + ") ";

			switch(this._type) {
				case SalaryType.AbzugVWL:
					text += "Abzug VWL";
					break;

				case SalaryType.BezugVWLlfd:
					text += "Bezug VWL lfd";
					break;

				case SalaryType.BruttoWeihnachtsgeld:
					text += "Brutto Weihnachtsgeld";
					break;

				case SalaryType.Gehalt:
					text += "Gehalt";
					break;

				case SalaryType.NettoWeihnachtsgeld:
					text += "Netto Weihnachtsgeld";
					break;
			}

			return text;
		}
	}
}
