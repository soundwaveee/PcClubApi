using System.ComponentModel.DataAnnotations;

namespace PcClubApi.Models;

public class Zone
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal PricePerHour { get; set; }
    public bool IsVip { get; set; }
    
    public List<Computer> Computers { get; set; } = new();
}