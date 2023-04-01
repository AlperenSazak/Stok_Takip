using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Repository.StockTypeRepo
{
    public class StockTypeRepository : GenericRepository<StockType>, IStockTypeRepository
    {
        public StockTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
                      
        }
    }
}
