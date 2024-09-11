using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Entities;

namespace MusicApi.Controllers;

[ApiController]
[Route("api")]
public class AlbumsController : Controller
{
    private readonly MusicDbContext _context;

    public AlbumsController(MusicDbContext context)
    {
        _context = context;
    }

    // GET: api/albums
    [HttpGet("albums")]
    public async Task<IActionResult> GetAllAlbum()
    {
        var albums = await _context.Albums.ToListAsync();
        return Ok(albums);
    }

    // GET: api/album/{albumId}
    [HttpGet("album/{albumId}")]
    public async Task<IActionResult> GetAlbumById(int albumId)
    {
        var album = await _context.Albums
            .FirstOrDefaultAsync(a => a.Id == albumId);

        if (album == null)
        {
            return NotFound("Album non trouvé");
        }

        return Ok(album);
    }

    // GET: api/albums/artist
    [HttpGet("albums/{artistId}")]
    public async Task<IActionResult> GetAlbumsByArtist(int artistId)
    {
        try
        {
            int localArtistId = artistId;
            var albums = await _context.Albums
                .Where(a => a.BandId == localArtistId)
                .ToListAsync();

            if (albums.Count == 0)
            {
                return NotFound("Albums pour l'artiste non trouvés");
            }

            return Ok(albums);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

// POST: api/album/create
    [HttpPost("album/create")]
    public async Task<IActionResult> CreateAlbum([FromBody] Album album)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var band = await _context.Bands.FindAsync(album.BandId);
        if (band == null)
        {
            return NotFound($"Groupe avec l'ID {album.BandId} non trouvé.");
        }

        _context.Albums.Add(album);
        await _context.SaveChangesAsync();

        // Assurez-vous que cela correspond exactement au nom et aux paramètres de votre méthode GetAlbumById
        return CreatedAtAction(nameof(GetAlbumById), new { albumId = album.Id }, album);
    }

    // DELETE: api/albums
    [HttpDelete("album/{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album == null)
        {
            return NotFound();
        }

        _context.Albums.Remove(album);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
