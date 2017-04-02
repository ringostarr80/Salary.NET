using System;
using System.Windows.Forms;

using SalaryLibrary;
using System.Collections.Generic;

namespace Salary.NET
{
	public partial class AddSalaryTypeForm : Form
	{
		private SalaryType _salaryType = null;
		private SalaryTypeCollection _salaryTypes = null;

		public SalaryType SalaryType { get { return this._salaryType; } }
		public SalaryTypeCollection SalaryTypes { get { return this._salaryTypes; } }

		public AddSalaryTypeForm()
		{
			InitializeComponent();

			this.buttonAdd.Visible = true;
			this.buttonEdit.Visible = false;
		}

		public AddSalaryTypeForm(SalaryTypeCollection salaryTypes)
		{
			this._salaryTypes = salaryTypes;

			InitializeComponent();

			this.Text = "Lohnart bearbeiten";
			this.labelSalaryTypes.Visible = true;
			this.comboBoxSalaryTypes.Visible = true;
			this.buttonAdd.Visible = false;
			this.buttonEdit.Visible = true;

			foreach(var salaryType in salaryTypes) {
				this.comboBoxSalaryTypes.Items.Add(salaryType);
			}
			if (this.comboBoxSalaryTypes.Items.Count > 0) {
				this.comboBoxSalaryTypes.SelectedIndex = 0;
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void ButtonEdit_Click(object sender, EventArgs e)
		{
			if (this._salaryTypes.HasConflictingElements) {
				MessageBox.Show("Es gibt Lohnarten, die miteinander in Konflikt stehen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			this._salaryType = new SalaryType(0, Convert.ToUInt32(this.numericUpDownNumber.Value), this.textBoxName.Text, this.checkBoxDiscountOnNetWage.Checked);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ComboBoxSalaryTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			var salaryType = (SalaryType)this.comboBoxSalaryTypes.SelectedItem;
			this.numericUpDownNumber.Value = salaryType.Number;
			this.textBoxName.Text = salaryType.Name;
			this.checkBoxDiscountOnNetWage.Checked = salaryType.DiscountOnNetWage;
		}

		private void NumericUpDownNumber_ValueChanged(object sender, EventArgs e)
		{
			if (this.comboBoxSalaryTypes.Items.Count == 0) {
				return;
			}

			var selectedSalaryType = (SalaryType)this.comboBoxSalaryTypes.SelectedItem;
			selectedSalaryType.Number = (uint)this.numericUpDownNumber.Value;
			this.comboBoxSalaryTypes.Items[this.comboBoxSalaryTypes.SelectedIndex] = selectedSalaryType;
		}

		private void TextBoxName_TextChanged(object sender, EventArgs e)
		{
			if (this.comboBoxSalaryTypes.Items.Count == 0) {
				return;
			}

			var selectedSalaryType = (SalaryType)this.comboBoxSalaryTypes.SelectedItem;
			selectedSalaryType.Name = this.textBoxName.Text;
			this.comboBoxSalaryTypes.Items[this.comboBoxSalaryTypes.SelectedIndex] = selectedSalaryType;
		}

		private void CheckBoxDiscountOnNetWage_CheckedChanged(object sender, EventArgs e)
		{
			if (this.comboBoxSalaryTypes.Items.Count == 0) {
				return;
			}

			var selectedSalaryType = (SalaryType)this.comboBoxSalaryTypes.SelectedItem;
			selectedSalaryType.DiscountOnNetWage = this.checkBoxDiscountOnNetWage.Checked;
			this.comboBoxSalaryTypes.Items[this.comboBoxSalaryTypes.SelectedIndex] = selectedSalaryType;
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if (this.comboBoxSalaryTypes.Items.Count == 0) {
				return;
			}
			var selectedIndex = this.comboBoxSalaryTypes.SelectedIndex;
			this.comboBoxSalaryTypes.Items.RemoveAt(selectedIndex);
			this._salaryTypes.RemoveAt(selectedIndex);
			if (this.comboBoxSalaryTypes.Items.Count == 0) {
				return;
			}
			if (this.comboBoxSalaryTypes.Items.Count - 1 >= selectedIndex) {
				this.comboBoxSalaryTypes.SelectedIndex = selectedIndex;
			} else {
				this.comboBoxSalaryTypes.SelectedIndex = this.comboBoxSalaryTypes.Items.Count - 1;
			}
		}
	}
}
