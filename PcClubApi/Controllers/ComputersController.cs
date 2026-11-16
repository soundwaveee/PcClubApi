using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcClubApi.Data;
using PcClubApi.Models;

namespace PcClubApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputersController : ControllerBase
{
    private readonly AppDbContext _context;

    public ComputersController(AppDbContext context)
    {
        _context = context;
    }

    public class BookRequest
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
    }

    [HttpPost("{id}/book")]
    public async Task<IActionResult> BookComputer(int id, [FromBody] BookRequest request)
    {
        var computer = await _context.Computers.FindAsync(id);
        
        if (computer == null) 
            return NotFound(new { message = "Компьютер не найден" });

        if (computer.StatusId != 1) 
            return BadRequest(new { message = "Компьютер уже занят или сломан" });

        if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.Date) || string.IsNullOrWhiteSpace(request.Time))
            return BadRequest(new { message = "Заполните все данные для бронирования" });

        // --- ПРОВЕРКА ДАТЫ ---
        if (!DateTime.TryParse(request.Date, out DateTime bookingDate))
            return BadRequest(new { message = "Неверный формат даты" });

        var today = DateTime.Today;
        var maxDate = today.AddDays(7); 

        if (bookingDate < today)
            return BadRequest(new { message = "Нельзя бронировать на прошедшую дату" });

        if (bookingDate > maxDate)
            return BadRequest(new { message = "Бронирование доступно только на 7 дней вперед" });
        // ---------------------

        computer.StatusId = 2;

        var booking = new Booking
        {
            ComputerId = id,
            PhoneNumber = request.PhoneNumber,
            BookingDate = request.Date,
            BookingTime = request.Time
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Успешно забронировано!" });
    }
}