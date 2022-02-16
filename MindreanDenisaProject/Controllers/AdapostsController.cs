using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MindreanDenisaProject.Data;
using MindreanDenisaProject.Models;

namespace MindreanDenisaProject.Controllers
{
    
    public class AdapostsController : Controller
    {
        private readonly ShelterContext _context;

        public AdapostsController(ShelterContext context)
        {
            _context = context;
        }

        // GET: Adaposts
        public async Task<IActionResult> Index()
        {
            var shelterContext = _context.Adaposturi.Include(a => a.Oras);
            return View(await shelterContext.ToListAsync());
        }

        // GET: Adaposts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adapost = await _context.Adaposturi
                .Include(a => a.Oras)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adapost == null)
            {
                return NotFound();
            }

            return View(adapost);
        }

        // GET: Adaposts/Create
        public IActionResult Create()
        {
            ViewData["OrasID"] = new SelectList(_context.Orase, "ID", "ID");
            return View();
        }

        // POST: Adaposts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrasID,Nume,Adresa")] Adapost adapost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adapost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrasID"] = new SelectList(_context.Orase, "ID", "ID", adapost.OrasID);
            return View(adapost);
        }

        // GET: Adaposts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adapost = await _context.Adaposturi.FindAsync(id);
            if (adapost == null)
            {
                return NotFound();
            }
            ViewData["OrasID"] = new SelectList(_context.Orase, "ID", "ID", adapost.OrasID);
            return View(adapost);
        }

        // POST: Adaposts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrasID,Nume,Adresa")] Adapost adapost)
        {
            if (id != adapost.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adapost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdapostExists(adapost.ID))
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
            ViewData["OrasID"] = new SelectList(_context.Orase, "ID", "ID", adapost.OrasID);
            return View(adapost);
        }

        // GET: Adaposts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adapost = await _context.Adaposturi
                .Include(a => a.Oras)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adapost == null)
            {
                return NotFound();
            }

            return View(adapost);
        }

        // POST: Adaposts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adapost = await _context.Adaposturi.FindAsync(id);
            _context.Adaposturi.Remove(adapost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdapostExists(int id)
        {
            return _context.Adaposturi.Any(e => e.ID == id);
        }
    }
}
