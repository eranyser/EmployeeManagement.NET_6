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
    }
}
