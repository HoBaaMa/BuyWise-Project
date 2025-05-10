using System.ComponentModel.DataAnnotations;

namespace BuyWise.Models
{
    public class Customer : BaseModel
    {
        [Required(ErrorMessage = "*")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public required string Mobile { get; set; }

        [Required(ErrorMessage = "*")]
        public required string Password { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNo { get; set; }
        public string? Floor { get; set; }
        public string? UnitNo { get; set; }

    }
}
