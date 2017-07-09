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
			this.numericUpDownNumber.Location = new System.Drawing.Point(218, 39);
			this.numericUpDownNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownNumber.Name = "numericUpDownNumber";
			this.numericUpDownNumber.Size = new System.Drawing.Size(274, 20);
			this.numericUpDownNumber.TabIndex = 0;
			this.numericUpDownNumber.ValueChanged += new System.EventHandler(this.NumericUpDownNumber_ValueChanged);
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new System.Drawing.Point(12, 41);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(49, 13);
			this.labelNumber.TabIndex = 1;
			this.labelNumber.Text = "Nummer:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 68);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(72, 13);
			this.labelName.TabIndex = 2;
			this.labelName.Text = "Bezeichnung:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(218, 65);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(274, 20);
			this.textBoxName.TabIndex = 3;
			this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
			// 
			// labelDiscountOnNetWage
			// 
			this.labelDiscountOnNetWage.AutoSize = true;
			this.labelDiscountOnNetWage.Location = new System.Drawing.Point(12, 95);
			this.labelDiscountOnNetWage.Name = "labelDiscountOnNetWage";
			this.labelDiscountOnNetWage.Size = new System.Drawing.Size(169, 13);
			this.labelDiscountOnNetWage.TabIndex = 4;
			this.labelDiscountOnNetWage.Text = "vom Nettobetrag wieder abziehen:";
			// 
			// checkBoxDiscountOnNetWage
			// 
			this.checkBoxDiscountOnNetWage.AutoSize = true;
			this.checkBoxDiscountOnNetWage.Location = new System.Drawing.Point(357, 94);
			this.checkBoxDiscountOnNetWage.Name = "checkBoxDiscountOnNetWage";
			this.checkBoxDiscountOnNetWage.Size = new System.Drawing.Size(15, 14);
			this.checkBoxDiscountOnNetWage.TabIndex = 5;
			this.checkBoxDiscountOnNetWage.UseVisualStyleBackColor = true;
			this.checkBoxDiscountOnNetWage.CheckedChanged += new System.EventHandler(this.CheckBoxDiscountOnNetWage_CheckedChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(106, 126);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(85, 23);
			this.buttonAdd.TabIndex = 6;
			this.buttonAdd.Text = "Hinzufügen";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(297, 126);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Abbrechen";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point(106, 126);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(85, 23);
			this.buttonEdit.TabIndex = 8;
			this.buttonEdit.Text = "Übernehmen";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
			// 
			// comboBoxSalaryTypes
			// 
			this.comboBoxSalaryTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSalaryTypes.FormattingEnabled = true;
			this.comboBoxSalaryTypes.Location = new System.Drawing.Point(218, 11);
			this.comboBoxSalaryTypes.Name = "comboBoxSalaryTypes";
			this.comboBoxSalaryTypes.Size = new System.Drawing.Size(193, 21);
			this.comboBoxSalaryTypes.TabIndex = 9;
			this.comboBoxSalaryTypes.Visible = false;
			this.comboBoxSalaryTypes.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSalaryTypes_SelectedIndexChanged);
			// 
			// labelSalaryTypes
			// 
			this.labelSalaryTypes.AutoSize = true;
			this.labelSalaryTypes.Location = new System.Drawing.Point(12, 15);
			this.labelSalaryTypes.Name = "labelSalaryTypes";
			this.labelSalaryTypes.Size = new System.Drawing.Size(58, 13);
			this.labelSalaryTypes.TabIndex = 10;
			this.labelSalaryTypes.Text = "Lohnarten:";
			this.labelSalaryTypes.Visible = false;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(417, 10);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonDelete.TabIndex = 11;
			this.buttonDelete.Text = "Löschen";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// AddSalaryTypeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 157);
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
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lohnart hinzufügen";
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