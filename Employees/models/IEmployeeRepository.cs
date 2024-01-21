namespace Employees.models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
    }
}
