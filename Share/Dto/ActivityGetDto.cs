

using System.ComponentModel.DataAnnotations;

namespace Share.Dto
{
    public class ActivityGetDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Title { get; set; }

        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string Description { get; set; }

        [Required(ErrorMessage = "یک پروژه را وارد کنید")]
        public Guid? UnitId { get; set; }

        [Required(ErrorMessage = "یک وضعیت را وارد کنید")]
        public Guid? StatusId { get; set; }

        [Required(ErrorMessage = "یک کاربر را وارد کنید")]
        public Guid? UserId { get; set; }
        public string StatusTitle { get; set; }
        public string UserFullName { get; set; }
        public string UnitTitle { get; set; }
    }
}
