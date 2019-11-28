using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nodus.Elluris.Data.ORM;
using Nodus.Elluris.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nodus.Elluris.Mvc.Controllers
{
    [Authorize]
    public class EventoPeriodosController : Controller
    {
        private readonly NodusArtDbContext _context;

        public EventoPeriodosController(NodusArtDbContext context)
        {
            _context = context;
        }

        // GET: EventoPeriodos
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventoPeriodos.ToListAsync());
        }

        // GET: EventoPeriodos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoPeriodo = await _context.EventoPeriodos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoPeriodo == null)
            {
                return NotFound();
            }

            return View(eventoPeriodo);
        }

        // GET: EventoPeriodos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventoPeriodos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataInicial,DataFinal,Id,DataAtualizacao")] EventoPeriodo eventoPeriodo)
        {
            if (ModelState.IsValid)
            {
                eventoPeriodo.Id = Guid.NewGuid();
                _context.Add(eventoPeriodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventoPeriodo);
        }

        // GET: EventoPeriodos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoPeriodo = await _context.EventoPeriodos.FindAsync(id);
            if (eventoPeriodo == null)
            {
                return NotFound();
            }
            return View(eventoPeriodo);
        }

        // POST: EventoPeriodos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DataInicial,DataFinal,Id,DataAtualizacao")] EventoPeriodo eventoPeriodo)
        {
            if (id != eventoPeriodo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventoPeriodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoPeriodoExists(eventoPeriodo.Id))
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
            return View(eventoPeriodo);
        }

        // GET: EventoPeriodos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoPeriodo = await _context.EventoPeriodos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventoPeriodo == null)
            {
                return NotFound();
            }

            return View(eventoPeriodo);
        }

        // POST: EventoPeriodos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventoPeriodo = await _context.EventoPeriodos.FindAsync(id);
            _context.EventoPeriodos.Remove(eventoPeriodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoPeriodoExists(Guid id)
        {
            return _context.EventoPeriodos.Any(e => e.Id == id);
        }
    }
}
