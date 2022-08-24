using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBucketList.Data;
using MyBucketList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MyBucketList.Controllers
{

    [Authorize]
    public class MyBucketListModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyBucketListModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyBucketListModels
        public async Task<IActionResult> Index(string bucketType)
        {
            //return _context.MyBucketListModel != null ? 
            //            View(await _context.MyBucketListModel.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.MyBucketListModel'  is null.");

            var CurrentUser = User.Identity.Name;

            //var searchBucket = "";

            //var myBucketListModels = _context.MyBucketListModel.Where(m => m.CreationEmail == CurrentUser);
            var myBucketListModels = GetBucketListByFilter(CurrentUser, bucketType);

            // var nr = new MyBucketListModels();
            // var myBucketListModels = _context.MyBucketListModel.ToList();
            var viewModels = new List<MyBucketListModels>();

            foreach (var nr in myBucketListModels)
            {
                var temp = new MyBucketListModels();

                temp.Id = nr.Id;
                temp.BucketType = nr.BucketType;
                temp.Title = nr.Title;
                temp.CreationDate = nr.CreationDate;
                temp.IWantIt = nr.IWantIt;
                temp.ToMakeiT = nr.ToMakeiT;
                temp.WhatSopped = nr.WhatSopped;
                temp.IWantWith = nr.IWantWith;
                temp.ItIsGonnaBe = nr.ItIsGonnaBe;
                temp.CreationEmail = nr.CreationEmail;
                temp.IsCompleted = nr.IsCompleted;

                //int bucketID;
                //Int32.TryParse(nr.BucketType, out bucketID);

#pragma warning disable CS8604 // Possible null reference argument.
                var bucket = (_context.Bucket.FirstOrDefault(c => c.Id == Int32.Parse(nr.BucketType)) as Bucket);
#pragma warning restore CS8604 // Possible null reference argument.
                if (bucket == null)
                {
                    temp.BucketType = "Invalid";
                }
                else
                {
                    temp.BucketType = bucket.Name;
                }


                temp.CreationEmail = nr.CreationEmail;

                viewModels.Add(temp);

            };




            return View(viewModels);
        }



        // GET: MyBucketListModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyBucketListModel == null)
            {
                return NotFound();
            }

            var myBucketListModel = await _context.MyBucketListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myBucketListModel == null)
            {
                return NotFound();
            }
            string bucketTypeName;
            var bucket = (_context.Bucket.FirstOrDefault(c => c.Id == Int32.Parse(myBucketListModel.BucketType)) as Bucket);
#pragma warning restore CS8604 // Possible null reference argument.
            if (bucket == null)
            {
                bucketTypeName = "Invalid";
            }
            else
            {
                bucketTypeName = bucket.Name;
            }
            ViewBag.BucketTypeName = bucketTypeName;

            //ViewBag.BucketsSelectList = new SelectList(GetBucketTypes(), "Id", "Name");
            return View(myBucketListModel);
        }

        // GET: MyBucketListModels/Create
        public IActionResult Create(string bucketType)
        {
            var CurrentUser = User.Identity.Name;

#pragma warning disable CS8604 // Possible null reference argument.
            var myBucketListModels = GetBucketListByFilter(CurrentUser, bucketType);
#pragma warning restore CS8604 // Possible null reference argument.
            ViewBag.BucketsSelectList = new SelectList(GetBucketTypes(), "Id", "Name");

            return View();
        }

        // POST: MyBucketListModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BucketType,CreationDate,Title,IWantIt,ToMakeiT,WhatSopped,IWantWith,ItIsGonnaBe")] MyBucketListModels myBucketListModel)
        {
            if (ModelState.IsValid)


            {
                myBucketListModel.CreationDate = DateTime.Now;
                myBucketListModel.CreationEmail = User.Identity.Name;
                _context.Add(myBucketListModel);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Your bucket list has been successfully created";
                return RedirectToAction("Index", "Home");
            }

            return View(myBucketListModel);
        }

        // GET: MyBucketListModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null || _context.MyBucketListModel == null)
            {
                return NotFound();
            }

            var myBucketListModel = await _context.MyBucketListModel.FindAsync(id);
            if (myBucketListModel == null)
            {
                return NotFound();
            }

            ViewBag.BucketsSelectList = new SelectList(GetBucketTypes(), "Id", "Name");
            return View(myBucketListModel);
        }

        // POST: MyBucketListModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BucketType,Title,CreationDate,CreationEmail,IWantIt,ToMakeiT,WhatSopped,IWantWith,ItIsGonnaBe,IsCompleted")] MyBucketListModels myBucketListModel)
        {
            if (id != myBucketListModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myBucketListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyBucketListModelExists(myBucketListModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }


                }
                TempData["Message"] = "Your bucket list has been successfully updated";
                return RedirectToAction(nameof(Index), new { bucketType = myBucketListModel.BucketType });

            }
            return View(myBucketListModel);
        }

        // GET: MyBucketListModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyBucketListModel == null)
            {
                return NotFound();
            }

            var myBucketListModel = await _context.MyBucketListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myBucketListModel == null)
            {
                return NotFound();
            }

            string bucketTypeName;
            var bucket = (_context.Bucket.FirstOrDefault(c => c.Id == Int32.Parse(myBucketListModel.BucketType)) as Bucket);


            if (bucket == null)
            {
                bucketTypeName = "Invalid";
            }
            else
            {
                bucketTypeName = bucket.Name;
            }
            ViewBag.BucketTypeName = bucketTypeName;


            //ViewBag.BucketsSelectList = new SelectList(GetBucketTypes(), "Id", "Name");

            return View(myBucketListModel);
        }

        // POST: MyBucketListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyBucketListModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MyBucketListModel'  is null.");
            }
            var myBucketListModel = await _context.MyBucketListModel.FindAsync(id);
            if (myBucketListModel != null)
            {
                _context.MyBucketListModel.Remove(myBucketListModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { bucketType = myBucketListModel.BucketType });
        }

        // GET: MyBucketListModels/Edit/5
        public async Task<IActionResult> CreateReview(int? id)
        {


            if (id == null || _context.MyBucketListModel == null)
            {
                return NotFound();
            }

            var myBucketListModel = await _context.MyBucketListModel.FindAsync(id);
            if (myBucketListModel == null)
            {
                return NotFound();
            }


            return View(myBucketListModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(int id, [Bind("Id,BucketType,Title,CreationDate,CreationEmail,IWantIt,ToMakeiT,WhatSopped,IWantWith,ItIsGonnaBe,IsCompleted,WhenAfter,WhereAfter,WithAfter,HowAfter,IlearnedAfter,ItMadeMeFeelAfter,WouldIDoItAfter,TheBestPartAfter")] MyBucketListModels bucketReview)
        {
            if (id != bucketReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(bucketReview);
                await _context.SaveChangesAsync();


                TempData["Message"] = "Your bucket list has been successfully updated";
                return RedirectToAction(nameof(Index), new { bucketType = bucketReview.BucketType });
            }
            return View(bucketReview);
        }


       

        private bool MyBucketListModelExists(int id)
        {
            return (_context.MyBucketListModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public List<Bucket> GetBucketTypes()
        {

            var categories = _context.Bucket.ToList();

            return categories;
        }

        public List<MyBucketListModels> GetBucketListByFilter(string user, string bucketType)
        {
            var myBucketListModels = _context.MyBucketListModel.Where(m => m.CreationEmail == user).Where(m => m.BucketType == bucketType).ToList();
            //var bucketLists = _context.BucketType.ToList();

            return myBucketListModels;
        }


    }
}
