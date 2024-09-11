using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MusicApi.Controllers;

[ApiController]
[Route("api")]
public class MembersController : ControllerBase
{
    private readonly MusicDbContext _context;

    public MembersController(MusicDbContext context)
    {
        _context = context;
    }

    // GET: api/Members
    [HttpGet("members")]
    public async Task<IActionResult> GetAllMembers()
    {
        var members = await _context.Members
            .Include(m => m.BandMembers)
            .ThenInclude(bm => bm.Band)
            .ToListAsync();
        return Ok(members);
    }
}