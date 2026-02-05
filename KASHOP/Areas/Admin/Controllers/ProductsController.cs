using KASHOP.Data;
using KASHOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var products = context.products.Include(p=>p.Category).ToList();
            
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.categories = context.categories.ToList();
            return View(new Product() { });
        }

        public IActionResult Store(Product request , IFormFile Image) 
        {
            if (Image != null && Image.Length > 0) 
            {
                var filename = Guid.NewGuid().ToString();
                filename += Path.GetExtension(Image.FileName);
                var filepath=Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images" ,filename);
                using (var stream = System.IO.File.Create(filepath)) 
                { 
                    Image.CopyTo(stream);
                }
                request.Image = filename;
                context.products.Add(request);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return Content("ok");
        }

        public IActionResult Edit(int id)
        {
            var product = context.products.Find(id);
            ViewBag.categories = context.categories.ToList();
            return View(product);
        }

        public IActionResult Update(Product request)
        {
            if (ModelState.IsValid)
            {
                context.products.Update(request);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.categories = context.categories.ToList();
            return View("Edit", request);
        }
        public IActionResult Remove(int id)
        {
            var product = context.products.Find(id);
            context.products.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
