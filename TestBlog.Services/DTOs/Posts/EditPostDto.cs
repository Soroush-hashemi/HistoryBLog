using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlog.Services.DTOs.Posts
{
    public class EditPostDto
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsSpecial { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
