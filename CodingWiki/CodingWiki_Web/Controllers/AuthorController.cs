using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Author> authors = _db.Authors;
            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {
            Author author = new();
            if (id == null || id == 0)
            {
                // create request
                return View(author);
            }
            else
            {
                // edit request
                author = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
                if (author == null)
                {
                    return NotFound();
                }
                return View(author);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.Author_Id == 0)
                {
                    // create
                    await _db.Authors.AddAsync(author);
                }
                else
                {
                    // update
                    _db.Authors.Update(author);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Author author = new();
            author = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (author == null)
            {
                return NotFound();
            }

            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
