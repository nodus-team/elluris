using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nodus.Elluris.Data.ORM;
using Nodus.Elluris.Domain.Models;
using Nodus.Elluris.Domain.Util;

namespace Nodus.Elluris.Mvc.Controllers
{
    public class ObrasController : Controller
    {
        private readonly NodusArtDbContext _context;

        public ObrasController(NodusArtDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Obras.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obras == null)
            {
                return NotFound();
            }

            return View(obras);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Create([Bind("Descricao,Observacao,UrlFoto,Id,DataAtualizacao")] Obras obras)
        {
            if (ModelState.IsValid)
            {
                obras.UrlFoto = FuncoesComuns.ReduzirImagem(obras.UrlFoto);
                _context.Add(obras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obras);
        }

        [RequestSizeLimit(2147483648)]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras.FindAsync(id);
            if (obras == null)
            {
                return NotFound();
            }
            return View(obras);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Descricao,Observacao,UrlFoto,Id,DataAtualizacao")] Obras obras)
        {
            if (id != obras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    obras.UrlFoto = FuncoesComuns.ReduzirImagem(obras.UrlFoto);
                    _context.Update(obras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObrasExists(obras.Id))
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
            return View(obras);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obras == null)
            {
                return NotFound();
            }

            return View(obras);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var obras = await _context.Obras.FindAsync(id);
            _context.Obras.Remove(obras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObrasExists(Guid id)
        {
            return _context.Obras.Any(e => e.Id == id);
        }
    }
}
