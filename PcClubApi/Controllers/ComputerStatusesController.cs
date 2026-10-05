using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcClubApi.Data;
using PcClubApi.Models;

namespace PcClubApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputerStatusesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ComputerStatusesController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ComputerStatus>>> GetComputerStatuses()
    {
        return await _context.ComputerStatuses.ToListAsync();
    }


    [HttpPost]
    public async Task<ActionResult<ComputerStatus>> CreateComputerStatus(ComputerStatus status)
    {
        _context.ComputerStatuses.Add(status);
        await _context.SaveChangesAsync();
        return Ok(status);
    }
}