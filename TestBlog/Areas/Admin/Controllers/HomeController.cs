using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestBlog.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        [Authorize]
        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
