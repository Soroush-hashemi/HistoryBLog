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
        public void OnGet(int pageId = 1, string categorySlug = null, string q = null)
        {
            Filter = _postService.GetPostsByFilter(new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageId = pageId,
                Take = 1,
                Title = q
            });
        }

        public IActionResult OnGetPagination(int pageId = 1, string categorySlug = null, string q = null)
        {
            var Model = _postService.GetPostsByFilter(new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageId = pageId,
                Take = 1,
                Title = q
            });
            return Partial("_SearchView", Model);
        }
    }
}
