using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class Log_ActivityGetDto
    {
        public Guid Id { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime DateTime { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? UserId { get; set; }
        public string UserFullName { get; set; }
        public string ActivityTitle { get; set; }
        public string StatusTitle { get; set; }
    }
}
