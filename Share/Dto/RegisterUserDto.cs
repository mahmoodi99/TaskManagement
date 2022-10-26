using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Dto
{
    public class RegisterUserDto
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
    }
}
