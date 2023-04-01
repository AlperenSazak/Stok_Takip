using Stok_Takip.Models;

namespace Stok_Takip.Repository.StockRepo
{
    public interface IStockRepository : IRepository<Stock>
    {
        IQueryable<StockDto> GetStockDtos();
    }
}
