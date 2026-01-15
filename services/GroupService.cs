using Microsoft.EntityFrameworkCore;
using upserver.Data;
using upserver.DTO;
using upserver.Models;

namespace upserver.services
{
    public class GroupsService : IGroupsService
    {
        private readonly AppDbContext _db;

        public GroupsService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<GroupsDto>> GetGroups()
        {
          
            var groups = await LoadGroups();

            return BuildGroupListDto(groups);
        }

        private async Task<List<StudentGroup>> LoadGroups()
        {
            {
                return await _db.StudentGroups.Include(s => s.Specialty).ToListAsync();
            }
        }
     

        private List<GroupsDto> BuildGroupListDto(List<StudentGroup> groups)
        {
            if (groups == null || groups.Count == 0)
                return new List<GroupsDto>();

            var allgroups = groups
                .GroupBy(s => s.GroupName)
                .OrderBy(g => g.Key)
                .Select(g => BuildGroupDto(g.ToList()))
                .ToList();

            return allgroups;

        }

        private static GroupsDto BuildGroupDto(List<StudentGroup> groups)
        {
            var specialties = groups
            .Select(s => s.Specialty.Name)
            .Select(name => new SpecialtyDto { SpecialtyName = name })
            .ToList();


            return new GroupsDto
            {
              GroupName = groups.First().GroupName,
              Course = groups.First().Course,
              Specialties = specialties

            };
        }
    }
}
