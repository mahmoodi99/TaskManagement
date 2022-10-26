


using System.Diagnostics;

namespace Domain
{
  public   class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string NationalCode { get; set; }
        public  string Mobile { get; set; }
        public  string UserName { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<Log_Activity> Logs { get; set; }

    }
}
