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
    public class TbKhacHangController : Controller
    {
        private readonly ChtcContext _context;

        public TbKhacHangController(ChtcContext context)
        {
            _context = context;
        }

        // GET: TbKhacHang
        public async Task<IActionResult> Index()
        {
            var chtcContext = _context.TbKhacHangs.Include(t => t.IdtaiKhoanNavigation);
            return View(await chtcContext.ToListAsync());
        }

        // GET: TbKhacHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbKhacHangs == null)
            {
                return NotFound();
            }

            var tbKhacHang = await _context.TbKhacHangs
                .Include(t => t.IdtaiKhoanNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbKhacHang == null)
            {
                return NotFound();
            }

            return View(tbKhacHang);
        }

        // GET: TbKhacHang/Create
        public IActionResult Create()
        {
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id");
            return View();
        }

        // POST: TbKhacHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDtaiKhoan,HoVaTen,Sdt,Email,DiaChi")] TbKhacHang tbKhacHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhacHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id", tbKhacHang.IDtaiKhoan);
            return View(tbKhacHang);
        }

        // GET: TbKhacHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbKhacHangs == null)
            {
                return NotFound();
            }

            var tbKhacHang = await _context.TbKhacHangs.FindAsync(id);
            if (tbKhacHang == null)
            {
                return NotFound();
            }
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id", tbKhacHang.IDtaiKhoan);
            return View(tbKhacHang);
        }

        // POST: TbKhacHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDtaiKhoan,HoVaTen,Sdt,Email,DiaChi")] TbKhacHang tbKhacHang)
        {
            if (id != tbKhacHang.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhacHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhacHangExists(tbKhacHang.ID))
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
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id", tbKhacHang.IDtaiKhoan);
            return View(tbKhacHang);
        }

        // GET: TbKhacHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbKhacHangs == null)
            {
                return NotFound();
            }

            var tbKhacHang = await _context.TbKhacHangs
                .Include(t => t.IdtaiKhoanNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbKhacHang == null)
            {
                return NotFound();
            }

            return View(tbKhacHang);
        }

        // POST: TbKhacHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbKhacHangs == null)
            {
                return Problem("Entity set 'ChtcContext.TbKhacHangs'  is null.");
            }
            var tbKhacHang = await _context.TbKhacHangs.FindAsync(id);
            if (tbKhacHang != null)
            {
                _context.TbKhacHangs.Remove(tbKhacHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhacHangExists(int id)
        {
          return (_context.TbKhacHangs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
