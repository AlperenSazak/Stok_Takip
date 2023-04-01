using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Models;
using Stok_Takip.Repository.StockClassRepo;
using Stok_Takip.Repository.StockRepo;
using Stok_Takip.Repository.StockTypeRepo;
using Stok_Takip.Repository.StockUnitRepo;

namespace Stok_Takip.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockClassRepository _stockClassRepository;
        private readonly IStockTypeRepository _stockTypeRepository;
        private readonly IStockUnitRepository _stockUnitRepository;
        private readonly IStockRepository _stockRepository;

        public StockController(
            IStockRepository stockRepository, 
            IStockClassRepository stockClassRepository, 
            IStockTypeRepository stockTypeRepository, 
            IStockUnitRepository stockUnitRepository)
        {
            _stockRepository = stockRepository;
            _stockClassRepository = stockClassRepository;
            _stockTypeRepository = stockTypeRepository;
            _stockUnitRepository = stockUnitRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            ViewData["StockClasses"] = _stockClassRepository.GetAll();
            ViewData["StockTypes"] = _stockTypeRepository.GetAll();
            ViewData["StockUnits"] = _stockUnitRepository.GetAll();
            ViewData["QuantityUnits"] = _stockUnitRepository.GetAll();
            return View();
        }

        public IActionResult GetAll()
        {
            var data = _stockRepository.GetStockDtos();
            return Ok(data);
        }

        public IActionResult Add(Stock stock)
        {
            try
            {
                _stockRepository.Add(stock);
                TempData["Message"] = "Stok Eklendi";
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
            var stock = _stockRepository.GetById(id);
            return View(stock);
        }
        public IActionResult UpdateStock(Stock stock)
        {
            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                var dbStock = _stockRepository.GetById(id);
                stock.StockUnitId = dbStock.StockUnitId;
                stock.StockClassId = dbStock.StockClassId;
                stock.StockTypeId = dbStock.StockTypeId;
                _stockRepository.Update(stock, id);
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
                _stockRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception m)
            {
                return Ok(m.Message);
                
            }
        }
    }
}
