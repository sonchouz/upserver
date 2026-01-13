namespace upserver.DTO
{
    public interface IScheduleService
    {
        Task<List<ScheduleByDateDto>> GetScheduleForGroup (string groupName, DateTime startDate,  DateTime endDate);
    }
}
