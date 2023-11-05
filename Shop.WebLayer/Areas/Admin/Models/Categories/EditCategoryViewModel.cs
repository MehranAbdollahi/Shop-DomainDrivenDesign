using System.ComponentModel.DataAnnotations;

namespace Shop.WebLayer.Areas.Admin.Models.Categories
{
    public class EditCategoryViewModel
    {
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = null!;


    }
}