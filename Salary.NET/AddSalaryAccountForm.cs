﻿using System;
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
			this.InitControls();
			this.RefreshNetAndGrossWage();
		}

		public AddSalaryAccountForm(Employee employee)
		{
			this._employee = employee;

			InitializeComponent();
			this.InitControls();
			this.RefreshNetAndGrossWage();
		}

		public AddSalaryAccountForm(SalaryAccount salaryAccount)
		{
			this._employee = salaryAccount.Employee;
			this._salaryAccount = salaryAccount;

			InitializeComponent();
			this.InitControls();
			this.RefreshNetAndGrossWage();
		}

		private void InitControls()
		{
			var startYear = 1900;
			for(var year = startYear; year <= DateTime.Now.Year; year++) {
				this.comboBoxPeriodYear.Items.Add(year);
			}
			this.comboBoxPeriodYear.SelectedIndex = this.comboBoxPeriodYear.Items.Count - 1;
			this.comboBoxPeriodMonth.SelectedIndex = DateTime.Now.Month - 1;

			if (this._salaryAccount == null) {
				return;
			}

			this.userControlSalaryItems1.SetSalaryItems(this._salaryAccount.Salaries);

			var grossWage = this._salaryAccount.GrossWage;
			var wageTaxPercentage = Math.Round(this._salaryAccount.WageTax * 100.0 / grossWage, 2);
			var solidarityTaxPercentage = Math.Round(this._salaryAccount.SolidarityTax * 100.0 / grossWage, 2);
			var SicknessInsurancePercentage = Math.Round(this._salaryAccount.SicknessInsurance * 100.0 / grossWage, 2);
			var annuityInsurancePercentage = Math.Round(this._salaryAccount.AnnuityInsurance * 100.0 / grossWage, 2);
			var unemploymentInsurancePercentage = Math.Round(this._salaryAccount.UnemploymentInsurance * 100.0 / grossWage, 2);
			var compulsoryLongTermCareInsurancePercentage = Math.Round(this._salaryAccount.CompulsoryLongTermCareInsurance * 100.0 / grossWage, 2);

			this.numericUpDownWageTax.Value = (decimal)this._salaryAccount.WageTax;
			this.textBoxWageTaxPercentage.Text = String.Format("{0:0.00} %", wageTaxPercentage);
			this.numericUpDownSolidarityTax.Value = (decimal)this._salaryAccount.SolidarityTax;
			this.textBoxSolidarityTaxPercentage.Text = String.Format("{0:0.00} %", solidarityTaxPercentage);
			this.numericUpDownSicknessInsurance.Value = (decimal)this._salaryAccount.SicknessInsurance;
			this.textBoxSicknessInsurancePercentage.Text = String.Format("{0:0.00} %", SicknessInsurancePercentage);
			this.numericUpDownAnnuityInsurance.Value = (decimal)this._salaryAccount.AnnuityInsurance;
			this.textBoxAnnuityInsurancePercentage.Text = String.Format("{0:0.00} %", annuityInsurancePercentage);
			this.numericUpDownUnemploymentInsurance.Value = (decimal)this._salaryAccount.UnemploymentInsurance;
			this.textBoxUnemploymentInsurancePercentage.Text = String.Format("{0:0.00} %", unemploymentInsurancePercentage);
			this.numericUpDownCompulsoryLongTermCareInsurance.Value = (decimal)this._salaryAccount.CompulsoryLongTermCareInsurance;
			this.textBoxCompulsoryLongTermCareInsurancePercentage.Text = String.Format("{0:0.00} %", compulsoryLongTermCareInsurancePercentage);

			this.comboBoxPeriodYear.SelectedIndex = this._salaryAccount.PeriodStart.Year - startYear;
			this.comboBoxPeriodMonth.SelectedIndex = this._salaryAccount.PeriodStart.Month - 1;
			if (this._salaryAccount.PeriodStart.Day != 1 ||
				this._salaryAccount.PeriodEnd.Day != DateTime.DaysInMonth(this._salaryAccount.PeriodStart.Year, this._salaryAccount.PeriodStart.Month)) {
				this.comboBoxPeriodFromDay.SelectedIndex = this._salaryAccount.PeriodStart.Day - 1;
				this.comboBoxPeriodToDay.SelectedIndex = this._salaryAccount.PeriodEnd.Day - 1;
				this.checkBoxPeriodFromTo.Enabled = true;
				this.checkBoxPeriodFromTo.Checked = true;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			try {
				this._salaryAccount = new SalaryAccount(this._employee) {
					AnnuityInsurance = (double)this.numericUpDownAnnuityInsurance.Value,
					CompulsoryLongTermCareInsurance = (double)this.numericUpDownCompulsoryLongTermCareInsurance.Value,
					SicknessInsurance = (double)this.numericUpDownSicknessInsurance.Value,
					SolidarityTax = (double)this.numericUpDownSolidarityTax.Value,
					UnemploymentInsurance = (double)this.numericUpDownUnemploymentInsurance.Value,
					WageTax = (double)this.numericUpDownWageTax.Value
				};
				foreach(var t in this.userControlSalaryItems1.Salaries) {
					this._salaryAccount.Salaries.Add(t.Key, t.Value);
				}
				var periodYear = Convert.ToInt32(this.comboBoxPeriodYear.SelectedItem);
				var periodMonth = this.comboBoxPeriodMonth.SelectedIndex + 1;
				if(!this.checkBoxPeriodFromTo.Checked) {
					this._salaryAccount.SetPeriod(periodYear, periodMonth);
				} else {
					var periodFromDay = this.comboBoxPeriodFromDay.SelectedIndex + 1;
					var periodToDay = this.comboBoxPeriodToDay.SelectedIndex + 1;
					this._salaryAccount.SetPeriod(periodYear, periodMonth, periodFromDay, periodYear, periodMonth, periodToDay);
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			} catch(Exception exc) {
				MessageBox.Show("An Exception was thrown: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			try {
				this._salaryAccount.AnnuityInsurance = (double)this.numericUpDownAnnuityInsurance.Value;
				this._salaryAccount.CompulsoryLongTermCareInsurance = (double)this.numericUpDownCompulsoryLongTermCareInsurance.Value;
				this._salaryAccount.SicknessInsurance = (double)this.numericUpDownSicknessInsurance.Value;
				this._salaryAccount.SolidarityTax = (double)this.numericUpDownSolidarityTax.Value;
				this._salaryAccount.UnemploymentInsurance = (double)this.numericUpDownUnemploymentInsurance.Value;
				this._salaryAccount.WageTax = (double)this.numericUpDownWageTax.Value;

				this._salaryAccount.Salaries.Clear();
				foreach(var t in this.userControlSalaryItems1.Salaries) {
					this._salaryAccount.Salaries.Add(t.Key, t.Value);
				}
				var periodYear = Convert.ToInt32(this.comboBoxPeriodYear.SelectedItem);
				var periodMonth = this.comboBoxPeriodMonth.SelectedIndex + 1;
				if (!this.checkBoxPeriodFromTo.Checked) {
					this._salaryAccount.SetPeriod(periodYear, periodMonth);
				} else {
					var periodFromDay = this.comboBoxPeriodFromDay.SelectedIndex + 1;
					var periodToDay = this.comboBoxPeriodToDay.SelectedIndex + 1;
					this._salaryAccount.SetPeriod(periodYear, periodMonth, periodFromDay, periodYear, periodMonth, periodToDay);
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			} catch(Exception exc) {
				MessageBox.Show("An Exception was thrown: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void userControlSalaryItems1_SalaryItemChanged(object sender, SalaryItemChangedEventArgs e)
		{
			this.RefreshNetAndGrossWage();
		}

		private void numericUpDownWageTax_ValueChanged(object sender, EventArgs e)
		{
			this.RefreshNetAndGrossWage();
		}

		private void RefreshNetAndGrossWage()
		{
			var salaryAccount = new SalaryAccount(this._employee) {
				AnnuityInsurance = (double)this.numericUpDownAnnuityInsurance.Value,
				CompulsoryLongTermCareInsurance = (double)this.numericUpDownCompulsoryLongTermCareInsurance.Value,
				SicknessInsurance = (double)this.numericUpDownSicknessInsurance.Value,
				SolidarityTax = (double)this.numericUpDownSolidarityTax.Value,
				UnemploymentInsurance = (double)this.numericUpDownUnemploymentInsurance.Value,
				WageTax = (double)this.numericUpDownWageTax.Value
			};
			foreach(var t in this.userControlSalaryItems1.Salaries) {
				salaryAccount.Salaries.Add(t.Key, t.Value);
			}

			var grossWage = salaryAccount.GrossWage;
			var wageTaxPercentage = Math.Round(salaryAccount.WageTax * 100.0 / grossWage, 2);
			var solidarityTaxPercentage = Math.Round(salaryAccount.SolidarityTax * 100.0 / grossWage, 2);
			var SicknessInsurancePercentage = Math.Round(salaryAccount.SicknessInsurance * 100.0 / grossWage, 2);
			var annuityInsurancePercentage = Math.Round(salaryAccount.AnnuityInsurance * 100.0 / grossWage, 2);
			var unemploymentInsurancePercentage = Math.Round(salaryAccount.UnemploymentInsurance * 100.0 / grossWage, 2);
			var compulsoryLongTermCareInsurancePercentage = Math.Round(salaryAccount.CompulsoryLongTermCareInsurance * 100.0 / grossWage, 2);

			this.textBoxWageTaxPercentage.Text = String.Format("{0:0.00} %", wageTaxPercentage);
			this.textBoxSolidarityTaxPercentage.Text = String.Format("{0:0.00} %", solidarityTaxPercentage);
			this.textBoxSicknessInsurancePercentage.Text = String.Format("{0:0.00} %", SicknessInsurancePercentage);
			this.textBoxAnnuityInsurancePercentage.Text = String.Format("{0:0.00} %", annuityInsurancePercentage);
			this.textBoxUnemploymentInsurancePercentage.Text = String.Format("{0:0.00} %", unemploymentInsurancePercentage);
			this.textBoxCompulsoryLongTermCareInsurancePercentage.Text = String.Format("{0:0.00} %", compulsoryLongTermCareInsurancePercentage);

			this.textBoxTotalGross.Text = String.Format("{0:N2} €", salaryAccount.GrossWage);
			this.textBoxTotalNet.Text = String.Format("{0:N2} €", salaryAccount.NetWage);

			var totalNetPercentage = Math.Round(salaryAccount.NetWage * 100.0 / salaryAccount.GrossWage, 2);
			this.textBoxTotalNetPercentage.Text = String.Format("{0:0.00} %", totalNetPercentage);
		}

		private void checkBoxPeriodFromTo_CheckedChanged(object sender, EventArgs e)
		{
			var enabled = this.checkBoxPeriodFromTo.Checked;
			this.comboBoxPeriodFromDay.Enabled = enabled;
			this.comboBoxPeriodToDay.Enabled = enabled;

			if (!enabled) {
				return;
			}

			this.RefreshComboBoxPeriodFromTo();
		}

		private void comboBoxPeriodYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(this.checkBoxPeriodFromTo.Checked) {
				this.RefreshComboBoxPeriodFromTo();
			}
		}

		private void comboBoxPeriodMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(this.checkBoxPeriodFromTo.Checked) {
				this.RefreshComboBoxPeriodFromTo();
			}
		}

		private void RefreshComboBoxPeriodFromTo()
		{
			if(this.comboBoxPeriodFromDay.SelectedItem == null) {
				this.comboBoxPeriodFromDay.SelectedIndex = 0;
			}
			if(this.comboBoxPeriodToDay.SelectedItem == null) {
				this.comboBoxPeriodToDay.SelectedIndex = this.comboBoxPeriodToDay.Items.Count - 1;
			}
			var periodYear = Convert.ToInt32(this.comboBoxPeriodYear.SelectedItem);
			var periodMonth = this.comboBoxPeriodMonth.SelectedIndex + 1;
			var daysInMonth = DateTime.DaysInMonth(periodYear, periodMonth);
			if(daysInMonth < this.comboBoxPeriodToDay.SelectedIndex + 1) {
				this.comboBoxPeriodToDay.SelectedIndex = daysInMonth - 1;
			}
			if(daysInMonth < this.comboBoxPeriodToDay.Items.Count) {
				do {
					this.comboBoxPeriodToDay.Items.RemoveAt(this.comboBoxPeriodToDay.Items.Count - 1);
				} while(daysInMonth < this.comboBoxPeriodToDay.Items.Count);
			} else if(daysInMonth > this.comboBoxPeriodToDay.Items.Count) {
				do {
					this.comboBoxPeriodToDay.Items.Add(this.comboBoxPeriodToDay.Items.Count + 1);
				} while(daysInMonth > this.comboBoxPeriodToDay.Items.Count);
			}
			if(daysInMonth < this.comboBoxPeriodFromDay.Items.Count) {
				do {
					this.comboBoxPeriodFromDay.Items.RemoveAt(this.comboBoxPeriodFromDay.Items.Count - 1);
				} while(daysInMonth < this.comboBoxPeriodFromDay.Items.Count);
			} else if(daysInMonth > this.comboBoxPeriodFromDay.Items.Count) {
				do {
					this.comboBoxPeriodFromDay.Items.Add(this.comboBoxPeriodFromDay.Items.Count + 1);
				} while(daysInMonth > this.comboBoxPeriodFromDay.Items.Count);
			}
		}
	}
}
