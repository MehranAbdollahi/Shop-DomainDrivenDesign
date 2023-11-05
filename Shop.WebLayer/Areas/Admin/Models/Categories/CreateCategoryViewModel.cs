using System.ComponentModel.DataAnnotations;
using Shop.Application.Categories.DTOs;

namespace Shop.WebLayer.Areas.Admin.Models.Categories
{
    public class CreateCategoryViewModel
    {

        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = null!;
        public int? ParentId { get; set; }



        public AddCategoryDto MapToDto()
        {
            return new AddCategoryDto()
            {
                Title = Title,
                ParentId = ParentId,
            };
        }
    }
}