
using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Student
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        public virtual string std_Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual int Age { get; set; }
        [Required]
        public virtual string Email { get; set; }
    }
}
