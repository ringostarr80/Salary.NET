using System;
using System.Drawing;
using System.Windows.Forms;
using SalaryLibrary;

namespace Salary.NET
{
	public partial class AddEmployeeForm : Form
	{
		private Employee _employee = null;

		public Employee Employee { get { return this._employee; } }

		public AddEmployeeForm()
		{
			InitializeComponent();
			
			this.buttonAdd.Visible = true;
			this.buttonEdit.Visible = false;
			this.comboBoxGender.SelectedIndex = 0;
		}

		public AddEmployeeForm(Employee employee)
		{
			InitializeComponent();

			this._employee = employee;

			this.textBoxId.Text = employee.Id.ToString();
			this.textBoxFirstName.Text = employee.FirstName;
			this.textBoxMiddleName.Text = employee.MiddleName;
			this.textBoxLastName.Text = employee.LastName;
			this.textBoxPersonnelNumber.Text = employee.PersonnelNumber;
			this.dateTimePickerBirthday.Value = employee.Birthday;

			this.buttonAdd.Visible = false;
			this.buttonEdit.Visible = true;

			this.SetGender(employee.Gender);
		}

		private Gender GetGender()
		{
			var gender = Gender.NotSpecified;

			switch(this.comboBoxGender.SelectedIndex) {
				case 0:
					gender = Gender.NotSpecified;
					break;

				case 1:
					gender = Gender.Male;
					break;

				case 2:
					gender = Gender.Female;
					break;
			}

			return gender;
		}

		private void SetGender(Gender gender)
		{
			var genderIndex = 0;
			switch(gender) {
				case Gender.Male:
					genderIndex = 1;
					break;

				case Gender.Female:
					genderIndex = 2;
					break;
			}
			this.comboBoxGender.SelectedIndex = genderIndex;
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var errors = false;
			if (this.textBoxFirstName.Text.Trim() == String.Empty) {
				errors = true;
				this.textBoxFirstName.BackColor = Color.Orange;
			}
			if(this.textBoxLastName.Text.Trim() == String.Empty) {
				errors = true;
				this.textBoxLastName.BackColor = Color.Orange;
			}
			if (errors) {
				return;
			}

			this._employee = new Employee(this.textBoxFirstName.Text, this.textBoxLastName.Text) {
				MiddleName = this.textBoxMiddleName.Text,
				PersonnelNumber = this.textBoxPersonnelNumber.Text,
				Gender = this.GetGender(),
				Birthday = this.dateTimePickerBirthday.Value
			};

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ButtonEdit_Click(object sender, EventArgs e)
		{
			var errors = false;
			if(this.textBoxFirstName.Text.Trim() == String.Empty) {
				errors = true;
				this.textBoxFirstName.BackColor = Color.Orange;
			}
			if(this.textBoxLastName.Text.Trim() == String.Empty) {
				errors = true;
				this.textBoxLastName.BackColor = Color.Orange;
			}
			if(errors) {
				return;
			}

			this._employee.FirstName = this.textBoxFirstName.Text;
			this._employee.LastName = this.textBoxLastName.Text;
			this._employee.MiddleName = this.textBoxMiddleName.Text;
			this._employee.PersonnelNumber = this.textBoxPersonnelNumber.Text;
			this._employee.Gender = this.GetGender();
			this._employee.Birthday = this.dateTimePickerBirthday.Value;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void TextBoxFirstName_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.textBoxFirstName.Text.Trim() != String.Empty) {
				this.textBoxFirstName.BackColor = SystemColors.Window;
			}
		}

		private void TextBoxLastName_KeyUp(object sender, KeyEventArgs e)
		{
			if(this.textBoxLastName.Text.Trim() != String.Empty) {
				this.textBoxLastName.BackColor = SystemColors.Window;
			}
		}
	}
}
