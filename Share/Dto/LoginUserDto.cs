

using System.ComponentModel.DataAnnotations;

namespace Share.Dto
{
    public class LoginUserDto
    {
        [Required]
        public string Mobile { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
