using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController()
        {
            _cityService = new CityManager();
            _countryService = new CountryManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allData = _cityService.GetAll().Data;
            return View(allData);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Countries = _countryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Add(City city)
        {
            _cityService.Add(city);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city = _cityService.GetById(id);
            if (city.Success)
            {
                ViewBag.Countries = _countryService.GetAll().Data;
                return View(city.Data);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityService.Update(city);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _cityService.GetById(id);
            if (deletedEntity.Success)
            {
                _cityService.Delete(deletedEntity.Data);
            }
            return RedirectToAction("Index");
        }
    }
}
