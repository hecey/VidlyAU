using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAU.Models;
using System.Data.Entity;
using VidlyAU.ViewModels;
using System.Data.Entity.Validation;

namespace VidlyAU.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                
                Genres = genres
            };
            //ViewBag.MainHeader ="New Movie";
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieModel = new MovieFormViewModel(movie) {
                    Genres = _context.Genres,

                };
                return View("MovieForm", movieModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Movies");

        }

        // GET: Movies
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(c => c.Genres).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList().SingleOrDefault(c => c.Id == Id);
            return View(movies);
        }


        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {              
                Genres = _context.Genres.ToList()
            };
           // ViewBag.MainHeader = "Edit Movie";
            return View("MovieForm", viewModel);
        }
        //private IEnumerable<Movies> GetMovies()
        //{


        //    return new List<Movies> {

        //        new Movies { Id=1, Name="Shrek" },
        //        new Movies { Id=2, Name="Wall-e" },
        //    };
        //}
    }
}