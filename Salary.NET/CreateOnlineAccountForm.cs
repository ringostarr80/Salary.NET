using System;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace Salary.NET
{
	public partial class CreateOnlineAccountForm : Form
	{
		public string BaseUrl { get; private set; } = string.Empty;
		public SecureString EncryptionPassword { get; private set; } = new SecureString();
		public string Username { get; private set; } = string.Empty;
		public SecureString Password { get; private set; } = new SecureString();

		public CreateOnlineAccountForm()
		{
			InitializeComponent();
		}

		private async void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (!Regex.IsMatch(this.TextBoxBaseUrl.Text, @"^https?://", RegexOptions.Compiled)) {
				MessageBox.Show("Die Basis-Url muss mit 'http://' oder 'https://' anfangen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (string.IsNullOrWhiteSpace(this.TextBoxUsername.Text)) {
				MessageBox.Show("Der Benutzername darf nicht leer oder nur aus Leerzeichen bestehen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (this.TextBoxPassword.Text == "") {
				MessageBox.Show("Das Passwort darf nicht leer sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (this.TextBoxPassword.Text != this.TextBoxRepeatPassword.Text) {
				MessageBox.Show("Das Passwort ist nicht richtig wiederholt worden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (this.TextBoxEncryptionPassword.Text == "") {
				MessageBox.Show("Das Verschlüsselungs-Kennwort darf nicht leer sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (this.TextBoxRepeatEncryptionPassword.Text == "") {
				MessageBox.Show("Das Verschlüsselungs-Kennwort ist nicht richtig wiederholt worden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			var signUpUrl = this.TextBoxBaseUrl.Text + "user/sign_up.php";
			signUpUrl += "?name=" + HttpUtility.UrlEncode(this.TextBoxUsername.Text);
			signUpUrl += "&password=" + HttpUtility.UrlEncode(this.TextBoxPassword.Text);
			signUpUrl += "&email=" + HttpUtility.UrlEncode(this.TextBoxEMail.Text);

			using (var webClient = new WebClient()) {
				try {
					this.ButtonCreate.Enabled = false;
					this.ButtonCancel.Enabled = false;
					var response = await webClient.DownloadStringTaskAsync(signUpUrl);

					this.BaseUrl= this.TextBoxBaseUrl.Text;
					this.Username = this.TextBoxUsername.Text;
					this.Password = new SecureString();
					this.EncryptionPassword = new SecureString();
					foreach (var character in this.TextBoxPassword.Text) {
						this.Password.AppendChar(character);
					}
					foreach (var character in this.TextBoxEncryptionPassword.Text) {
						this.EncryptionPassword.AppendChar(character);
					}
					this.DialogResult = DialogResult.OK;
					this.Close();
				} catch(Exception exc) {
					MessageBox.Show(exc.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					this.ButtonCreate.Enabled = true;
					this.ButtonCancel.Enabled = true;
				}
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
