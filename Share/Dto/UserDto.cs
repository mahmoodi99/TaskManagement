

using System.ComponentModel.DataAnnotations;

namespace Share.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "کد ملی  را وارد کنید")]
        [StringLength(10)]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "شماره همراه  را وارد کنید")]
        [StringLength(11)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "یک نام کاربری وارد  کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "رمز ورود باید شامل حداقل 4 حرف باشد")]
        [MinLength(6)]
        public string Password { get; set; }
        public string? RoleTitle { get; set; }

        [Required(ErrorMessage = "یک سمت  وارد  کنید")]
        public Guid? RoleId { get; set; }
        public string? UserFullName { get; set; }


    }


}
