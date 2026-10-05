using System.ComponentModel.DataAnnotations;

namespace PcClubApi.Models;

public class ComputerStatus
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<Computer> Computers { get; set; } = new();
}