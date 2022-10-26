
using System.ComponentModel.DataAnnotations;

namespace Share.Dto
{
    public class UnitDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string Title { get; set; }

        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string Description { get; set; }
    }
}
