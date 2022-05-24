using System.ComponentModel.DataAnnotations;
using TestBlog.Services.DTOs.Categories;

namespace TestBlog.Web.Areas.Admin.Models.Categories
{
    public class CreateCategoryViewModel
    {
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "وارد کردن slug اجباری است")]
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public string MetaTag { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string MetaDescription { get; set; }

        public CreateCategoryDto MapToDto()
        {
            return new CreateCategoryDto()
            {
                Title = Title,
                MetaDescription = MetaDescription,
                Slug = Slug,
                ParentId = ParentId,
                MetaTag = MetaTag
            };
        }
    }
}
