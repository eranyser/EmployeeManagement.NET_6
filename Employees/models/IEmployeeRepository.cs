namespace Employees.models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);

        Employee? AddEmployee(Employee newEmployee);

        Employee? UpdateEmploeye(int id, Employee updatedEmployee);

        bool DeleteEmployee(int id);
    }
}
