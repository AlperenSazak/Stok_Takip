using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class StockClass : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
    }
}
