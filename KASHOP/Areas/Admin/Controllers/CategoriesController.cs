using KASHOP.Data;
using KASHOP.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Store(Category request)
        {
            if (ModelState.IsValid) {
                var category = context.categories.Add(request);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("create" ,request);
            
        }

        public IActionResult Edit(int id)
        {
            var category = context.categories.Find(id);

            return View(category);
        }

        public IActionResult Update (Category request)
        {
            if (ModelState.IsValid)
            {
                context.categories.Update(request);
                context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            return View("Edit",request);
        }
        public IActionResult Remove(int id) 
        {
            var category = context.categories.Find(id);
            context.categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
