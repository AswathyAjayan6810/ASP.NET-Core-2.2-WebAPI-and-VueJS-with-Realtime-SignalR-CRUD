using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}