using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class Currency : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        [MinLength(1)]
        public string? Name { get; set; }
    }
}
