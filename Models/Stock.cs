namespace Stok_Takip.Models
{
    public class Stock : BaseEntity
    {
        public int StockClassId { get; set; }
        public int StockTypeId { get; set; }
        public int StockUnitId { get; set; }
        public int Amount { get; set; }
        public string ShelfInfo { get; set; }
        public string CupBoardInfo { get; set; }
        public int CriticalAmount { get; set; }
    }
}
