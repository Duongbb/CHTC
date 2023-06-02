
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHTC.Models;

namespace CHTC.Controllers
{
    public class TbNhaCcController : Controller
    {
        private readonly ChtcContext _context;

        public TbNhaCcController(ChtcContext context)
        {
            _context = context;
        }

        // GET: TbNhaCc
        public async Task<IActionResult> Index()
        {
              return _context.TbNhaCcs != null ? 
                          View(await _context.TbNhaCcs.ToListAsync()) :
                          Problem("Entity set 'ChtcContext.TbNhaCcs'  is null.");
        }

        // GET: TbNhaCc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbNhaCcs == null)
            {
                return NotFound();
            }

            var tbNhaCc = await _context.TbNhaCcs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbNhaCc == null)
            {
                return NotFound();
            }

            return View(tbNhaCc);
        }

        // GET: TbNhaCc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbNhaCc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaNhaCc,TenNhaCc,Sdt,DiaChi")] TbNhaCc tbNhaCc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNhaCc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbNhaCc);
        }

        // GET: TbNhaCc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbNhaCcs == null)
            {
                return NotFound();
            }

            var tbNhaCc = await _context.TbNhaCcs.FindAsync(id);
            if (tbNhaCc == null)
            {
                return NotFound();
            }
            return View(tbNhaCc);
        }

        // POST: TbNhaCc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaNhaCc,TenNhaCc,Sdt,DiaChi")] TbNhaCc tbNhaCc)
        {
            if (id != tbNhaCc.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNhaCc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNhaCcExists(tbNhaCc.ID))
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
            return View(tbNhaCc);
        }

        // GET: TbNhaCc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbNhaCcs == null)
            {
                return NotFound();
            }

            var tbNhaCc = await _context.TbNhaCcs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbNhaCc == null)
            {
                return NotFound();
            }

            return View(tbNhaCc);
        }

        // POST: TbNhaCc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbNhaCcs == null)
            {
                return Problem("Entity set 'ChtcContext.TbNhaCcs'  is null.");
            }
            var tbNhaCc = await _context.TbNhaCcs.FindAsync(id);
            if (tbNhaCc != null)
            {
                _context.TbNhaCcs.Remove(tbNhaCc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNhaCcExists(int id)
        {
          return (_context.TbNhaCcs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
