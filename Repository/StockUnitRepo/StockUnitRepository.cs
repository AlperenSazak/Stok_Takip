using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Repository.StockUnitRepo
{
    public class StockUnitRepository : GenericRepository<StockUnit>, IStockUnitRepository
    {
        public StockUnitRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
        }

        public IQueryable<StockUnitDto> GetStockUnitDtos()
        {
            var response = from su in _appDbContext.StockUnits_Tbl
                           join st in _appDbContext.StockTypes_Tbl
                           on su.StockTypeId equals st.Id
                           join qu in _appDbContext.QuantityUnits_Tbl
                           on su.QuantityUnitId equals qu.Id
                           join cu in _appDbContext.Currencies_Tbl
                           on su.PurchaseCurrencyId equals cu.Id
                           join cut in _appDbContext.Currencies_Tbl
                           on su.SalesCurrencyId equals cut.Id
                           select new StockUnitDto
                           {
                               Id = su.Id,
                               UnitCode = su.UnitCode,
                               StockType = st.Name,
                               QuantityType = qu.Name,
                               Description = su.Description,
                               PurchasePrice = su.PurchasePrice,
                               SalePrice = su.SalePrice,
                               PurchaseCurrency = cu.Name,
                               SaleCurrency = cut.Name,
                               PaperWeight = su.PaperWeight,
                               Status = st.Status
                           };
            return response;

        }
    }
}
