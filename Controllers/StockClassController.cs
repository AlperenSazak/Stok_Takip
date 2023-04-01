using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Models;
using Stok_Takip.Repository.StockClassRepo;

namespace Stok_Takip.Controllers
{
    public class StockClassController : Controller
    {
        private readonly IStockClassRepository _stockClassRepository;

        public StockClassController(IStockClassRepository stockclassRepository)
        {
            _stockClassRepository = stockclassRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            return View();
        }

        public IActionResult GetAll()
        {
            var data = _stockClassRepository.GetAll();
            return Ok(data);
        }

        public IActionResult Add(StockClass stockClass)
        {
            try
            {
                _stockClassRepository.Add(stockClass);
                TempData["Message"] = "Stok Sınıfı Eklendi";
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
            var stockClass = _stockClassRepository.GetById(id);
            return View(stockClass);
        }
        public IActionResult UpdateStockClass(StockClass stockClass)
        {
            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                _stockClassRepository.Update(stockClass, id);
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
                _stockClassRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception m)
            {
                return Ok(m.Message);
                
            }
        }
    }
}
