using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlog.Services.DTOs.MainPage
{
    public class MainPageCategoryDto
    {
        public int PostChild { get; set; }
        public bool IsMainCategory { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
    }
}
