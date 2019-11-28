using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nodus.Elluris.Data.ORM;
using Nodus.Elluris.Domain.Models;

namespace Nodus.Elluris.Mvc.Controllers
{
    public class BeaconsController : Controller
    {
        private readonly NodusArtDbContext _context;

        public BeaconsController(NodusArtDbContext context)
        {
            _context = context;
        }

        // GET: Beacons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beacons.ToListAsync());
        }

        // GET: Beacons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacon = await _context.Beacons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beacon == null)
            {
                return NotFound();
            }

            return View(beacon);
        }

        // GET: Beacons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beacons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeaconCode,Id,DataAtualizacao")] Beacon beacon)
        {
            if (ModelState.IsValid)
            {
                beacon.Id = Guid.NewGuid();
                _context.Add(beacon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beacon);
        }

        // GET: Beacons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacon = await _context.Beacons.FindAsync(id);
            if (beacon == null)
            {
                return NotFound();
            }
            return View(beacon);
        }

        // POST: Beacons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BeaconCode,Id,DataAtualizacao")] Beacon beacon)
        {
            if (id != beacon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beacon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeaconExists(beacon.Id))
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
            return View(beacon);
        }

        // GET: Beacons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacon = await _context.Beacons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beacon == null)
            {
                return NotFound();
            }

            return View(beacon);
        }

        // POST: Beacons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var beacon = await _context.Beacons.FindAsync(id);
            _context.Beacons.Remove(beacon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeaconExists(Guid id)
        {
            return _context.Beacons.Any(e => e.Id == id);
        }
    }
}
