using System.Windows.Forms;
using SalaryLibrary;

namespace Salary.NET
{
	partial class UserControlSalaryItems
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
			this.groupBox = new GroupBox();
			this.panelBackground = new Panel();
			this.panel = new Panel();
			this.buttonAdd1 = new Button();
			this.buttonRemove1 = new Button();
			this.vScrollBar = new VScrollBar();
			this.userControlGrossIncome1 = new UserControlGrossIncome();
			this.groupBox.SuspendLayout();
			this.panelBackground.SuspendLayout();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.panelBackground);
			this.groupBox.Controls.Add(this.vScrollBar);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(480, 200);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Brutto-Bezüge";
			// 
			// panelBackground
			// 
			this.panelBackground.Controls.Add(this.panel);
			this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBackground.Location = new System.Drawing.Point(3, 16);
			this.panelBackground.Name = "panelBackground";
			this.panelBackground.Size = new System.Drawing.Size(457, 181);
			this.panelBackground.TabIndex = 5;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.userControlGrossIncome1);
			this.panel.Controls.Add(this.buttonAdd1);
			this.panel.Controls.Add(this.buttonRemove1);
			this.panel.Location = new System.Drawing.Point(3, 3);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(451, 175);
			this.panel.TabIndex = 4;
			// 
			// buttonAdd1
			// 
			this.buttonAdd1.Location = new System.Drawing.Point(400, 3);
			this.buttonAdd1.Name = "buttonAdd1";
			this.buttonAdd1.Size = new System.Drawing.Size(21, 21);
			this.buttonAdd1.TabIndex = 1;
			this.buttonAdd1.Text = "+";
			this.buttonAdd1.UseVisualStyleBackColor = true;
			this.buttonAdd1.Click += new System.EventHandler(this.ButtonAdd1_Click);
			// 
			// buttonRemove1
			// 
			this.buttonRemove1.Location = new System.Drawing.Point(427, 3);
			this.buttonRemove1.Name = "buttonRemove1";
			this.buttonRemove1.Size = new System.Drawing.Size(21, 21);
			this.buttonRemove1.TabIndex = 2;
			this.buttonRemove1.Text = "-";
			this.buttonRemove1.UseVisualStyleBackColor = true;
			this.buttonRemove1.Visible = false;
			this.buttonRemove1.Click += new System.EventHandler(this.ButtonRemove1_Click);
			// 
			// vScrollBar
			// 
			this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar.Enabled = false;
			this.vScrollBar.Location = new System.Drawing.Point(460, 16);
			this.vScrollBar.Maximum = 12;
			this.vScrollBar.Name = "vScrollBar";
			this.vScrollBar.Size = new System.Drawing.Size(17, 181);
			this.vScrollBar.TabIndex = 3;
			this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBar_Scroll);
			// 
			// userControlGrossIncome1
			// 
			this.userControlGrossIncome1.Amount = 0D;
			this.userControlGrossIncome1.AmountWidth = 245;
			this.userControlGrossIncome1.Location = new System.Drawing.Point(3, 3);
			this.userControlGrossIncome1.Name = "userControlGrossIncome1";
			this.userControlGrossIncome1.SalaryTypeWidth = 140;
			this.userControlGrossIncome1.Size = new System.Drawing.Size(391, 21);
			this.userControlGrossIncome1.TabIndex = 0;
			this.userControlGrossIncome1.SalaryItemChanged += new System.EventHandler<SalaryItemChangedEventArgs>(this.UserControlGrossIncome1_SalaryItemChanged);
			// 
			// UserControlSalaryItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.Name = "UserControlSalaryItems";
			this.Size = new System.Drawing.Size(480, 200);
			this.groupBox.ResumeLayout(false);
			this.panelBackground.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox;
		private UserControlGrossIncome userControlGrossIncome1;
		private System.Windows.Forms.Button buttonRemove1;
		private System.Windows.Forms.Button buttonAdd1;
		private System.Windows.Forms.VScrollBar vScrollBar;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Panel panelBackground;
	}
}
