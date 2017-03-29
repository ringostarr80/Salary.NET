namespace Salary.NET
{
	partial class AddEmployeeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeForm));
			this.labelFirstName = new System.Windows.Forms.Label();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.labelMiddleName = new System.Windows.Forms.Label();
			this.textBoxMiddleName = new System.Windows.Forms.TextBox();
			this.labelLastName = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.labelPersonnelNumber = new System.Windows.Forms.Label();
			this.textBoxPersonnelNumber = new System.Windows.Forms.TextBox();
			this.labelBirthday = new System.Windows.Forms.Label();
			this.dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelId = new System.Windows.Forms.Label();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.labelGender = new System.Windows.Forms.Label();
			this.comboBoxGender = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// labelFirstName
			// 
			resources.ApplyResources(this.labelFirstName, "labelFirstName");
			this.labelFirstName.Name = "labelFirstName";
			// 
			// textBoxFirstName
			// 
			resources.ApplyResources(this.textBoxFirstName, "textBoxFirstName");
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxFirstName_KeyUp);
			// 
			// labelMiddleName
			// 
			resources.ApplyResources(this.labelMiddleName, "labelMiddleName");
			this.labelMiddleName.Name = "labelMiddleName";
			// 
			// textBoxMiddleName
			// 
			resources.ApplyResources(this.textBoxMiddleName, "textBoxMiddleName");
			this.textBoxMiddleName.Name = "textBoxMiddleName";
			// 
			// labelLastName
			// 
			resources.ApplyResources(this.labelLastName, "labelLastName");
			this.labelLastName.Name = "labelLastName";
			// 
			// textBoxLastName
			// 
			resources.ApplyResources(this.textBoxLastName, "textBoxLastName");
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxLastName_KeyUp);
			// 
			// labelPersonnelNumber
			// 
			resources.ApplyResources(this.labelPersonnelNumber, "labelPersonnelNumber");
			this.labelPersonnelNumber.Name = "labelPersonnelNumber";
			// 
			// textBoxPersonnelNumber
			// 
			resources.ApplyResources(this.textBoxPersonnelNumber, "textBoxPersonnelNumber");
			this.textBoxPersonnelNumber.Name = "textBoxPersonnelNumber";
			// 
			// labelBirthday
			// 
			resources.ApplyResources(this.labelBirthday, "labelBirthday");
			this.labelBirthday.Name = "labelBirthday";
			// 
			// dateTimePickerBirthday
			// 
			resources.ApplyResources(this.dateTimePickerBirthday, "dateTimePickerBirthday");
			this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
			// 
			// buttonAdd
			// 
			resources.ApplyResources(this.buttonAdd, "buttonAdd");
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// buttonCancel
			// 
			resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// labelId
			// 
			resources.ApplyResources(this.labelId, "labelId");
			this.labelId.Name = "labelId";
			// 
			// textBoxId
			// 
			resources.ApplyResources(this.textBoxId, "textBoxId");
			this.textBoxId.Name = "textBoxId";
			// 
			// buttonEdit
			// 
			resources.ApplyResources(this.buttonEdit, "buttonEdit");
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
			// 
			// labelGender
			// 
			resources.ApplyResources(this.labelGender, "labelGender");
			this.labelGender.Name = "labelGender";
			// 
			// comboBoxGender
			// 
			this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGender.FormattingEnabled = true;
			this.comboBoxGender.Items.AddRange(new object[] {
            resources.GetString("comboBoxGender.Items"),
            resources.GetString("comboBoxGender.Items1"),
            resources.GetString("comboBoxGender.Items2")});
			resources.ApplyResources(this.comboBoxGender, "comboBoxGender");
			this.comboBoxGender.Name = "comboBoxGender";
			// 
			// AddEmployeeForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBoxGender);
			this.Controls.Add(this.labelGender);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.textBoxId);
			this.Controls.Add(this.labelId);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.dateTimePickerBirthday);
			this.Controls.Add(this.labelBirthday);
			this.Controls.Add(this.textBoxPersonnelNumber);
			this.Controls.Add(this.labelPersonnelNumber);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelLastName);
			this.Controls.Add(this.textBoxMiddleName);
			this.Controls.Add(this.labelMiddleName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.labelFirstName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "AddEmployeeForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.Label labelMiddleName;
		private System.Windows.Forms.TextBox textBoxMiddleName;
		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Label labelPersonnelNumber;
		private System.Windows.Forms.TextBox textBoxPersonnelNumber;
		private System.Windows.Forms.Label labelBirthday;
		private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Label labelGender;
		private System.Windows.Forms.ComboBox comboBoxGender;
	}
}