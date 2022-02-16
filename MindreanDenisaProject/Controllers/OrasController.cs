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
   // [Authorize(Roles = "Admin")]
    public class OrasController : Controller
    {
        private readonly ShelterContext _context;

        public OrasController(ShelterContext context)
        {
            _context = context;
        }

        // GET: Oras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orase.ToListAsync());
        }

        // GET: Oras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oras = await _context.Orase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oras == null)
            {
                return NotFound();
            }

            return View(oras);
        }

        // GET: Oras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume")] Oras oras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oras);
        }

        // GET: Oras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oras = await _context.Orase.FindAsync(id);
            if (oras == null)
            {
                return NotFound();
            }
            return View(oras);
        }

        // POST: Oras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume")] Oras oras)
        {
            if (id != oras.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrasExists(oras.ID))
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
            return View(oras);
        }

        // GET: Oras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oras = await _context.Orase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oras == null)
            {
                return NotFound();
            }

            return View(oras);
        }

        // POST: Oras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oras = await _context.Orase.FindAsync(id);
            _context.Orase.Remove(oras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrasExists(int id)
        {
            return _context.Orase.Any(e => e.ID == id);
        }
    }
}
