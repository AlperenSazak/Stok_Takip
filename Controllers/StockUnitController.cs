using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Models;
using Stok_Takip.Repository.CurrencyRepo;
using Stok_Takip.Repository.QuantityUnitRepo;
using Stok_Takip.Repository.StockTypeRepo;
using Stok_Takip.Repository.StockUnitRepo;


namespace Stok_Takip.Controllers
{
    public class StockUnitController : Controller
    {
        private readonly IStockUnitRepository _stockUnitRepository;
        private readonly IStockTypeRepository _stockTypeRepository;
        private readonly IQuantityUnitRepository _quantityUnitRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public StockUnitController(
            IStockUnitRepository stockUnitRepository,
            IStockTypeRepository stockTypeRepository, 
            IQuantityUnitRepository quantityUnitRepository,
            ICurrencyRepository currencyRepository
            )
        {
            _stockUnitRepository = stockUnitRepository;
            _stockTypeRepository = stockTypeRepository;
            _quantityUnitRepository = quantityUnitRepository;
            _currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            ViewData["StockTypes"] = _stockTypeRepository.GetAll();           
            ViewData["QuantityUnits"] = _quantityUnitRepository.GetAll();           
            ViewData["Currencies"] = _currencyRepository.GetAll();
            return View();
        }

        public IActionResult GetAll()
        {
            var data = _stockUnitRepository.GetStockUnitDtos();
            return Ok(data);
        }

        public IActionResult Add(StockUnit stockUnit) 
        {
            try
            {           
                _stockUnitRepository.Add(stockUnit);
                TempData["Message"] = "Stok Birimi Eklendi";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }
        public IActionResult Update()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            TempData["id"] = id;
            var stockUnit = _stockUnitRepository.GetById(id);
            return View(stockUnit);
        }
        public IActionResult UpdateStockUnit(StockUnit stockUnit)
        {
            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                var dbStockUnit = _stockUnitRepository.GetById(id);
                stockUnit.QuantityUnitId = dbStockUnit.QuantityUnitId;
                stockUnit.SalesCurrencyId = dbStockUnit.SalesCurrencyId;
                stockUnit.PurchaseCurrencyId = dbStockUnit.PurchaseCurrencyId;
                stockUnit.StockTypeId = dbStockUnit.StockTypeId;
                _stockUnitRepository.Update(stockUnit, id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _stockUnitRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }
    }
}
