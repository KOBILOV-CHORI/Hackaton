using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Location
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required, MaxLength(200)]
    public string Description { get; set; }

    public List<Participant> Participants { get; set; }
}