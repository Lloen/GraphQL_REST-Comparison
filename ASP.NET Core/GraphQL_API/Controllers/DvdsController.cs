using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraphQL_API.Models;

namespace GraphQL_API.Controllers
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [ApiController]
    public class DvdsController : ControllerBase
    {
        private readonly DVD_LibraryContext _context;

        public DvdsController(DVD_LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Dvds
        [HttpGet]
        public async Task<ActionResult<List<Dvd>>> GetDvd()
        {

            return await _context.Dvd.Select(d => new Dvd
            {
                DvdId = d.DvdId,
                Isbn = d.Isbn,
                MovieId = d.MovieId,
                Edition = d.Edition,
                Region = d.Region,
                Movie = _context.Movie.Select(m => new Movie
                {
                    MovieId = m.MovieId,
                    MovieTitle = m.MovieTitle,
                    Length = m.Length,
                    GenreId = m.GenreId,
                    ReleaseDate = m.ReleaseDate,
                    Genre = _context.Genre.Select(g => new Genre
                    {
                        GenreId = g.GenreId,
                        Genre1 = g.Genre1
                    })
                    .Where(g => g.GenreId == m.GenreId)
                    .FirstOrDefault()
                })
                            .Where(m => m.MovieId == d.MovieId)
                            .FirstOrDefault()
            })
                .ToListAsync();
        }

        // GET: api/Dvds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dvd>> GetDvd(long id)
        {
            var dvd = await _context.Dvd.Select(d => new Dvd
            {
                DvdId = d.DvdId,
                Isbn = d.Isbn,
                MovieId = d.MovieId,
                Edition = d.Edition,
                Region = d.Region,
                Movie = _context.Movie.Select(m => new Movie
                {
                    MovieId = m.MovieId,
                    MovieTitle = m.MovieTitle,
                    Length = m.Length,
                    GenreId = m.GenreId,
                    ReleaseDate = m.ReleaseDate,
                    Genre = _context.Genre.Select(g => new Genre
                    {
                        GenreId = g.GenreId,
                        Genre1 = g.Genre1
                    })
                    .Where(g => g.GenreId == m.GenreId)
                    .FirstOrDefault()
                })
                                .Where(m => m.MovieId == d.MovieId)
                                .FirstOrDefault()
            })
            .Where(d => d.DvdId == id)
            .FirstOrDefaultAsync();

            if (dvd == null)
            {
                return NotFound();
            }

            return dvd;
        }

        // PUT: api/Dvds/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDvd(long id, Dvd dvd)
        {
            if (id != dvd.DvdId)
            {
                return BadRequest();
            }

            _context.Entry(dvd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DvdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dvds
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dvd>> PostDvd(Dvd dvd)
        {
            _context.Dvd.Add(dvd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw e;
            }

            return CreatedAtAction("GetDvd", new { id = dvd.DvdId }, dvd);
        }

        // DELETE: api/Dvds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dvd>> DeleteDvd(long id)
        {
            var dvd = await _context.Dvd.FindAsync(id);
            if (dvd == null)
            {
                return NotFound();
            }

            _context.Dvd.Remove(dvd);
            await _context.SaveChangesAsync();

            return dvd;
        }

        private bool DvdExists(long id)
        {
            return _context.Dvd.Any(e => e.DvdId == id);
        }
    }
}
