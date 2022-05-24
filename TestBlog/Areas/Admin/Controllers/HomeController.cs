using Microsoft.AspNetCore.Mvc;

namespace TestBlog.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
