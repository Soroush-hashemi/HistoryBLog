using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBlog.Services.DTOs.Posts;

namespace TestBlog.Services.DTOs.MainPage
{
    public class MainPageDto
    {
        public List<PostDto> LatestPosts { get; set; }
        public List<PostDto>  SpecialPosts { get; set; }
        public List<MainPageCategoryDto> Categories { get; set; }
    }
}
