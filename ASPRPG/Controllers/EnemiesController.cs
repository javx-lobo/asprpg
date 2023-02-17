using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPRPG.Models;

namespace ASPRPG.Controllers
{
    public class EnemiesController : Controller
    {
        private readonly YourDbContext _context;

        public EnemiesController(YourDbContext context)
        {
            _context = context;
        }

        // GET: Enemies
        public async Task<IActionResult> Index()
        {
              return _context.Enemy != null ? 
                          View(await _context.Enemy.ToListAsync()) :
                          Problem("Entity set 'YourDbContext.Enemy'  is null.");
        }

        // GET: Enemies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enemy == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // GET: Enemies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enemies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Health,Attack,Defense,Icon")] Enemy enemy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enemy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enemy);
        }

        // GET: Enemies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enemy == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemy.FindAsync(id);
            if (enemy == null)
            {
                return NotFound();
            }
            return View(enemy);
        }

        // POST: Enemies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Health,Attack,Defense,Icon")] Enemy enemy)
        {
            if (id != enemy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enemy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnemyExists(enemy.Id))
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
            return View(enemy);
        }

        // GET: Enemies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enemy == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // POST: Enemies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enemy == null)
            {
                return Problem("Entity set 'YourDbContext.Enemy'  is null.");
            }
            var enemy = await _context.Enemy.FindAsync(id);
            if (enemy != null)
            {
                _context.Enemy.Remove(enemy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnemyExists(int id)
        {
          return (_context.Enemy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
