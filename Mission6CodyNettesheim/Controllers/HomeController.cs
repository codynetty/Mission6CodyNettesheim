using Microsoft.AspNetCore.Mvc;
using Mission6CodyNettesheim.Models;
using System.Diagnostics;

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
        public IActionResult movies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult movies(Additions response) 
        {
            _movieContext.Additions.Add(response);
            _movieContext.SaveChanges();

            return View("Confirm");
        }
     

    }
}
