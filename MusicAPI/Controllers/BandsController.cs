using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using MusicApi.Entities;

namespace MusicApi.Controllers;

[ApiController]
[Route("api")]
public class BandsController : Controller
{
    private readonly MusicDbContext _context;

    public BandsController(MusicDbContext context)
    {
        _context = context;
    }

    // GET: api/bands
    [HttpGet("bands")]
    public async Task<IActionResult> GetAllBands()
    {
        var bands = await _context.Bands.ToListAsync();
        return Ok(bands);
    }

    // GET: api/artistId/albums
    [HttpGet("band/{bandId}")]
    public async Task<IActionResult> GetBandById(int bandId)
    {
        try
        {
            int localBandId = bandId; 
            var band = await _context.Bands
                .FirstOrDefaultAsync(a => a.Id == localBandId);
            
            if (band == null)
            {
                return NotFound("Artiste non trouvé");
            }

            return Ok(band);

        }
        catch (Exception)
        {
            return StatusCode(500, "Une erreur s'est produite.");
        }
    }
    
    // POST: api/bands
    [HttpPost("band/create")]
    public async Task<IActionResult> CreateBand([FromBody] Band band)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _context.Bands.Add(band);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetBandById), new { bandId = band.Id }, band);
    }
    
    // DELETE: api/bands
    [HttpDelete("band/{id}")]
    public async Task<IActionResult> DeleteBand(int id)
    {
        var band = await _context.Bands.FindAsync(id);
        if (band == null)
        {
            return NotFound();
        }

        _context.Bands.Remove(band);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}