

namespace Domain
{
    public class Activity
    {     
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; }
        public Guid UserId { get; set; }
        public Guid UnitId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Log_Activity> log { get; set; }
    }
}
