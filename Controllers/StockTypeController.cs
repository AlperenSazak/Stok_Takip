using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Models;
using Stok_Takip.Repository;
using Stok_Takip.Repository.StockTypeRepo;

namespace Stok_Takip.Controllers
{
    public class StockTypeController : Controller
    {
        private readonly IStockTypeRepository _stockTypeRepository;

        public StockTypeController(IStockTypeRepository stockTypeRepository)
        {
                _stockTypeRepository = stockTypeRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            return View();
        }
        [HttpGet]
        public IActionResult GetAll() {
            var response = _stockTypeRepository.GetAll();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Add(StockType stockType)
        {
            try
            {
                _stockTypeRepository.Add(stockType);
                TempData["Message"] = "Stok Türü Eklendi";
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
            var stockType = _stockTypeRepository.GetById(id);
            return View(stockType);
        }
        [HttpPost]
        public ActionResult UpdateStockType(StockType stockType, bool Status)
        {
            try
            {
                stockType.Status = Status;
                int id = Convert.ToInt32(TempData["id"]);
                _stockTypeRepository.Update(stockType, id);
                
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
                _stockTypeRepository.Delete(id);
              return  RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }
    }
}
