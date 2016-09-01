using System;
using System.Windows.Forms;

using SalaryLibrary;

namespace Salary.NET
{
	public partial class AddSalaryAccountForm : Form
	{
		private Employee _employee = null;
		private SalaryAccount _salaryAccount = null;

		public SalaryAccount SalaryAccount { get { return this._salaryAccount; } }

		public AddSalaryAccountForm()
		{
			InitializeComponent();
		}

		public AddSalaryAccountForm(Employee employee)
		{
			this._employee = employee;

			InitializeComponent();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			this._salaryAccount = new SalaryAccount(this._employee) {
				AnnuityInsurance = (double)this.numericUpDownAnnuityInsurance.Value,
				CompulsoryLongTermCareInsurance = (double)this.numericUpDownCompulsoryLongTermCareInsurance.Value,
				SicknessInsurance = (double)this.numericUpDownSicknessInsurance.Value,
				SolidarityTax = (double)this.numericUpDownSolidarityTax.Value,
				UnemploymentInsurance = (double)this.numericUpDownUnemploymentInsurance.Value,
				WageTax = (double)this.numericUpDownWageTax.Value
			};

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
