using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StudentCRUD.Models
{
    public abstract class CommonModel
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual DateTime CreatedAt { get; set; }

       
        public virtual DateTime? UpdatedAt { get; set; }
    }
}
