using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcClubApi.Data;
using PcClubApi.Models;

namespace PcClubApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ZonesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ZonesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Zone>>> GetZones()
    {
        return await _context.Zones.Include(z => z.Computers).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Zone>> CreateZone(Zone zone)
    {
        _context.Zones.Add(zone);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetZones), new { id = zone.Id }, zone);
    }
}