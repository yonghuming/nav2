using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nav.Data;
using nav.Models;

namespace nav.Controllers
{
    public class AspNetUrlsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AspNetUrlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AspNetUrls
        public async Task<IActionResult> Index()
        {
            return View(await _context.AspNetUrls.ToListAsync());
        }

        // GET: AspNetUrls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUrls = await _context.AspNetUrls
                .SingleOrDefaultAsync(m => m.Id == id);
            if (aspNetUrls == null)
            {
                return NotFound();
            }

            return View(aspNetUrls);
        }

        // GET: AspNetUrls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetUrls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HpyerUrl,HpyerText,HpyerCatalog")] AspNetUrls aspNetUrls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUrls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUrls);
        }

        // GET: AspNetUrls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUrls = await _context.AspNetUrls.SingleOrDefaultAsync(m => m.Id == id);
            if (aspNetUrls == null)
            {
                return NotFound();
            }
            return View(aspNetUrls);
        }

        // POST: AspNetUrls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HpyerUrl,HpyerText,HpyerCatalog")] AspNetUrls aspNetUrls)
        {
            if (id != aspNetUrls.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUrls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUrlsExists(aspNetUrls.Id))
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
            return View(aspNetUrls);
        }

        // GET: AspNetUrls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUrls = await _context.AspNetUrls
                .SingleOrDefaultAsync(m => m.Id == id);
            if (aspNetUrls == null)
            {
                return NotFound();
            }

            return View(aspNetUrls);
        }

        // POST: AspNetUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspNetUrls = await _context.AspNetUrls.SingleOrDefaultAsync(m => m.Id == id);
            _context.AspNetUrls.Remove(aspNetUrls);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUrlsExists(int id)
        {
            return _context.AspNetUrls.Any(e => e.Id == id);
        }
    }
}
