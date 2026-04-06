using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCrudDemo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Grade { get; set; }
    }
}
