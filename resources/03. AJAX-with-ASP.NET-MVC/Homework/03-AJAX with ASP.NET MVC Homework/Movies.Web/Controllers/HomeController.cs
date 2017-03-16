using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Movies.Data;
using Movies.Web.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        // In my course project It will come from IoC Container the logic part will be executed in Service layer
        MoviesDbContext data = new MoviesDbContext();

        public ActionResult Index()
        {
            var movies = data.Movies.Select(MovieViewModel.FromMovie).AsQueryable();
            return View(movies);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = data.Movies.Find(id);
            Thread.Sleep(2000);
            return this.PartialView("_MovieDetails", movie);
        }
    }
}