using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcClubApi.Models;

public class Booking
{
    [Key]
    public int Id { get; set; }

    public int ComputerId { get; set; }
    [ForeignKey("ComputerId")]
    public Computer? Computer { get; set; }

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required]
    public string BookingDate { get; set; } = string.Empty; // Например, "2026-10-28"
    
    [Required]
    public string BookingTime { get; set; } = string.Empty; // Например, "18:00"
}