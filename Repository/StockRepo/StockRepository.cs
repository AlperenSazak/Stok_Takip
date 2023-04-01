using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Repository.StockRepo
{
        public class StockRepository : GenericRepository<Stock>, IStockRepository
        {
            public StockRepository(AppDbContext appDbContext) : base(appDbContext)
            {

            }

            public IQueryable<StockDto> GetStockDtos()
            {
            var response = from s in _appDbContext.Stocks_Tbl
                           join sc in _appDbContext.StockClasses_Tbl
                           on s.StockClassId equals sc.Id
                           join st in _appDbContext.StockTypes_Tbl
                           on s.StockTypeId equals st.Id
                           join su in _appDbContext.StockUnits_Tbl
                           on s.StockUnitId equals su.Id
                           select new StockDto
                           {
                               Id = s.Id,
                               UnitCode = su.UnitCode,
                               Description = su.Description,
                               StockType = st.Name,
                               TotalStockAmount = s.Amount,
                               CriticalAmount = s.CriticalAmount
                           };
            return response;
            }
        }
}
