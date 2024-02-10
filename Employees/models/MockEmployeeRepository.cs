namespace Employees.models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeRepository;

        public MockEmployeeRepository()
        {
            _employeeRepository = new List<Employee>() {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com" },
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com" },
                new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "sam@pragimtech.com" },
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>null if not found, otherwise the corresponding Employee according it Id.</returns>
        public Employee? GetEmployeeById(int Id)
        {
            Employee? employee = _employeeRepository.FirstOrDefault(e => e.Id == Id);
            return employee;
        }

        public Employee? AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = _employeeRepository.Max(e => e.Id) + 1;
            _employeeRepository.Add(newEmployee);
            return GetEmployeeById(newEmployee.Id);
        }

        public Employee? UpdateEmploeye(int id, Employee updatedEmployee)
        {
            Employee? employeeToUpdate = _employeeRepository.Find(e => e.Id == id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = updatedEmployee.Name != null ? updatedEmployee.Name : employeeToUpdate.Name;
                employeeToUpdate.Department = updatedEmployee.Department != null ? updatedEmployee.Department : employeeToUpdate.Department;
                employeeToUpdate.Email = updatedEmployee.Email != null ? updatedEmployee.Email : employeeToUpdate.Email;

            }
            return employeeToUpdate;
        }

        public bool DeleteEmployee(int id)
        {
            bool succeeded = false;
            Employee? employeeToDelete = _employeeRepository.Find(e => e.Id == id);
            if (employeeToDelete != null)
            {
                succeeded = _employeeRepository.Remove(employeeToDelete);
            }
            return succeeded;
        }
    }


}
