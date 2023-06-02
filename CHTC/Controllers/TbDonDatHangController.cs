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
    public class TbDonDatHangController : Controller
    {
        private readonly ChtcContext _context;

        public TbDonDatHangController(ChtcContext context)
        {
            _context = context;
        }

        // GET: TbDonDatHang
        public async Task<IActionResult> Index()
        {
            var chtcContext = _context.TbDonDatHangs.Include(t => t.IDnvNavigation);
            var tbDonDatHangs = _context.TbDonDatHangs.ToList();
            return View(await chtcContext.ToListAsync());
        }

        public ActionResult ChiTietDh(string maDonHang)
        {
            var tbChiTietDhs = _context.TbChiTietDhs.Include(x => x.IDdonHangNavigation).Where(x => x.IDdonHangNavigation.MaDonHang == maDonHang).ToList();

            ViewBag.MaDonHang = maDonHang;

            return View(tbChiTietDhs);
        }

        // GET: TbDonDatHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbDonDatHangs == null)
            {
                return NotFound();
            }

            var tbDonDatHang = await _context.TbDonDatHangs
                .Include(t => t.IDnvNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbDonDatHang == null)
            {
                return NotFound();
            }

            return View(tbDonDatHang);
        }

        // GET: TbDonDatHang/Create
        public IActionResult Create()
        {
            ViewData["IDnv"] = new SelectList(_context.TbNhanViens, "ID", "ID");
            return View();
        }

        // POST: TbDonDatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDnv,MaDonHang,NgayDatHang,IDkhachHang")] TbDonDatHang tbDonDatHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDonDatHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDnv"] = new SelectList(_context.TbNhanViens, "ID", "ID", tbDonDatHang.IDnv);
            return View(tbDonDatHang);
        }

        // GET: TbDonDatHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbDonDatHangs == null)
            {
                return NotFound();
            }

            var tbDonDatHang = await _context.TbDonDatHangs.FindAsync(id);
            if (tbDonDatHang == null)
            {
                return NotFound();
            }
            ViewData["IDnv"] = new SelectList(_context.TbNhanViens, "ID", "ID", tbDonDatHang.IDnv);
            return View(tbDonDatHang);
        }

        // POST: TbDonDatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDnv,MaDonHang,NgayDatHang,IDkhachHang")] TbDonDatHang tbDonDatHang)
        {
            if (id != tbDonDatHang.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDonDatHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDonDatHangExists(tbDonDatHang.ID))
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
            ViewData["IDnv"] = new SelectList(_context.TbNhanViens, "ID", "ID", tbDonDatHang.IDnv);
            return View(tbDonDatHang);
        }

        // GET: TbDonDatHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbDonDatHangs == null)
            {
                return NotFound();
            }

            var tbDonDatHang = await _context.TbDonDatHangs
                .Include(t => t.IDnvNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbDonDatHang == null)
            {
                return NotFound();
            }

            return View(tbDonDatHang);
        }

        // POST: TbDonDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbDonDatHangs == null)
            {
                return Problem("Entity set 'ChtcContext.TbDonDatHangs'  is null.");
            }
            var tbDonDatHang = await _context.TbDonDatHangs.FindAsync(id);
            if (tbDonDatHang != null)
            {
                _context.TbDonDatHangs.Remove(tbDonDatHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDonDatHangExists(int id)
        {
          return (_context.TbDonDatHangs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
