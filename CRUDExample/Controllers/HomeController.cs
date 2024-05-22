using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IColorService _colorService;
        public HomeController()
        {
            _colorService = new ColorManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allData = _colorService.GetAll().Data;
            return View(allData);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Color color)
        {
            _colorService.Add(color);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var color = _colorService.GetById(id);
            if(color.Success)
            {
                return View(color.Data);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            _colorService.Update(color);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _colorService.GetById(id);
            if(deletedEntity.Success)
            {
                _colorService.Delete(deletedEntity.Data);
            }
            var allData = _colorService.GetAll().Data;
            return RedirectToAction("Index");
        }
    }
}
