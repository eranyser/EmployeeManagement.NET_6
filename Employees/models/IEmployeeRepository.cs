namespace Employees.models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);

        Employee? AddEmployee(Employee newEmployee);
    }
}
