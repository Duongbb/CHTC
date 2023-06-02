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
    public class TbChiTietDhController : Controller
    {
        private readonly ChtcContext _context;

        public TbChiTietDhController(ChtcContext context)
        {
            _context = context;
        }

        // GET: TbChiTietDh
        public async Task<IActionResult> Index()
        {
            var chtcContext = _context.TbChiTietDhs.Include(t => t.IDdonHangNavigation).Include(t => t.IDsanPhamNavigation).Include(t => t.IDtiemchungNavigation).Include(t => t.IDthuCungNavigation);
            /*var chiTietDhs = _context.TbChiTietDhs
                           .Where(c => c.IDdonHangNavigation.MaDonHang == _context.TbDonDatHangs.FirstOrDefault(d => d.ID == c.IDdonHang).MaDonHang)
                           .ToListAsync();*/
            return View(await chtcContext.ToListAsync());
            
        }

        public async Task<IActionResult> ChiTietDh(string maDonHang)
        {
            var tbChiTietDhs = _context.TbChiTietDhs
                        .Include(x => x.IDdonHangNavigation)
                        .Where(x => x.IDdonHangNavigation.MaDonHang == maDonHang)
                        .ToList();

            ViewBag.MaDonHang = maDonHang;
            return View(tbChiTietDhs);
        }
        // GET: TbChiTietDh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbChiTietDhs == null)
            {
                return NotFound();
            }

            var tbChiTietDh = await _context.TbChiTietDhs
                .Include(t => t.IDdonHangNavigation)
                .Include(t => t.IDsanPhamNavigation)
                .Include(t => t.IDtiemchungNavigation)
                .Include(t => t.IDthuCungNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbChiTietDh == null)
            {
                return NotFound();
            }

            return View(tbChiTietDh);
        }

        // GET: TbChiTietDh/Create
        public IActionResult Create()
        {
            ViewData["IDdonHang"] = new SelectList(_context.TbDonDatHangs, "ID", "MaDonHang");
            ViewData["IDsanPham"] = new SelectList(_context.TbSanPhams, "ID", "TenSanPham");
            ViewData["IDtiemChung"] = new SelectList(_context.TbTiemChungs, "ID", "Ten");
            ViewData["IDthuCung"] = new SelectList(_context.TbThuCungs, "ID", "Ten");
            return View();
        }

        // POST: TbChiTietDh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDdonHang,IDsanPham,IDthuCung, IDtiemChung,SoLuong,Gia")] TbChiTietDh tbChiTietDh)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin sản phẩm và thú cưng dựa trên ID được chọn
                var sanPham = await _context.TbSanPhams.FindAsync(tbChiTietDh.IDsanPham);
                var thuCung = await _context.TbThuCungs.FindAsync(tbChiTietDh.IDthuCung);
                var thuTiem = await _context.TbTiemChungs.FindAsync(tbChiTietDh.IDtiemChung);
                // Tính giá tổng của chi tiết đơn hàng
                tbChiTietDh.Gia = (tbChiTietDh.SoLuong * sanPham.Gia) + thuCung.Gia + thuTiem.Gia;

                // Thêm chi tiết đơn hàng vào database
                _context.Add(tbChiTietDh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IDdonHang = new SelectList(_context.TbDonDatHangs, "ID", "ID");
            ViewBag.IDsanPham = new SelectList(_context.TbSanPhams, "ID", "TenSanPham");
            ViewBag.IDtiemChung = new SelectList(_context.TbTiemChungs, "ID", "Ten");
            ViewBag.IDthuCung = new SelectList(_context.TbThuCungs, "ID", "TenThuCung");
            return View(tbChiTietDh);
        }

        // GET: TbChiTietDh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Get the TbChiTietDh object with the specified ID from the database
            var tbChiTietDh = _context.TbChiTietDhs.Find(id);

            // Check whether the object was found
            if (tbChiTietDh == null)
            {
                return NotFound();
            }

            // Initialize the ViewBag objects for the dropdown lists
            ViewBag.IDdonHang = new SelectList(_context.TbDonDatHangs, "ID", "ID", tbChiTietDh.IDdonHang);
            ViewBag.IDsanPham = new SelectList(_context.TbSanPhams, "ID", "TenSanPham", tbChiTietDh.IDsanPham);
            ViewBag.IDtiemChung = new SelectList(_context.TbTiemChungs, "ID", "Ten", tbChiTietDh.IDtiemChung);
            ViewBag.IDthuCung = new SelectList(_context.TbThuCungs, "ID", "Ten", tbChiTietDh.IDthuCung);

            // Pass the TbChiTietDh object to the view
            return View(tbChiTietDh);
        }

        // POST: TbChiTietDh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDdonHang,IDsanPham,IDtiemChung,IDthuCung,SoLuong,Gia")] TbChiTietDh tbChiTietDh)
        {
            if (id != tbChiTietDh.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Lấy thông tin sản phẩm và thú cưng dựa trên ID được chọn
                    var sanPham = await _context.TbSanPhams.FindAsync(tbChiTietDh.IDsanPham);
                    var thuCung = await _context.TbThuCungs.FindAsync(tbChiTietDh.IDthuCung);
                    var thuTiem = await _context.TbTiemChungs.FindAsync(tbChiTietDh.IDtiemChung);
                    // Tính giá tổng của chi tiết đơn hàng
                    tbChiTietDh.Gia = (tbChiTietDh.SoLuong * sanPham.Gia) + thuCung.Gia + thuTiem.Gia;

                    _context.Update(tbChiTietDh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChiTietDhExists(tbChiTietDh.ID))
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
            ViewBag.IDdonHang = new SelectList(_context.TbDonDatHangs, "ID", "MaDonHang", tbChiTietDh.IDdonHang);
            ViewBag.IDsanPham = new SelectList(_context.TbSanPhams, "ID", "TenSanPham", tbChiTietDh.IDsanPham);
            ViewBag.IDtiemChung = new SelectList(_context.TbTiemChungs, "ID", "Ten", tbChiTietDh.IDtiemChung);
            ViewBag.IDthuCung = new SelectList(_context.TbThuCungs, "ID", "Ten", tbChiTietDh.IDthuCung);
            return View(tbChiTietDh);
        }

        // GET: TbChiTietDh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbChiTietDhs == null)
            {
                return NotFound();
            }

            var tbChiTietDh = await _context.TbChiTietDhs
                .Include(t => t.IDdonHangNavigation)
                .Include(t => t.IDsanPhamNavigation)
                .Include(t => t.IDtiemchungNavigation)
                .Include(t => t.IDthuCungNavigation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbChiTietDh == null)
            {
                return NotFound();
            }

            return View(tbChiTietDh);
        }

        // POST: TbChiTietDh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbChiTietDhs == null)
            {
                return Problem("Entity set 'ChtcContext.TbChiTietDhs'  is null.");
            }
            var tbChiTietDh = await _context.TbChiTietDhs.FindAsync(id);
            if (tbChiTietDh != null)
            {
                _context.TbChiTietDhs.Remove(tbChiTietDh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChiTietDhExists(int id)
        {
          return (_context.TbChiTietDhs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
