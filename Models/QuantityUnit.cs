using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class QuantityUnit : BaseEntity
    {
        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string? Name { get; set; }
    }
}
