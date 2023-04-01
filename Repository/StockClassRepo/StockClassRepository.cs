using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Repository.StockClassRepo
{
    public class StockClassRepository : GenericRepository<StockClass>, IStockClassRepository
    {
        public StockClassRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
