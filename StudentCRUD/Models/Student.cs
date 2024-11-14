
using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Student: CommonModel
    {
        
        [Required(ErrorMessage ="Student Id is required")]
        public virtual string std_Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public virtual string Name { get; set; }
        [Required(ErrorMessage ="Age is required")]
        [Range(15,40,ErrorMessage="Age must between 15 and 40")]
        public virtual int Age { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public virtual string Email { get; set; }
    }
}
