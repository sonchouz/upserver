namespace upserver.DTO
{
    public interface IGroupsService
    {
        Task<List<GroupsDto>> GetGroups();
    }
}
