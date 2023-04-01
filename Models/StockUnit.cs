using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class StockUnit : BaseEntity
    {
        [Required]
        public string? UnitCode { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        [Required]
        public decimal PaperWeight { get; set; }
        
        [Required]
        public int StockTypeId { get; set; }
        
        [Required]
        public int QuantityUnitId  { get; set;}
    
       
        public int PurchaseCurrencyId { get; set; }

    
        public int SalesCurrencyId { get; set; }
       

    }
}

