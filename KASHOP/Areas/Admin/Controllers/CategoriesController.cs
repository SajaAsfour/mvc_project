using KASHOP.Data;
using KASHOP.Models;
using KASHOP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
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

        public IActionResult Create()
        {
            return View(new CategoriesViewModel());
        }


        public IActionResult Store(CategoriesViewModel request)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = request.Name
                };

                context.categories.Add(category);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View("Create", request);
        }


        public IActionResult Edit(int id)
        {
            var category = context.categories.Find(id);

            var vm = new CategoriesViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(vm);
        }


        public IActionResult Update(CategoriesViewModel request)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Id = request.Id,
                    Name = request.Name
                };

                context.categories.Update(category);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View("Edit", request);
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
