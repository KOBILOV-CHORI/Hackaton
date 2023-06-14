using Domain.Dtos.Participant;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class ParticipantService
{
    private readonly DataContext _context;

    public ParticipantService(DataContext context)
    {
        _context = context;
    }

    public ParticipantBase AddParticipant(ParticipantBase participant)
    {
        participant.CreatedAt = DateTime.SpecifyKind(participant.CreatedAt, DateTimeKind.Utc);
        var result = new Participant()
        {
            Id = participant.Id,
            Email = participant.Email,
            FullName = participant.FullName,
            Password = participant.Password,
            LocationId = participant.LocationId,
            CreatedAt = participant.CreatedAt,
            GroupId = participant.GroupId,
            Phone = participant.Phone
        };
        _context.Participants.Add(result);
        _context.SaveChanges();
        return participant;
    }

    public ParticipantBase UpdateParticipant(ParticipantBase participant)
    {
        participant.CreatedAt = DateTime.SpecifyKind(participant.CreatedAt, DateTimeKind.Utc);
        var find = _context.Participants.Find(participant.Id);
        find.FullName = participant.FullName;
        find.Email = participant.Email;
        find.Phone = participant.Phone;
        find.Password = participant.Password;
        find.GroupId = participant.GroupId;
        find.LocationId = participant.LocationId;
        _context.SaveChanges();
        return participant;
    }

    public bool DeleteParticipant(int id)
    {
        var find = _context.Participants.Find(id);
        if (find != null)
        {
            _context.Participants.Remove(find);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public ParticipantBase GetParticipantById(int id)
    {
        var find = _context.Participants.Find(id);
        if (find != null)
        {
            return new ParticipantBase()
            {
                Id = find.Id,
                Email = find.Email,
                FullName = find.FullName,
                Password = find.Password,
                LocationId = find.LocationId,
                CreatedAt = find.CreatedAt,
                GroupId = find.GroupId,
                Phone = find.Phone
            };
        }

        return new ParticipantBase();
    }

    public List<ParticipantBase> GetParticipants()
    {
        return _context.Participants.Select(p => new ParticipantBase()
        {
            Id = p.Id,
            Email = p.Email,
            FullName = p.FullName,
            Password = p.Password,
            LocationId = p.LocationId,
            CreatedAt = p.CreatedAt,
            GroupId = p.GroupId,
            Phone = p.Phone
        }).ToList();
    }
}