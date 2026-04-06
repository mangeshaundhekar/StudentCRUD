using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Key]
        public int StudId { get; set; }
    }
}
