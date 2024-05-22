using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        public SizeController()
        {
            _sizeService = new SizeManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allData = _sizeService.GetAll().Data;
            return View(allData);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Size size)
        {
            _sizeService.Add(size);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var size = _sizeService.GetById(id);
            if (size.Success)
            {
                return View(size.Data);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(Size size)
        {
            _sizeService.Update(size);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _sizeService.GetById(id);
            if (deletedEntity.Success)
            {
                _sizeService.Delete(deletedEntity.Data);
            }
            var allData = _sizeService.GetAll().Data;
            return RedirectToAction("Index");
        }
    }
}
