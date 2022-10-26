

namespace Share.Dto
{
    public class ActivityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; }
        public Guid UserId { get; set; }
        public Guid UnitId { get; set; }
    }
}
