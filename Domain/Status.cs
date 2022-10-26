

namespace Domain
{
    public class Status
    {
        public Guid Id { get; set; }       
        public string Title { get; set; }

      
         public virtual ICollection<Activity> Activities { get; set; }
         public virtual ICollection<Log_Activity> Logs { get; set; }
    }
}
