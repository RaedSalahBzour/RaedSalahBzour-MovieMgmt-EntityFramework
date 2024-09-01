using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Modles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  public class GenreController : ControllerBase
    {
        private readonly AppDBContext context;

        public GenreController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<GenreController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Genre>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Genres.ToListAsync());
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var genre = await context.Genres
                 .SingleOrDefaultAsync(m => m.GenreId == id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        // POST api/<GenreController>
        [HttpPost]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Genre genre)
        {
            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { Id = genre.GenreId }, genre);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Genre genre)
        {
            var existingGenre = await context.Genres.FindAsync(id);
            if (existingGenre == null)
            { return NotFound(); }
            existingGenre.Name = genre.Name;
            await context.SaveChangesAsync();
            return Ok(existingGenre);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var genre = await context.Genres.FindAsync(id);
            if (genre == null)
            { return NotFound(); }
            context.Genres.Remove(genre);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
