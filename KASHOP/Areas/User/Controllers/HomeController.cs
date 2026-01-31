using KASHOP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        ApplicationDbContext context= new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            return View(categories);
        }
    }
}
