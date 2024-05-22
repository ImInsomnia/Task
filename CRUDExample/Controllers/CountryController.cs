using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController()
        {
            _countryService = new CountryManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allData = _countryService.GetAll().Data;
            return View(allData);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Country country)
        {
            _countryService.Add(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = _countryService.GetById(id);
            if (country.Success)
            {
                return View(country.Data);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            _countryService.Update(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _countryService.GetById(id);
            if (deletedEntity.Success)
            {
                _countryService.Delete(deletedEntity.Data);
            }
            var allData = _countryService.GetAll().Data;
            return RedirectToAction("Index");
        }
    }
}
