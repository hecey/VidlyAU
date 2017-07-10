using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VidlyAU.DTOs;
using VidlyAU.Models;
using System.Data.Entity;

namespace VidlyAU.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.ToList().SingleOrDefault(m => m.Id == Id);

            if (movie == null)
            {
                return BadRequest();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);


            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(Request.RequestUri + "/" + movie.Id, movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        public void  UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDB = _context.Movies.ToList().SingleOrDefault(m => m.Id == Id);

            if (movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDB);

            _context.SaveChanges();

        }

        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.ToList().SingleOrDefault(m => m.Id == Id);

            if (movieInDb == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }


    }
}
