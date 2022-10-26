

namespace Domain
{
    public   class Unit
    {
        public Guid Id { get; set; }
        public string  title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
    }
}
