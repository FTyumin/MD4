using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MD4.Data;
using MD4.Models;
using Microsoft.AspNetCore.Authorization;

namespace MD4.Controllers
{
    // Tikai registretie lietotaji var rediget iesniegumus
    [Authorize]
    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Submissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Submissions.Include(s => s.Assignment).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Submissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);



            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // GET: Submissions/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            ViewBag.AssignmentId = _context.Assignments.Select(a => new SelectListItem
            {
                Text = a.Description,
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.StudentId = _context.Students.Select(s => new SelectListItem
            {
                Text = s.Name + " " + s.Surname,
                Value = s.Id.ToString()
            }).ToList();

            return View();
        }

        // POST: Submissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssignmentId,StudentId,SubmissionTime,Score")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id", submission.AssignmentId);
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", submission.StudentId);
            ViewBag.AssignmentId = _context.Assignments.Select(a => new SelectListItem
            {
                Text = a.Description,
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.StudentId = _context.Students.Select(s => new SelectListItem
            {
                Text = s.Name + " " + s.Surname,
                Value = s.Id.ToString()
            }).ToList();
            return View(submission);
        }

        // GET: Submissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            //ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id", submission.AssignmentId);
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", submission.StudentId);
            ViewBag.AssignmentId = _context.Assignments.Select(a => new SelectListItem
            {
                Text = a.Description,
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.StudentId = _context.Students.Select(s => new SelectListItem
            {
                Text = s.Name + " " + s.Surname,
                Value = s.Id.ToString()
            }).ToList();
            return View(submission);
        }

        // POST: Submissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignmentId,StudentId,SubmissionTime,Score")] Submission submission)
        {
            if (id != submission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionExists(submission.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.AssignmentId = _context.Assignments.Select(a => new SelectListItem
                {
                    Text = a.Description,
                    Value = a.Id.ToString()
                }).ToList();

                ViewBag.StudentId = _context.Students.Select(s => new SelectListItem
                {
                    Text = s.Name + " " + s.Surname,
                    Value = s.Id.ToString()
                }).ToList();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id", submission.AssignmentId);
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", submission.StudentId);
            return View(submission);
        }

        // GET: Submissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            if (submission != null)
            {
                _context.Submissions.Remove(submission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmissionExists(int id)
        {
            return _context.Submissions.Any(e => e.Id == id);
        }
    }
}
