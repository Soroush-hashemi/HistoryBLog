using System.ComponentModel.DataAnnotations;

namespace TestBlog.Web.Areas.Admin.Models.Categories
{
    public class EditCategoryViewModel
    {
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "وارد کردن slug اجباری است")]
        public string Slug { get; set; }
        [Display(Name = "MetaTag")]
        public string MetaTag { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string MetaDescription { get; set; }

    }
}
