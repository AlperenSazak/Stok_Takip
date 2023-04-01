using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Models;
using Stok_Takip.Repository.CurrencyRepo;

namespace Stok_Takip.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Error = TempData["Error"];
            return View();
        }

        public IActionResult GetAll() 
        {
            var data = _currencyRepository.GetAll();
            return Ok(data);
        }

        public IActionResult Add(Currency currency)
        {
            try
            {
                _currencyRepository.Add(currency);
                TempData["Message"] = "Para Birimi Eklendi";
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
            var currency = _currencyRepository.GetById(id);
            return View(currency);
        }
        public IActionResult UpdateCurrency(Currency currency)
        {
            try
            {
                int id = Convert.ToInt32(TempData["id"]);
                _currencyRepository.Update(currency, id);
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
                _currencyRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception m)
            {
                return Ok(m.Message);
                
            }

        }
    }
}
