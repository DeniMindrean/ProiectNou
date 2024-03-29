﻿using System;
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
    public class TipAnimalsController : Controller
    {
        private readonly ShelterContext _context;

        public TipAnimalsController(ShelterContext context)
        {
            _context = context;
        }

        // GET: TipAnimals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipuri.ToListAsync());
        }

        // GET: TipAnimals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipAnimal = await _context.Tipuri
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipAnimal == null)
            {
                return NotFound();
            }

            return View(tipAnimal);
        }

        // GET: TipAnimals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipAnimals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume_Tip,Rasa")] TipAnimal tipAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipAnimal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipAnimal);
        }

        // GET: TipAnimals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipAnimal = await _context.Tipuri.FindAsync(id);
            if (tipAnimal == null)
            {
                return NotFound();
            }
            return View(tipAnimal);
        }

        // POST: TipAnimals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume_Tip,Rasa")] TipAnimal tipAnimal)
        {
            if (id != tipAnimal.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipAnimalExists(tipAnimal.ID))
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
            return View(tipAnimal);
        }

        // GET: TipAnimals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipAnimal = await _context.Tipuri
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipAnimal == null)
            {
                return NotFound();
            }

            return View(tipAnimal);
        }

        // POST: TipAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipAnimal = await _context.Tipuri.FindAsync(id);
            _context.Tipuri.Remove(tipAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipAnimalExists(int id)
        {
            return _context.Tipuri.Any(e => e.ID == id);
        }
    }
}
