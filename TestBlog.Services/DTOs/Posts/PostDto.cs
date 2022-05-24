using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlog.Services.DTOs.Categories;

namespace TestBlog.Services.DTOs.Posts
{
    public class PostDto
    {
        public readonly IFormFile ImageFile;
        public int PostId { get; set; }
        public string UserFullName { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        public DateTime CreationDate { get; set; }
        public CategoryDto Category { get; set; }
        public CategoryDto SubCategory { get; set; }
    }
}
