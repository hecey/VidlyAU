using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using VidlyAU.Dtos;
using VidlyAU.Models;

namespace VidlyAU.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            if (rentalDto.MoviesIds.Count == 0)
            {
                return BadRequest("No movies Ids has been giveng");
            }

            var customer = _context.Customers.ToList().SingleOrDefault(c=>c.Id == rentalDto.CustomerId);

            if (customer == null)
            {
                return  BadRequest("Invalid customer ID");
            }

           

            var  movies = _context.Movies.Where(m => rentalDto.MoviesIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MoviesIds.Count)
            {
                return BadRequest("One or more of the movies is invalid");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            
            _context.SaveChanges();

            return Ok();
        }
    }
}