using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Stok_Takip.Models
{
    public class StockType : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        [MinLength(1)]
       
        public string? Name { get; set; }

        public bool Status { get; set; } = true;
    }

}
