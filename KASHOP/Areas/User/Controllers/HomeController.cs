using KASHOP.Data;
using KASHOP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        ApplicationDbContext context= new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.categories.Include(p => p.Products).ToList();
            var categoriesVm = new List<CategoriesViewModel>();
            foreach (var category in categories)
            {
                var vm = new CategoriesViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                categoriesVm.Add(vm);
            }
            return View(categoriesVm);
        }

        public IActionResult ByCategory(int id)
        {
            var products = context.products
                .Where(p => p.CategoryId == id)
                .Select(p => new ProductsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image
                })
                .ToList();

            ViewBag.CategoryName = context.categories
                .FirstOrDefault(c => c.Id == id)?.Name;

            return View(products);
        }
    }
}
