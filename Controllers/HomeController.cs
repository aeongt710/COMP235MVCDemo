using COMP235MVCDemo.DataAccessObjects;
using COMP235MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COMP235MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Movie()
        {
            ViewBag.Message = "My Movie Page.";
            //Movie m = new Movie(1, "Star Wars", "George Lucas");
            //return View();
            //return View(m);

            MovieDAO dAO = new MovieDAO();
            Movie m = dAO.getMovieById(2);
            return View(m);

        }


        public ActionResult AddMovie(Movie m, string Save) 
        {
            ViewBag.Message = "Add A Movie Page";
            if (Save == "Save"){
                MovieDAO dAO = new MovieDAO();
                dAO.InsertMovie(m);
                ViewBag.Message = "Movie Added successfully";
                return View("Home");
            }
             return View("AddMovie");
        }


        public ActionResult Details(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            movie = dAO.getMovieById(movie.Id);
            return View("Movie", movie);
        }


        public ActionResult MoviesEdit(int? id, Movies movies)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            movies = dAO.getAllMovies();
            movies.EditIndex = dAO.setMovieToEditMode(movies.Items, id2);
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }

        public ActionResult AllMovies(Movies m, String Save)
        {
            ViewBag.Message = "All movies.";
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                Movie movie = m.Items[m.EditIndex];
                dAO.updateMovie(movie);
                movie.IsEditable = false;
                m.EditIndex = -1;
            }
            m = dAO.getAllMovies();
            return View(m);
        }


        public ActionResult MoviesDelete(int? id, Movies movies)
        {
            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            dAO.deleteMovie(id2);
            movies = dAO.getAllMovies();
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }
    }
}