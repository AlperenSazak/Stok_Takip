using Stok_Takip.Models;

namespace Stok_Takip.Repository.StockUnitRepo
{
    public interface IStockUnitRepository : IRepository<StockUnit>
    {
        IQueryable<StockUnitDto> GetStockUnitDtos();
    }
}
