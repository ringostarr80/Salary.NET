namespace Salary.NET
{
	partial class LoginToOnlineAccountForm
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
			if (disposing && (components != null)) {
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
			this.TextBoxBaseUrl = new System.Windows.Forms.TextBox();
			this.LabelBaseUrl = new System.Windows.Forms.Label();
			this.LabelUsername = new System.Windows.Forms.Label();
			this.TextBoxUsername = new System.Windows.Forms.TextBox();
			this.LabelPassword = new System.Windows.Forms.Label();
			this.TextBoxPassword = new System.Windows.Forms.TextBox();
			this.LabelEncryptionPassword = new System.Windows.Forms.Label();
			this.TextBoxEncryptionPassword = new System.Windows.Forms.TextBox();
			this.ButtonLogin = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.Label2StarHint = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TextBoxBaseUrl
			// 
			this.TextBoxBaseUrl.Location = new System.Drawing.Point(166, 12);
			this.TextBoxBaseUrl.Name = "TextBoxBaseUrl";
			this.TextBoxBaseUrl.Size = new System.Drawing.Size(226, 20);
			this.TextBoxBaseUrl.TabIndex = 1;
			this.TextBoxBaseUrl.Text = "https://salary.ringoleese.de/api/salary.net/";
			// 
			// LabelBaseUrl
			// 
			this.LabelBaseUrl.AutoSize = true;
			this.LabelBaseUrl.Location = new System.Drawing.Point(12, 15);
			this.LabelBaseUrl.Name = "LabelBaseUrl";
			this.LabelBaseUrl.Size = new System.Drawing.Size(51, 13);
			this.LabelBaseUrl.TabIndex = 7;
			this.LabelBaseUrl.Text = "Basis-Url:";
			// 
			// LabelUsername
			// 
			this.LabelUsername.AutoSize = true;
			this.LabelUsername.Location = new System.Drawing.Point(12, 41);
			this.LabelUsername.Name = "LabelUsername";
			this.LabelUsername.Size = new System.Drawing.Size(78, 13);
			this.LabelUsername.TabIndex = 8;
			this.LabelUsername.Text = "Benutzername:";
			// 
			// TextBoxUsername
			// 
			this.TextBoxUsername.Location = new System.Drawing.Point(166, 38);
			this.TextBoxUsername.Name = "TextBoxUsername";
			this.TextBoxUsername.Size = new System.Drawing.Size(226, 20);
			this.TextBoxUsername.TabIndex = 2;
			// 
			// LabelPassword
			// 
			this.LabelPassword.AutoSize = true;
			this.LabelPassword.Location = new System.Drawing.Point(12, 67);
			this.LabelPassword.Name = "LabelPassword";
			this.LabelPassword.Size = new System.Drawing.Size(53, 13);
			this.LabelPassword.TabIndex = 9;
			this.LabelPassword.Text = "Passwort:";
			// 
			// TextBoxPassword
			// 
			this.TextBoxPassword.Location = new System.Drawing.Point(166, 64);
			this.TextBoxPassword.Name = "TextBoxPassword";
			this.TextBoxPassword.PasswordChar = '*';
			this.TextBoxPassword.Size = new System.Drawing.Size(226, 20);
			this.TextBoxPassword.TabIndex = 3;
			// 
			// LabelEncryptionPassword
			// 
			this.LabelEncryptionPassword.AutoSize = true;
			this.LabelEncryptionPassword.Location = new System.Drawing.Point(12, 93);
			this.LabelEncryptionPassword.Name = "LabelEncryptionPassword";
			this.LabelEncryptionPassword.Size = new System.Drawing.Size(148, 13);
			this.LabelEncryptionPassword.TabIndex = 10;
			this.LabelEncryptionPassword.Text = "Verschlüsselungs-Kennwort**:";
			// 
			// TextBoxEncryptionPassword
			// 
			this.TextBoxEncryptionPassword.Location = new System.Drawing.Point(166, 90);
			this.TextBoxEncryptionPassword.Name = "TextBoxEncryptionPassword";
			this.TextBoxEncryptionPassword.PasswordChar = '*';
			this.TextBoxEncryptionPassword.Size = new System.Drawing.Size(226, 20);
			this.TextBoxEncryptionPassword.TabIndex = 4;
			// 
			// ButtonLogin
			// 
			this.ButtonLogin.Location = new System.Drawing.Point(85, 159);
			this.ButtonLogin.Name = "ButtonLogin";
			this.ButtonLogin.Size = new System.Drawing.Size(75, 23);
			this.ButtonLogin.TabIndex = 5;
			this.ButtonLogin.Text = "Einloggen";
			this.ButtonLogin.UseVisualStyleBackColor = true;
			this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Location = new System.Drawing.Point(244, 159);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.ButtonCancel.TabIndex = 6;
			this.ButtonCancel.Text = "Abbrechen";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// Label2StarHint
			// 
			this.Label2StarHint.AutoSize = true;
			this.Label2StarHint.Location = new System.Drawing.Point(12, 123);
			this.Label2StarHint.Name = "Label2StarHint";
			this.Label2StarHint.Size = new System.Drawing.Size(359, 13);
			this.Label2StarHint.TabIndex = 11;
			this.Label2StarHint.Text = "** Wird nur lokal im Speicher gehalten und nicht an den Server übertragen!";
			// 
			// LoginToOnlineAccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(407, 194);
			this.Controls.Add(this.Label2StarHint);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonLogin);
			this.Controls.Add(this.TextBoxEncryptionPassword);
			this.Controls.Add(this.LabelEncryptionPassword);
			this.Controls.Add(this.TextBoxPassword);
			this.Controls.Add(this.LabelPassword);
			this.Controls.Add(this.TextBoxUsername);
			this.Controls.Add(this.LabelUsername);
			this.Controls.Add(this.LabelBaseUrl);
			this.Controls.Add(this.TextBoxBaseUrl);
			this.Name = "LoginToOnlineAccountForm";
			this.Text = "LoginToOnlineAccountForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextBoxBaseUrl;
		private System.Windows.Forms.Label LabelBaseUrl;
		private System.Windows.Forms.Label LabelUsername;
		private System.Windows.Forms.TextBox TextBoxUsername;
		private System.Windows.Forms.Label LabelPassword;
		private System.Windows.Forms.TextBox TextBoxPassword;
		private System.Windows.Forms.Label LabelEncryptionPassword;
		private System.Windows.Forms.TextBox TextBoxEncryptionPassword;
		private System.Windows.Forms.Button ButtonLogin;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Label Label2StarHint;
	}
}