using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Group
{
    public Group()
    {
        CreatedAt = DateTime.Now;
    }
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)] public string GroupNick { get; set; }
    public int ChallangeId { get; set; }
    public Challange Challange { get; set; }
    public bool NeededMember { get; set; }
    [Required, MaxLength(100)] 
    public string TeamSlogan { get; set; } 
    public DateTime CreatedAt { get; set; }
    public List<Participant> Participants { get; set; }
}