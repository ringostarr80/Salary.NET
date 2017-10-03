using System;
using System.Resources;
using System.Windows.Forms;
using BrightIdeasSoftware;
using SalaryLibrary;

namespace Salary.NET
{
	public partial class UserControlSalaryFilter : UserControl
	{
		private ResourceManager _resourceManager = new ResourceManager("Salary.NET.UserControlSalaryFilter", typeof(SalaryForm).Assembly);

		public event EventHandler FilterChanged;

		public UserControlSalaryFilter()
		{
			InitializeComponent();
		}

		protected void OnFilterChanged(object sender, SalaryFilterEventArgs e)
		{
			this.FilterChanged?.Invoke(this, e);
		}

		private void CheckBoxFilter_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBoxFilter.Checked) {
				this.Height += 110;
				var modelFilter = new ModelFilter(this.FilterDelegate);
				var eventArgs = new SalaryFilterEventArgs(modelFilter);

				this.OnFilterChanged(sender, eventArgs);
			} else {
				this.Height -= 110;
				var modelFilter = new ModelFilter(delegate(object x) {
					return true;
				});
				var eventArgs = new SalaryFilterEventArgs(modelFilter);

				this.OnFilterChanged(sender, eventArgs);
			}
		}

		private bool FilterDelegate(object x)
		{
			var salaryAccount = (SalaryAccount)x;
			if (this.checkBoxId.Checked)
			{
				ulong id = 0;
				switch(salaryAccount.Id.GetType().ToString())
				{
					case "System.UInt16":
					case "System.UInt32":
					case "System.UInt64":
						id = Convert.ToUInt64(salaryAccount.Id.ToString());
						break;

					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
						id = (ulong)salaryAccount.Id;
						break;

					default:
						return false;
				}
				if (id < this.numericUpDownMinId.Value || id > this.numericUpDownMaxId.Value)
				{
					return false;
				}
			}
			if (this.checkBoxGrossWage.Checked)
			{
				if (salaryAccount.GrossWage < (double)this.numericUpDownMinGrossWage.Value ||
					salaryAccount.GrossWage > (double)this.numericUpDownMaxGrossWage.Value)
				{
					return false;
				}
			}
			if (this.checkBoxNetWage.Checked)
			{
				if (salaryAccount.NetWage < (double)this.numericUpDownMinNetWage.Value ||
					salaryAccount.NetWage > (double)this.numericUpDownMaxNetWage.Value)
				{
					return false;
				}
			}
			if (this.checkBoxPeriod.Checked)
			{
				if (salaryAccount.PeriodEnd < this.dateTimePickerMinPeriod.Value ||
					salaryAccount.PeriodStart > this.dateTimePickerMaxPeriod.Value)
				{
					return false;
				}
			}

			return true;
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			var modelFilter = new ModelFilter(this.FilterDelegate);
			var eventArgs = new SalaryFilterEventArgs(modelFilter);

			this.OnFilterChanged(sender, eventArgs);
		}

		private void NumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			var modelFilter = new ModelFilter(this.FilterDelegate);
			var eventArgs = new SalaryFilterEventArgs(modelFilter);

			this.OnFilterChanged(sender, eventArgs);
		}

		private void DateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			var modelFilter = new ModelFilter(this.FilterDelegate);
			var eventArgs = new SalaryFilterEventArgs(modelFilter);

			this.OnFilterChanged(sender, eventArgs);
		}

		public void ChangeLocalization(string locale)
		{
			switch (locale)
			{
				case "de":
				case "de-DE":
				case "":
					break;

				case "en":
				case "en-US":
					break;

				case "ja":
					break;

				//default:
					//Console.WriteLine("invalid or unknown language-code: " + locale);
					//break;
			}

			this.checkBoxFilter.Text = this._resourceManager.GetString("checkBoxFilter.Text");
			this.checkBoxId.Text = this._resourceManager.GetString("checkBoxId.Text"); ;
			this.checkBoxGrossWage.Text = this._resourceManager.GetString("checkBoxGrossWage.Text"); ;
			this.checkBoxNetWage.Text = this._resourceManager.GetString("checkBoxNetWage.Text"); ;
			this.checkBoxPeriod.Text = this._resourceManager.GetString("checkBoxPeriod.Text"); ;
		}
	}
}
