namespace Stok_Takip.Models
{
    public class StockUnitDto
    {
        public int Id { get; set; }
        public string UnitCode { get; set; }
        public string StockType { get; set; }
        public string QuantityType { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseCurrency { get; set; }
        public decimal SalePrice { get; set; }
        public string SaleCurrency { get; set; }
        public decimal PaperWeight { get; set; }
        public bool? Status { get; set; }
    }
}
