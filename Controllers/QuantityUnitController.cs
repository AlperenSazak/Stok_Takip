using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Models;
using Stok_Takip.Repository.QuantityUnitRepo;

namespace Stok_Takip.Controllers
{
    public class QuantityUnitController : Controller
    {
        private readonly IQuantityUnitRepository _quantityUnitRepository;

        public QuantityUnitController(IQuantityUnitRepository quantityUnitRepository)
        {
            _quantityUnitRepository = quantityUnitRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            return View();
        }

        public IActionResult GetAll() 
        {
            var data = _quantityUnitRepository.GetAll();
            return Ok(data);
        }

        public IActionResult Add(QuantityUnit quantityUnit)
        {
            try
            {
                _quantityUnitRepository.Add(quantityUnit);
                TempData["Message"] = "Miktar Birimi Eklendi";
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
            var quantityUnit = _quantityUnitRepository.GetById(id);
            return View(quantityUnit);
        }
        public IActionResult UpdateQuantityUnit(QuantityUnit quantityUnit)
        {
            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                _quantityUnitRepository.Update(quantityUnit, id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["Error"]=e.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            try
            {
                _quantityUnitRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }
    }
}
