namespace Salary.NET
{
	partial class UserControlGrossIncome
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.comboBoxSalaryType = new System.Windows.Forms.ComboBox();
			this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxSalaryType
			// 
			this.comboBoxSalaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSalaryType.FormattingEnabled = true;
			this.comboBoxSalaryType.Location = new System.Drawing.Point(0, 0);
			this.comboBoxSalaryType.Name = "comboBoxSalaryType";
			this.comboBoxSalaryType.Size = new System.Drawing.Size(120, 21);
			this.comboBoxSalaryType.TabIndex = 0;
			this.comboBoxSalaryType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSalaryType_SelectedIndexChanged);
			// 
			// numericUpDownAmount
			// 
			this.numericUpDownAmount.DecimalPlaces = 2;
			this.numericUpDownAmount.Location = new System.Drawing.Point(126, 1);
			this.numericUpDownAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownAmount.Name = "numericUpDownAmount";
			this.numericUpDownAmount.Size = new System.Drawing.Size(200, 20);
			this.numericUpDownAmount.TabIndex = 1;
			this.numericUpDownAmount.ValueChanged += new System.EventHandler(this.NumericUpDownAmount_ValueChanged);
			this.numericUpDownAmount.Enter += new System.EventHandler(this.NumericUpDownAmount_Enter);
			// 
			// UserControlGrossIncome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.numericUpDownAmount);
			this.Controls.Add(this.comboBoxSalaryType);
			this.Name = "UserControlGrossIncome";
			this.Size = new System.Drawing.Size(326, 21);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxSalaryType;
		private System.Windows.Forms.NumericUpDown numericUpDownAmount;
	}
}
