using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace SalaryLibrary.SalaryDataProviders
{
	public class SalaryDataREST : ISalaryDataProvider
	{
		private readonly string _baseUrl = "https://salary.ringoleese.de/api/salary.net/";
		private readonly string _username = string.Empty;
		private readonly SecureString _password = new SecureString();
		private readonly SecureString _encryptionPassword = new SecureString();

		public SalaryDataREST(string username, SecureString securePassword, SecureString encryptionPassword)
		{
			this._username = username;
			this._password = securePassword;
			this._encryptionPassword = encryptionPassword;
		}

		public SalaryDataREST(string username, SecureString securePassword, SecureString encryptionPassword, string baseUrl)
		{
			this._username = username;
			this._password = securePassword;
			this._encryptionPassword = encryptionPassword;
			this._baseUrl = baseUrl;
		}

		public SalaryDataREST(string username, string password, string encryptionPassword)
		{
			this._username = username;

			var securePassword = new SecureString();
			foreach (var character in password) {
				securePassword.AppendChar(character);
			}
			this._password = securePassword;

			var secureEncryptionPassword = new SecureString();
			foreach (var character in encryptionPassword) {
				secureEncryptionPassword.AppendChar(character);
			}
			this._encryptionPassword = secureEncryptionPassword;
		}

		public SalaryDataREST(string username, string password, string encryptionPassword, string baseUrl)
		{
			this._username = username;

			var securePassword = new SecureString();
			foreach (var character in password) {
				securePassword.AppendChar(character);
			}
			this._password = securePassword;

			var secureEncryptionPassword = new SecureString();
			foreach (var character in encryptionPassword) {
				secureEncryptionPassword.AppendChar(character);
			}
			this._encryptionPassword = secureEncryptionPassword;

			this._baseUrl = baseUrl;
		}

		~SalaryDataREST()
		{
			this._password.Dispose();
		}

		private void StartAPIRequest(string url, Action<JObject> callback)
		{
			var webRequest = HttpWebRequest.CreateHttp(url);
			var cookieString = "name=" + this._username + ";password=";

			var unmanagedString = IntPtr.Zero;
			try {
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(this._password);
				cookieString += Marshal.PtrToStringUni(unmanagedString);
				webRequest.Headers.Add(HttpRequestHeader.Cookie, cookieString);
			} finally {
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}

			try {
				using (var webResponse = webRequest.GetResponse()) {
					var responseString = "";
					using (var responseStream = webResponse.GetResponseStream()) {
						var buffer = new byte[1024];
						var readBytes = 0;
						do {
							readBytes = responseStream.Read(buffer, 0, buffer.Length);
							if (readBytes > 0) {
								responseString += Encoding.UTF8.GetString(buffer, 0, readBytes);
							}
						} while (readBytes > 0);
					}

					switch (webResponse.ContentType) {
						case "application/json":
						case "text/json":
							callback(JObject.Parse(responseString));
							break;

						default:
							throw new Exception("invalid Content-Type received: " + webRequest.ContentType);
					}
				}
			} catch (WebException exc) {
				if (exc.Response == null) {
					throw exc;
				}
				using (var responseStream = exc.Response.GetResponseStream()) {
					var responseString = "";
					var buffer = new byte[1024];
					var readBytes = 0;
					do {
						readBytes = responseStream.Read(buffer, 0, buffer.Length);
						if (readBytes > 0) {
							responseString += Encoding.UTF8.GetString(buffer, 0, readBytes);
						}
					} while (readBytes > 0);

					var jObject = JObject.Parse(responseString);
					if (jObject["message"]?.Type == JTokenType.String) {
						throw new Exception(jObject["message"].ToString());
					}

					throw exc;
				}
			}
		}

		public object InsertEmployee(Employee employee)
		{
			object id = 0;

			var url = this._baseUrl + "data/insert_employee.php";
			url += "?first_name=" + HttpUtility.UrlEncode(employee.FirstName);
			url += "&middle_name=" + HttpUtility.UrlEncode(employee.MiddleName);
			url += "&last_name=" + HttpUtility.UrlEncode(employee.LastName);
			url += "&personnel_number=" + employee.PersonnelNumber;
			url += "&gender=" + employee.Gender;
			url += "&birthday=" + employee.Birthday.ToString("yyyy-MM-dd");
			this.StartAPIRequest(url, (json) => {
				if (json["id"]?.Type == JTokenType.String) {
					id = json["id"].ToObject<string>();
				} else if (json["id"]?.Type == JTokenType.Integer) {
					id = json["id"].ToObject<int>();
				}
			});

			return id;

			throw new NotImplementedException();
		}

		public async Task<object> InsertEmployeeAsync(Employee employee)
		{
			return await Task.Run(() => { return this.InsertEmployee(employee); });
		}

		public void UpdateEmployee(Employee employee)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateEmployeeAsync(Employee employee)
		{
			throw new NotImplementedException();
		}

		public void DeleteEmployee(object id)
		{
			throw new NotImplementedException();
		}

		public void DeleteEmployee(string firstName, string lastName)
		{
			throw new NotImplementedException();
		}

		public void DeleteEmployee(Employee employee)
		{
			//this.DeleteEmployee((uint)employee.Id);
			throw new NotImplementedException();
		}

		public bool EmployeeExists(object id)
		{
			throw new NotImplementedException();
		}

		public bool EmployeeExists(string firstName, string lastName)
		{
			throw new NotImplementedException();
		}

		public Employee GetEmployee(object id)
		{
			throw new NotImplementedException();
		}

		public Employee GetEmployee(string firstName, string lastName)
		{
			throw new NotImplementedException();
		}

		public uint GetEmployeesCount()
		{
			throw new NotImplementedException();
		}

		public List<Employee> GetEmployees()
		{
			var employees = new List<Employee>();

			this.GetEmployees((employee) => {
				employees.Add(employee);
			});

			return employees;
		}

		public async Task<List<Employee>> GetEmployeesAsync()
		{
			return await Task.Run(() => { return this.GetEmployees(); });
		}

		public uint GetEmployees(Action<Employee> callback)
		{
			var count = 0U;

			this.StartAPIRequest(this._baseUrl + "user/employees", (json) => {
				if (json["employees"]?.Type == JTokenType.Array) {
					var jsonEmployees = json["employees"].ToObject<JArray>();
					foreach(var jsonEmployee in jsonEmployees) {
						var employee = new Employee(jsonEmployee);
						callback(employee);
						count++;
					}
				}
			});

			return count;
		}

		private uint GetLastEmployeeId()
		{
			throw new NotImplementedException();
		}

		private uint GetLastSalaryId()
		{
			throw new NotImplementedException();
		}

		private uint GetLastSalaryTypeId()
		{
			throw new NotImplementedException();
		}

		public object InsertSalary(SalaryAccount salary)
		{
			throw new NotImplementedException();
		}

		public SalaryAccount GetSalaryAccount(object id)
		{
			throw new NotImplementedException();
		}

		public List<SalaryAccount> GetSalaryAccounts()
		{
			throw new NotImplementedException();
		}

		public List<SalaryAccount> GetSalaryAccounts(object id)
		{
			throw new NotImplementedException();
		}

		public uint GetSalaryAccounts(Action<SalaryAccount> callback)
		{
			throw new NotImplementedException();
		}

		public uint GetSalaryAccounts(object id, Action<SalaryAccount> callback)
		{
			throw new NotImplementedException();
		}

		public async Task<List<SalaryAccount>> GetSalaryAccountsAsync()
		{
			return await Task.Run(() => { return this.GetSalaryAccounts(); });
		}

		public void UpdateSalary(SalaryAccount salary)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateSalaryAsync(SalaryAccount salary)
		{
			await Task.Run(() => { this.UpdateSalary(salary); });
		}

		public void DeleteSalary(object id)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteSalaryAsync(object id)
		{
			await Task.Run(() => { this.DeleteSalary(id); });
		}

		public SalaryType GetSalaryType(object id)
		{
			throw new NotImplementedException();
		}

		public SalaryTypeCollection GetSalaryTypes()
		{
			var salaryTypes = new SalaryTypeCollection();

			this.StartAPIRequest(this._baseUrl + "data/get_salary_types.php", (json) => {
				if (json["data"]?.Type == JTokenType.Array) {
					
				}
			});

			return salaryTypes;
		}

		public void DeleteSalaryTypes()
		{
			throw new NotImplementedException();
		}

		public object InsertSalaryType(SalaryType salaryType)
		{
			object id = 0;

			var url = this._baseUrl + "data/insert_salary_type.php";
			url += "?name=" + HttpUtility.UrlEncode(salaryType.Name);
			url += "&number=" + salaryType.Number;
			url += "&discount_on_wage=" + salaryType.DiscountOnNetWage.ToString().ToLower();
			this.StartAPIRequest(url, (json) => {
				if (json["id"]?.Type == JTokenType.String) {
					id = json["id"].ToObject<string>();
				} else if (json["id"]?.Type == JTokenType.Integer) {
					id = json["id"].ToObject<int>();
				}
			});

			return id;
		}

		public object[] InsertSalaryTypes(SalaryTypeCollection salaryTypes)
		{
			throw new NotImplementedException();
		}
	}
}
