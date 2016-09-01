using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryLibrary
{
	public interface ISalaryDataProvider
	{
		uint InsertEmployee(Employee employee);
		Task<uint> InsertEmployeeAsync(Employee employee);
		void UpdateEmployee(Employee employee);
		Task UpdateEmployeeAsync(Employee employee);
		void DeleteEmployee(uint id);
		void DeleteEmployee(string firstName, string lastName);
		void DeleteEmployee(Employee employee);
		bool EmployeeExists(uint id);
		bool EmployeeExists(string firstName, string lastName);
		Employee GetEmployee(uint id);
		Employee GetEmployee(string firstName, string lastName);
		uint GetEmployeesCount();
		List<Employee> GetEmployees();
		Task<List<Employee>> GetEmployeesAsync();
		uint GetEmployees(Action<Employee> callback);

		uint InsertSalary(SalaryAccount salary);
		SalaryAccount GetSalaryAccount(uint id);
		void UpdateSalary(SalaryAccount salary);
		void DeleteSalary(uint id);
		void DeleteSalary(SalaryAccount salary);
	}
}
