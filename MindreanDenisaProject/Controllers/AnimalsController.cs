using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MindreanDenisaProject.Data;
using MindreanDenisaProject.Models;

namespace MindreanDenisaProject.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ShelterContext _context;

        public AnimalsController(ShelterContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var shelterContext = _context.Animale.Include(a => a.Adapost).Include(a => a.TipAnimal);
            return View(await shelterContext.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale
                .Include(a => a.Adapost)
                .Include(a => a.TipAnimal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["AdapostID"] = new SelectList(_context.Adaposturi, "ID", "ID");
            ViewData["TipAnimalID"] = new SelectList(_context.Tipuri, "ID", "ID");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume,TipAnimalID,AdapostID,Data_Nasterii")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdapostID"] = new SelectList(_context.Adaposturi, "ID", "ID", animal.AdapostID);
            ViewData["TipAnimalID"] = new SelectList(_context.Tipuri, "ID", "ID", animal.TipAnimalID);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["AdapostID"] = new SelectList(_context.Adaposturi, "ID", "ID", animal.AdapostID);
            ViewData["TipAnimalID"] = new SelectList(_context.Tipuri, "ID", "ID", animal.TipAnimalID);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume,TipAnimalID,AdapostID,Data_Nasterii")] Animal animal)
        {
            if (id != animal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.ID))
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
            ViewData["AdapostID"] = new SelectList(_context.Adaposturi, "ID", "ID", animal.AdapostID);
            ViewData["TipAnimalID"] = new SelectList(_context.Tipuri, "ID", "ID", animal.TipAnimalID);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale
                .Include(a => a.Adapost)
                .Include(a => a.TipAnimal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animale.FindAsync(id);
            _context.Animale.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animale.Any(e => e.ID == id);
        }
    }
}
