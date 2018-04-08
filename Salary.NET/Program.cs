using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Salary.NET
{
	static class Program
	{
		private static SalaryForm _form = null;

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.ThreadException += Application_ThreadExceptionAsync;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			_form = new SalaryForm();
			Application.Run(_form);
		}

		private static async void Application_ThreadExceptionAsync(object sender, ThreadExceptionEventArgs e)
		{
			var message = _form.GetLocalizedString("QUESTION_UNHANDLED_EXCEPTION_SEND_REPORT");
			message += "\n\nException message: " + e.Exception.Message + "\nException stacktrace: " + e.Exception.ToString();
			var dialogResult = MessageBox.Show(message, _form.GetLocalizedString("UNHANDLED_EXCEPTION"), MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
			if (dialogResult != DialogResult.Yes) {
				return;
			}

			var repeat = false;
			do {
				repeat = false;
				try {
					using (var webClient = new WebClient()) {
						var parameters = new NameValueCollection {
							{ "message", e.Exception.Message },
							{ "stacktrace", e.Exception.ToString() }
						};
						var url = "https://salary.ringoleese.de/api/salary.net/report_crash.php";
						var result = await webClient.UploadValuesTaskAsync(url, parameters);
						MessageBox.Show(_form.GetLocalizedString("UNHANDLED_EXCEPTION_REPORT_SENT_SUCCESSFULLY"), _form.GetLocalizedString("HINT"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
				} catch (Exception exc) {
					var errorMessage = string.Format(_form.GetLocalizedString("UNHANDLED_EXCEPTION_REPORT_SENT_FAILED"), exc.Message);
					dialogResult = MessageBox.Show(errorMessage, _form.GetLocalizedString("ERROR"), MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					if (dialogResult == DialogResult.Yes) {
						repeat = true;
					}
				}
			} while (repeat);
		}
	}
}
