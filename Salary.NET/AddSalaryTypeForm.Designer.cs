namespace Salary.NET
{
	partial class AddSalaryTypeForm
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
			if (disposing && (components != null))
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSalaryTypeForm));
			this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
			this.labelNumber = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelDiscountOnNetWage = new System.Windows.Forms.Label();
			this.checkBoxDiscountOnNetWage = new System.Windows.Forms.CheckBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.comboBoxSalaryTypes = new System.Windows.Forms.ComboBox();
			this.labelSalaryTypes = new System.Windows.Forms.Label();
			this.buttonDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownNumber
			// 
			resources.ApplyResources(this.numericUpDownNumber, "numericUpDownNumber");
			this.numericUpDownNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownNumber.Name = "numericUpDownNumber";
			this.numericUpDownNumber.ValueChanged += new System.EventHandler(this.NumericUpDownNumber_ValueChanged);
			// 
			// labelNumber
			// 
			resources.ApplyResources(this.labelNumber, "labelNumber");
			this.labelNumber.Name = "labelNumber";
			// 
			// labelName
			// 
			resources.ApplyResources(this.labelName, "labelName");
			this.labelName.Name = "labelName";
			// 
			// textBoxName
			// 
			resources.ApplyResources(this.textBoxName, "textBoxName");
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
			// 
			// labelDiscountOnNetWage
			// 
			resources.ApplyResources(this.labelDiscountOnNetWage, "labelDiscountOnNetWage");
			this.labelDiscountOnNetWage.Name = "labelDiscountOnNetWage";
			// 
			// checkBoxDiscountOnNetWage
			// 
			resources.ApplyResources(this.checkBoxDiscountOnNetWage, "checkBoxDiscountOnNetWage");
			this.checkBoxDiscountOnNetWage.Name = "checkBoxDiscountOnNetWage";
			this.checkBoxDiscountOnNetWage.UseVisualStyleBackColor = true;
			this.checkBoxDiscountOnNetWage.CheckedChanged += new System.EventHandler(this.CheckBoxDiscountOnNetWage_CheckedChanged);
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
			// buttonEdit
			// 
			resources.ApplyResources(this.buttonEdit, "buttonEdit");
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
			// 
			// comboBoxSalaryTypes
			// 
			resources.ApplyResources(this.comboBoxSalaryTypes, "comboBoxSalaryTypes");
			this.comboBoxSalaryTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSalaryTypes.FormattingEnabled = true;
			this.comboBoxSalaryTypes.Name = "comboBoxSalaryTypes";
			this.comboBoxSalaryTypes.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSalaryTypes_SelectedIndexChanged);
			// 
			// labelSalaryTypes
			// 
			resources.ApplyResources(this.labelSalaryTypes, "labelSalaryTypes");
			this.labelSalaryTypes.Name = "labelSalaryTypes";
			// 
			// buttonDelete
			// 
			resources.ApplyResources(this.buttonDelete, "buttonDelete");
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// AddSalaryTypeForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.labelSalaryTypes);
			this.Controls.Add(this.comboBoxSalaryTypes);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.checkBoxDiscountOnNetWage);
			this.Controls.Add(this.labelDiscountOnNetWage);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelNumber);
			this.Controls.Add(this.numericUpDownNumber);
			this.Name = "AddSalaryTypeForm";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownNumber;
		private System.Windows.Forms.Label labelNumber;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelDiscountOnNetWage;
		private System.Windows.Forms.CheckBox checkBoxDiscountOnNetWage;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.ComboBox comboBoxSalaryTypes;
		private System.Windows.Forms.Label labelSalaryTypes;
		private System.Windows.Forms.Button buttonDelete;
	}
}