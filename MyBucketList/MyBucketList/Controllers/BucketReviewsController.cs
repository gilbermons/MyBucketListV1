using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBucketList.Data;

namespace MyBucketList.Controllers
{
    public class BucketReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BucketReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BucketReviews
        public async Task<IActionResult> Index()
        {
              return _context.BucketReview != null ? 
                          View(await _context.BucketReview.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BucketReview'  is null.");
        }

        // GET: BucketReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BucketReview == null)
            {
                return NotFound();
            }

            var bucketReview = await _context.BucketReview
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucketReview == null)
            {
                return NotFound();
            }

            return View(bucketReview);
        }

        // GET: BucketReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BucketReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,Where,With,How,Ilearned,ItMadeMeFeel,WouldIDoIt,TheBestPart")] BucketReview bucketReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucketReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bucketReview);
        }

        // GET: BucketReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BucketReview == null)
            {
                return NotFound();
            }

            var bucketReview = await _context.BucketReview.FindAsync(id);
            if (bucketReview == null)
            {
                return NotFound();
            }
            return View(bucketReview);
        }

        // POST: BucketReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,When,Where,With,How,Ilearned,ItMadeMeFeel,WouldIDoIt,TheBestPart")] BucketReview bucketReview)
        {
            if (id != bucketReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bucketReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BucketReviewExists(bucketReview.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bucketReview);
        }

        // GET: BucketReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BucketReview == null)
            {
                return NotFound();
            }

            var bucketReview = await _context.BucketReview
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucketReview == null)
            {
                return NotFound();
            }

            return View(bucketReview);
        }

        // POST: BucketReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BucketReview == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BucketReview'  is null.");
            }
            var bucketReview = await _context.BucketReview.FindAsync(id);
            if (bucketReview != null)
            {
                _context.BucketReview.Remove(bucketReview);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BucketReviewExists(int id)
        {
          return (_context.BucketReview?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
