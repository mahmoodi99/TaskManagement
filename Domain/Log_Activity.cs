

namespace Domain
{
    public class Log_Activity
    {
        public Guid Id { get; set; }
        public Guid ActivityId{ get; set; }
        public DateTime DateTime { get; set; }
        public Guid StatusId { get; set; }
        public Guid UserID { get; set; }

        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual Activity Activity { get; set; }

    }
}
