using Domain.Dtos.Challange;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChallangeController : ControllerBase
{
    private readonly ChallangeService _challangeService;

    public ChallangeController(ChallangeService challangeService)
    {
        _challangeService = challangeService;
    }

    [HttpPost("add-challange")]
    public ChallangeBase AddChallange([FromForm]ChallangeBase challange)
    {
        return _challangeService.AddChallange(challange);
    }

    [HttpPut("update-challange")]
    public ChallangeBase UpdateChallange([FromForm]ChallangeBase challange)
    {
        return _challangeService.UpdateChallange(challange);
    }

    [HttpDelete("remove-challange")]
    public bool RemoveChallange(int id)
    {
        return _challangeService.DeleteChallange(id);
    }

    [HttpGet("get-by-id")]
    public ChallangeBase GetById(int id)
    {
        return _challangeService.GetChallangeById(id);
    }

    [HttpGet("get-challenges")]
    public List<ChallangeBase> GetChallanges()
    {
        return _challangeService.GetChallanges();
    }
}