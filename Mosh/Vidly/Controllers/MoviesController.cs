using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            //ViewData["movie"] = movie;
            var customers = new List<Customer> {
                new Customer() { Name = "Cliente 1", Id = 1},
                new Customer() { Name = "Cliente 2", Id = 2}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);




            //return new EmptyResult();
            //return HttpNotFound("Página não encontrada!");
            //return Content("Hello World");
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        public ActionResult Index(int? PageIndex = 10, string sortBy = "teste")
        {
            return Content($"pageIndex={PageIndex} e sortBy={sortBy}");
        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            if (year == 0 || !year.HasValue) year = DateTime.Now.Year;
            if (month == 0 || !month.HasValue) month = DateTime.Now.Month;

            return Content($"year={year}, month={month}");
        }

    }
}