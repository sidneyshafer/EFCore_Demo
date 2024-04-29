using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new();
            if (id == null || id == 0)
            {
                // create request
                return View(category);
            }
            else
            {
                // edit request
                category = _db.Categories.FirstOrDefault(u => u.Category_Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Category_Id == 0)
                {
                    // create
                    await _db.Categories.AddAsync(category);
                }
                else
                {
                    // update
                    _db.Categories.Update(category);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Category category = new();
            category = _db.Categories.FirstOrDefault(u => u.Category_Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            List<Category> categories = new();
            for (int i = 1; i <= 2; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            await _db.Categories.AddRangeAsync(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            List<Category> categories = new();
            for (int i = 1; i <= 5; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            await _db.Categories.AddRangeAsync(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            List<Category> categories = _db.Categories
                .OrderByDescending(u => u.Category_Id)
                .Take(2)
                .ToList();

            _db.Categories.RemoveRange(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            List<Category> categories = _db.Categories
                .OrderByDescending(u => u.Category_Id)
                .Take(5)
                .ToList();

            _db.Categories.RemoveRange(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
