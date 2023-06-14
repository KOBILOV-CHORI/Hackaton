using Domain.Dtos.Participant;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly ParticipantService _participantService;

    public ParticipantController(ParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpPost("add-participant")]
    public ParticipantBase AddParticipant([FromForm]ParticipantBase participant)
    {
        return _participantService.AddParticipant(participant);
    }

    [HttpPut("update-participant")]
    public ParticipantBase UpdateParticipant([FromForm]ParticipantBase participant)
    {
        return _participantService.UpdateParticipant(participant);
    }

    [HttpDelete("remove-participant")]
    public bool RemoveParticipant(int id)
    {
        return _participantService.DeleteParticipant(id);
    }

    [HttpGet("get-by-id")]
    public ParticipantBase GetById(int id)
    {
        return _participantService.GetParticipantById(id);
    }

    [HttpGet("get-challenges")]
    public List<ParticipantBase> GetParticipants()
    {
        return _participantService.GetParticipants();
    }
}