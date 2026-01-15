namespace upserver.DTO
{
    public class GroupsDto
    {
        public string GroupName { get; set; }
        public int Course {  get; set; }

        public List<SpecialtyDto> Specialties = new();
    }
}
