using System.ComponentModel.DataAnnotations;

namespace BuyWise.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "*")]
        public required string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long CreatedBy { get; set; } // Current user ID
        public long ModifiedBy { get; set; } // ID of current user will be saved with modify action
        public bool IsNotActive { get; set; } = false; // Soft delete
    }

}
