using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6CodyNettesheim.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6CodyNettesheim.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _movieContext;

        public HomeController(MoviesContext temp)
        {
            _movieContext = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieAddition()
        {
            ViewBag.Category = _movieContext.Categories.ToList();

            return View("MovieAddition", new Additions());
        }
        [HttpPost]
        public IActionResult MovieAddition(Additions response) 
        {
            if (ModelState.IsValid)
            {

                _movieContext.Movies.Add(response);
                _movieContext.SaveChanges();
                return View("Confirm", response);

            }
            else //invalid data
            {
                ViewBag.Category = _movieContext.Categories.ToList();

                return View(response);
            }
        
        }

        public IActionResult MovieList()
        {
            //linq
            var movies = _movieContext.Movies.Include("Category").ToList();

            return View(movies);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var recordToEdit = _movieContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Category = _movieContext.Categories.ToList();

            return View("MovieAddition", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Additions updatedInfo)
        {
            _movieContext.Update(updatedInfo);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _movieContext.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Additions application)
        {
            _movieContext.Movies.Remove(application);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


    }
}
