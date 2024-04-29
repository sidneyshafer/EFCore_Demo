using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Publisher> publishers = _db.Publishers;
            return View(publishers);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher publisher = new();
            if (id == null || id == 0)
            {
                // create request
                return View(publisher);
            }
            else
            {
                // edit request
                publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
                if (publisher == null)
                {
                    return NotFound();
                }
                return View(publisher);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if (publisher.Publisher_Id == 0)
                {
                    // create
                    await _db.Publishers.AddAsync(publisher);
                }
                else
                {
                    // update
                    _db.Publishers.Update(publisher);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Publisher publisher = new();
            publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (publisher == null)
            {
                return NotFound();
            }

            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
