using System.Text.Json.Serialization;

namespace Employees.models
{
    public class Employee
    {
        public int Id { get; set; }
        [JsonPropertyName("EmployeeName")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }  
    }
}
