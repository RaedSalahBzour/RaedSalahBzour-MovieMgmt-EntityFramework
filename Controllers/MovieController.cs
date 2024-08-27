using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Modles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDBContext context;

        public MovieController(AppDBContext context)
        {
            this.context = context;
        }
        // GET: api/<MovieController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Movie>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Movies.Include(m=>m.Genre).ToListAsync());
        }

        // GET api/<MovieController>/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var movie = await context.Movies
                .Include(m=>m.Genre)
                .SingleOrDefaultAsync(m=>m.Id==id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpGet("by-year/{year:int}")]
        [ProducesResponseType(typeof(List<MovieTitle>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByYear([FromRoute] int year)
        {
            var filteredMovies = await (context.Movies.Where(movie => movie.ReleaseDate.Year == year)
                                                .Select(movie=>new MovieTitle { Id=movie.Id ,Title=movie.Title})).ToListAsync();

            return Ok( filteredMovies);
           
        }
        [HttpGet("until-age/{ageRating}")]
        [ProducesResponseType(typeof(List<MovieTitle>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAge([FromRoute]AgeRating ageRating)
        {

           var filteredMovies= await context.Movies.Where(m => m.AgeRating <= ageRating)
                                                   .Select(m => new MovieTitle { Id = m.Id, Title = m.Title })
                                                   .ToListAsync();
            return Ok(filteredMovies);
        }
        // POST api/<MovieController>
        [HttpPost]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Movie movie)
        {
            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();   
            return CreatedAtAction(nameof(Get), new {id=movie.Id},movie);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] Movie movie)
        {
            var existingMovie = await context.Movies.FindAsync(id);
            if (existingMovie == null) 
            { return NotFound(); }
            existingMovie.Title= movie.Title;
            existingMovie.ReleaseDate=movie.ReleaseDate;
            existingMovie.Synopsis= movie.Synopsis;
            await context.SaveChangesAsync();
            return Ok(existingMovie);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var movie=await context.Movies.FindAsync(id);
            if (movie == null)
            { return NotFound(); }
            context.Movies.Remove(movie);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
