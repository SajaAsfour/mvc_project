using KASHOP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            return View(categories);
        }
    }
}
