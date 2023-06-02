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
    public class TbNhanVienController : BaseController
    {
        private readonly ChtcContext _context;

        public TbNhanVienController(ChtcContext context)
        {
            _context = context;
        }

        // GET: TbNhanVien
        public async Task<IActionResult> Index()
        {
            if (!IsLogin)
            {
                return RedirectToAction("Login", "Account");
            }
            var chtcContext = _context.TbNhanViens.Include(t => t.IdtaiKhoanNavigation);
            return View(await chtcContext.ToListAsync());
        }

        // GET: TbNhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbNhanViens == null)
            {
                return NotFound();
            }

            var tbNhanVien = await _context.TbNhanViens
                .Include(t => t.IdtaiKhoanNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbNhanVien == null)
            {
                return NotFound();
            }

            return View(tbNhanVien);
        }

        // GET: TbNhanVien/Create
        public IActionResult Create()
        {
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id");
            return View();
        }

        // POST: TbNhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDtaiKhoan,MaNhanVien,TenNhanVien,DiaChi,NgaySinh,Sdt,Email")] TbNhanVien tbNhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id", tbNhanVien.IDtaiKhoan);
            return View(tbNhanVien);
        }

        // GET: TbNhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbNhanViens == null)
            {
                return NotFound();
            }

            var tbNhanVien = await _context.TbNhanViens.FindAsync(id);
            if (tbNhanVien == null)
            {
                return NotFound();
            }
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id", tbNhanVien.IDtaiKhoan);
            return View(tbNhanVien);
        }

        // POST: TbNhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDtaiKhoan,MaNhanVien,TenNhanVien,DiaChi,NgaySinh,Sdt,Email")] TbNhanVien tbNhanVien)
        {
            if (id != tbNhanVien.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNhanVienExists(tbNhanVien.ID))
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
            ViewData["IDtaiKhoan"] = new SelectList(_context.TbTaiKhoans, "Id", "Id", tbNhanVien.IDtaiKhoan);
            return View(tbNhanVien);
        }

        // GET: TbNhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbNhanViens == null)
            {
                return NotFound();
            }

            var tbNhanVien = await _context.TbNhanViens
                .Include(t => t.IdtaiKhoanNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbNhanVien == null)
            {
                return NotFound();
            }

            return View(tbNhanVien);
        }

        // POST: TbNhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbNhanViens == null)
            {
                return Problem("Entity set 'ChtcContext.TbNhanViens'  is null.");
            }
            var tbNhanVien = await _context.TbNhanViens.FindAsync(id);
            if (tbNhanVien != null)
            {
                _context.TbNhanViens.Remove(tbNhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNhanVienExists(int id)
        {
          return (_context.TbNhanViens?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
