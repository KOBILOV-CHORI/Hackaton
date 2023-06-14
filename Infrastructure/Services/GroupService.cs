using Domain.Dtos.Group;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }

    public GroupBase AddGroup(GroupBase group)
    {
        group.CreatedAt = DateTime.SpecifyKind(group.CreatedAt, DateTimeKind.Utc);
        var result = new Group()
        {
            Id = group.Id,
            GroupNick = group.GroupNick,
            ChallangeId = group.ChallangeId,
            NeededMember = group.NeededMember,
            CreatedAt = group.CreatedAt,
            TeamSlogan = group.TeamSlogan
        };
        _context.Groups.Add(result);
        _context.SaveChanges();
        return group;
    }

    public GroupBase UpdateGroup(GroupBase group)
    {
        group.CreatedAt = DateTime.SpecifyKind(group.CreatedAt, DateTimeKind.Utc);
        var find = _context.Groups.Find(group.Id);
        find.GroupNick = group.GroupNick;
        find.ChallangeId = group.ChallangeId;
        find.NeededMember = group.NeededMember;
        find.CreatedAt = group.CreatedAt;
        find.TeamSlogan = group.TeamSlogan;
        _context.SaveChanges();
        return group;
    }

    public bool DeleteGroup(int id)
        {
            var find = _context.Groups.Find(id);
            if (find != null)
            {
                _context.Groups.Remove(find);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public GroupBase GetGroupById(int id)
        {
            var find = _context.Groups.Find(id);
            if (find != null)
            {
                return new GroupBase()
                {
                    Id = find.Id,
                    GroupNick = find.GroupNick,
                    ChallangeId = find.ChallangeId,
                    NeededMember = find.NeededMember,
                    TeamSlogan = find.TeamSlogan,
                    CreatedAt = find.CreatedAt
                };
            }

            return new GroupBase();
        }

        public List<GroupBase> GetGroups()
        {
            return _context.Groups.Select(g => new GroupBase()
            {
                Id = g.Id,
                GroupNick = g.GroupNick,
                ChallangeId = g.ChallangeId,
                NeededMember = g.NeededMember,
                TeamSlogan = g.TeamSlogan,
                CreatedAt = g.CreatedAt
            }).ToList();
        }
    }