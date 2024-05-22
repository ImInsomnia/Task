using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class CharacteristicsController : Controller
    {
        private readonly ICharacteristicsService _characteristicsService;
        public CharacteristicsController()
        {
            _characteristicsService = new CharacteristicsManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allData = _characteristicsService.GetAll().Data;
            return View(allData);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Characteristics characteristics)
        {
            _characteristicsService.Add(characteristics);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var characteristics = _characteristicsService.GetById(id);
            if (characteristics.Success)
            {
                return View(characteristics.Data);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(Characteristics characteristics)
        {
            _characteristicsService.Update(characteristics);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _characteristicsService.GetById(id);
            if (deletedEntity.Success)
            {
                _characteristicsService.Delete(deletedEntity.Data);
            }
            var allData = _characteristicsService.GetAll().Data;
            return RedirectToAction("Index");
        }
    }
}