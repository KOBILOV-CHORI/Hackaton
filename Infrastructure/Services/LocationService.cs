using Domain.Dtos.Location;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }

    public LocationBase AddLocation(LocationBase location)
    {
        var result = new Location()
        {
            Id = location.Id,
            Name = location.Name,
            Description = location.Description
        };
        _context.Locations.Add(result);
        _context.SaveChanges();
        return location;
    }

    public LocationBase UpdateLocation(LocationBase location)
    {
        var find = _context.Locations.Find(location.Id);

        find.Name = location.Name;
        find.Description = location.Description;
        _context.SaveChanges();
        return location;
    }

    public bool DeleteLocation(int id)
    {
        var find = _context.Locations.Find(id);
        if (find != null)
        {
            _context.Locations.Remove(find);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public LocationBase GetLocationById(int id)
    {
        var find = _context.Locations.Find(id);
        if (find != null)
        {
            return new LocationBase()
            {
                Id = find.Id,
                Name = find.Name,
                Description = find.Description
            };
        }

        return new LocationBase();
    }

    public List<LocationBase> GetLocations()
    {
        return _context.Locations.Select(l => new LocationBase()
        {
            Id = l.Id,
            Name = l.Name,
            Description = l.Description
        }).ToList();
    }
}