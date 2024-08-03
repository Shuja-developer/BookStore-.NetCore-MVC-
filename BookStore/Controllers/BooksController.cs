using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using BookStore.Repository.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookServices BookServices;
        private readonly IAuthorServices authorServices;
        private readonly IGenreServices genreServices;
        private readonly IPublisherServices publisherServices;
        public BooksController(IBookServices BookServices, IAuthorServices  authorServices, IGenreServices genreServices, IPublisherServices publisherServices)
        {
            this.BookServices = BookServices;
            this.authorServices = authorServices;
            this.genreServices = genreServices;
            this.publisherServices = publisherServices;
        }
        public IActionResult Add()
        {
            var model = new Book();
            model.AuthorList = authorServices.GetALl().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString()}).ToList();
            model.PublisherList = publisherServices.GetALl().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString()}).ToList();
            model.GenreList = genreServices.GetALl().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString()}).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = authorServices.GetALl().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherServices.GetALl().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreServices.GetALl().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = BookServices.Add(model);
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
            var model = BookServices.FindById(id);
               model.AuthorList = authorServices.GetALl().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected= a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherServices.GetALl().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreServices.GetALl().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = authorServices.GetALl().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherServices.GetALl().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreServices.GetALl().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = BookServices.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "error are occur on server side";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = BookServices.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll(int id)
        {
            var data = BookServices.GetALl();
            return View(data);
        }
    }
}
