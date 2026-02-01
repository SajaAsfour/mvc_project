using KASHOP.Data;
using KASHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.categories = context.categories.ToList();
            return View(new Product() { });
        }

        public IActionResult Store(Product request , IFormFile Image) 
        {
            return Content("ok");
        }
    }
}
