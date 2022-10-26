

using System.ComponentModel.DataAnnotations;

namespace Share.Dto
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Title { get; set; }
    }
}
