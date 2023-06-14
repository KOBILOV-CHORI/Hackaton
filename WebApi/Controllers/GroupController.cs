using Domain.Dtos.Group;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost("add-group")]
    public GroupBase AddGroup([FromForm]GroupBase group)
    {
        return _groupService.AddGroup(group);
    }

    [HttpPut("update-group")]
    public GroupBase UpdateGroup([FromForm]GroupBase group)
    {
        return _groupService.UpdateGroup(group);
    }

    [HttpDelete("remove-group")]
    public bool RemoveGroup(int id)
    {
        return _groupService.DeleteGroup(id);
    }

    [HttpGet("get-by-id")]
    public GroupBase GetById(int id)
    {
        return _groupService.GetGroupById(id);
    }

    [HttpGet("get-group")]
    public List<GroupBase> GetGroups()
    {
        return _groupService.GetGroups();
    }
}