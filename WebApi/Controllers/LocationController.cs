using Domain.Dtos.Location;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpPost("add-location")]
    public LocationBase AddLocation([FromForm]LocationBase location)
    {
        return _locationService.AddLocation(location);
    }

    [HttpPut("update-location")]
    public LocationBase UpdateLocation([FromForm]LocationBase location)
    {
        return _locationService.UpdateLocation(location);
    }

    [HttpDelete("remove-location")]
    public bool RemoveLocation(int id)
    {
        return _locationService.DeleteLocation(id);
    }

    [HttpGet("get-by-id")]
    public LocationBase GetById(int id)
    {
        return _locationService.GetLocationById(id);
    }

    [HttpGet("get-group")]
    public List<LocationBase> GetLocations()
    {
        return _locationService.GetLocations();
    }
}