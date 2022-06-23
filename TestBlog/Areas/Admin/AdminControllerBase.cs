using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TestBlog.Web.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class AdminControllerBase : Controller
    {
          
    }
}
