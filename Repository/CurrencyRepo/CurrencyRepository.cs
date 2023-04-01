using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Repository.CurrencyRepo
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository 
    {
        public CurrencyRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            
        }
    }
}
