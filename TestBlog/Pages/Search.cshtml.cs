using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestBlog.Services.DTOs.Posts;
using TestBlog.Services.Services.Posts;

namespace TestBlog.Web.Pages
{
    public class SearchModel : PageModel
    {
        private IPostService _postService;
        public SearchModel(IPostService postService)
        {
            _postService = postService;
        }
        public PostFilterDto Filter { get; set; }
        public void OnGet()
        {

        }
    }
}
