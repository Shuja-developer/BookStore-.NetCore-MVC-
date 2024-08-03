using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreServices Services;
        public GenreController(IGenreServices Services)
        {
            this.Services = Services;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genres model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Services.Add(model);
            if (result)
            {
                TempData["msg"] = "Added successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "error has occur on server side";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            var record = Services.FindById(id);
            return View();
        }
        [HttpPost]
        public IActionResult Update(Genres model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Services.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "error are occur on server side";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = Services.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll(int id)
        {
            var data = Services.GetALl();
            return View(data);
        }
    }
}
