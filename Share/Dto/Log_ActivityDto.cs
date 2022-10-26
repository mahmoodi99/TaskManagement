

namespace Share.Dto
{
    public class Log_ActivityDto
    {
        public Guid Id { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime DateTime { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? UserID { get; set; }      
    }
}
