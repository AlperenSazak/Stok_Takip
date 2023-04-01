using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Repository.QuantityUnitRepo
{
    public class QuantityUnitRepository : GenericRepository<QuantityUnit>, IQuantityUnitRepository
    {
        public QuantityUnitRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            
        }
    }
}
