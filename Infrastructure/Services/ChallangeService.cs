using Domain.Dtos.Challange;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class ChallangeService
{
    private readonly DataContext _context;

    public ChallangeService(DataContext context)
    {
        _context = context;
    }

    public ChallangeBase AddChallange(ChallangeBase challenge)
    {
        var result = new Challange(){Id = challenge.Id,Title = challenge.Title, Description = challenge.Description};
        _context.Challanges.Add(result);
        _context.SaveChanges();
        return challenge;
    }

    public ChallangeBase UpdateChallange(ChallangeBase challenge)
    {
        var find = _context.Challanges.Find(challenge.Id);
        if (find != null)
        {
            find.Title = challenge.Title;
            find.Description = challenge.Description;
            _context.SaveChanges();
            return challenge;
        }

        return challenge;
    }

    public bool DeleteChallange(int id)
    {
        var find = _context.Challanges.Find(id);
        if (find != null)
        {
            _context.Challanges.Remove(find);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public ChallangeBase GetChallangeById(int id)
    {
        var find = _context.Challanges.Find(id);
        if (find != null)
        {
            return new ChallangeBase(){Title = find.Title, Description = find.Description};
        }
        return new ChallangeBase();
    }

    public List<ChallangeBase> GetChallanges()
    {
        return _context.Challanges.Select(c => new ChallangeBase()
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description
        }).ToList();
    }
}