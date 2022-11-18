using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Issue_Tracker.Models;

namespace Issue_Tracker.Controllers
{
    public class TrackerModelsController : Controller
    {
        private readonly TrackerDbContext _context;

        public TrackerModelsController(TrackerDbContext context)
        {
            _context = context;
        }

        // GET: TrackerModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.ISSUE_TRACKER.ToListAsync());
        }

        // GET: TrackerModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ISSUE_TRACKER == null)
            {
                return NotFound();
            }

            var trackerModel = await _context.ISSUE_TRACKER
                .FirstOrDefaultAsync(m => m.Issue_ID == id);
            if (trackerModel == null)
            {
                return NotFound();
            }

            return View(trackerModel);
        }

        // GET: TrackerModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrackerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Issue_ID,RepoterID,RepoterName,Heading,Description,CreatedDate,AssignedToName")] TrackerModels trackerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trackerModel);
                await _context.SaveChangesAsync();
                return Json(new { IsValid = true, html = Healper.RenderRazorViewToString(this, "Index", _context.ISSUE_TRACKER.ToList()) });
            }
            return Json(new { IsValid = false, html = Healper.RenderRazorViewToString(this, "Create", trackerModel) });


        }

        // GET: TrackerModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ISSUE_TRACKER == null)
            {
                return NotFound();
            }

            var trackerModel = await _context.ISSUE_TRACKER.FindAsync(id);
            if (trackerModel == null)
            {
                return NotFound();
            }
            return View(trackerModel);
        }

        // POST: TrackerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Issue_ID,RepoterID,RepoterName,Heading,Description,CreatedDate,AssignedToName")] TrackerModels trackerModel)
        {
            if (id != trackerModel.Issue_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trackerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackerModelExists(trackerModel.Issue_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new {IsValid=true,html=Healper.RenderRazorViewToString(this,"Index",_context.ISSUE_TRACKER.ToList())});
            }
            return Json(new { IsValid = false, html = Healper.RenderRazorViewToString(this,"Edit",trackerModel) });
        }

        //// GET: TrackerModels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.ISSUE_TRACKER == null)
        //    {
        //        return NotFound();
        //    }

        //    var trackerModel = await _context.ISSUE_TRACKER
        //        .FirstOrDefaultAsync(m => m.Issue_ID == id);
        //    if (trackerModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(trackerModel);
        //}

        // POST: TrackerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ISSUE_TRACKER == null)
            {
                return Problem("Entity set 'TrackerDbContext.ISSUE_TRACKER'  is null.");
            }
            var trackerModel = await _context.ISSUE_TRACKER.FindAsync(id);
            if (trackerModel != null)
            {
                _context.ISSUE_TRACKER.Remove(trackerModel);
            }
            
            await _context.SaveChangesAsync();
            return Json(new {html = Healper.RenderRazorViewToString(this, "Index", _context.ISSUE_TRACKER.ToList()) });
        }

        private bool TrackerModelExists(int id)
        {
          return _context.ISSUE_TRACKER.Any(e => e.Issue_ID == id);
        }
    }
}
