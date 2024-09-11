using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MusicApi.Controllers;

[ApiController]
[Route("api")]
public class CountriesController : Controller
{
    private readonly MusicDbContext _context;

    public CountriesController(MusicDbContext context)
    {
        _context = context;
    }

    // GET: api/countries
    [HttpGet("countries")]
    public async Task<IActionResult> GetAllCountries()
    {
        var countries = await _context.Countries.ToListAsync();
        return Ok(countries);
    }

}