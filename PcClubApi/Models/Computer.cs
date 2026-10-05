using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcClubApi.Models;

public class Computer
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string? Specs { get; set; }

    public int ZoneId { get; set; }
    [ForeignKey("ZoneId")]
    public Zone? Zone { get; set; }

    public int StatusId { get; set; } = 1; 
    [ForeignKey("StatusId")]
    public ComputerStatus? Status { get; set; }
}