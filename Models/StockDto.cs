namespace Stok_Takip.Models
{
    public class StockDto
    {
        public int Id { get; set; }

        public string UnitCode { get; set; }

        public string Description { get; set; }

        public string StockType { get; set; }

        public decimal TotalStockAmount { get; set; }

        public int CriticalAmount { get; set; }

    }
}
