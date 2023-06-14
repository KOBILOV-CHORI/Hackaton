using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Challange
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Title { get; set; }
    [Required, MaxLength(200)]
    public string Description { get; set; }

    public List<Group> Groups { get; set; }
}