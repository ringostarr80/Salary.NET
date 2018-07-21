using System;
using System.Net;
using System.Security;
using System.Web;
using System.Windows.Forms;

namespace Salary.NET
{
	public partial class LoginToOnlineAccountForm : Form
	{
		public string BaseUrl { get; private set; } = string.Empty;
		public SecureString EncryptionPassword { get; private set; } = new SecureString();
		public string Username { get; private set; } = string.Empty;
		public SecureString Password { get; private set; } = new SecureString();

		public LoginToOnlineAccountForm()
		{
			InitializeComponent();
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private async void ButtonLogin_Click(object sender, EventArgs e)
		{
			var getInfosUrl = this.TextBoxBaseUrl.Text + "user";
			getInfosUrl += "?name=" + HttpUtility.UrlEncode(this.TextBoxUsername.Text);
			getInfosUrl += "&password=" + HttpUtility.UrlEncode(this.TextBoxPassword.Text);

			using (var webClient = new WebClient()) {
				try {
					this.ButtonLogin.Enabled = false;
					this.ButtonCancel.Enabled = false;
					var response = await webClient.DownloadStringTaskAsync(getInfosUrl);

					this.BaseUrl = this.TextBoxBaseUrl.Text;
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
				} catch (Exception exc) {
					MessageBox.Show(exc.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					this.ButtonLogin.Enabled = true;
					this.ButtonCancel.Enabled = true;
				}
			}
		}
	}
}
