using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryLibrary
{
	public interface ISalaryDataProvider
	{
		object InsertEmployee(Employee employee);
		Task<object> InsertEmployeeAsync(Employee employee);
		void UpdateEmployee(Employee employee);
		Task UpdateEmployeeAsync(Employee employee);
		void DeleteEmployee(object id);
		void DeleteEmployee(string firstName, string lastName);
		void DeleteEmployee(Employee employee);
		bool EmployeeExists(object id);
		bool EmployeeExists(string firstName, string lastName);
		Employee GetEmployee(object id);
		Employee GetEmployee(string firstName, string lastName);
		uint GetEmployeesCount();
		List<Employee> GetEmployees();
		Task<List<Employee>> GetEmployeesAsync();
		uint GetEmployees(Action<Employee> callback);

		object InsertSalary(SalaryAccount salary);
		SalaryAccount GetSalaryAccount(object id);
		List<SalaryAccount> GetSalaryAccounts();
		List<SalaryAccount> GetSalaryAccounts(object id);
		Task<List<SalaryAccount>> GetSalaryAccountsAsync();
		uint GetSalaryAccounts(Action<SalaryAccount> callback);
		uint GetSalaryAccounts(object id, Action<SalaryAccount> callback);
		void UpdateSalary(SalaryAccount salary);
		Task UpdateSalaryAsync(SalaryAccount salary);
		void DeleteSalary(object id);
		Task DeleteSalaryAsync(object id);

		SalaryType GetSalaryType(object id);
		List<SalaryType> GetSalaryTypes();
		object InsertSalaryType(SalaryType salaryType);
	}
}
