using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHTC.Models;
using Microsoft.Extensions.Hosting;

namespace CHTC.Controllers
{
    public class TbThuCungController : BaseController
    {
        private readonly ChtcContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TbThuCungController(ChtcContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: TbThuCung
        public async Task<IActionResult> Index(int? id)
        {
            if (!IsLogin)
            {
                return RedirectToAction("Login", "Account");
            }
            var chtcContext = _context.TbThuCungs.Include(t => t.loaihangID);
            return View(await chtcContext.ToListAsync());
        }
        public IActionResult Logout()
        {
            //Xử lý logic đăng xuất ở đây
            //Ví dụ xóa biến Session và chuyển hướng đến trang đăng nhập
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // GET: TbThuCung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbThuCungs == null)
            {
                return NotFound();
            }

            var tbThuCung = await _context.TbThuCungs
                 .Include(t => t.loaihangID)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (tbThuCung == null)
            {
                return NotFound();
            }

            return View(tbThuCung);
        }

        // GET: TbThuCung/Create
        public IActionResult Create()
        {
            ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "ID");
            return View();
        }

        // POST: TbThuCung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaThuCung,Ten,Tuoi,GioiTinh,Giong,MoTa,Imagefile,IDloaiHang,TinhTrang,Gia,TrangThai")] TbThuCung tbThuCung)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(tbThuCung.Imagefile.FileName);
                string extension = Path.GetExtension(tbThuCung.Imagefile.FileName);
                tbThuCung.AnhTc = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/AnhPet", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await tbThuCung.Imagefile.CopyToAsync(fileStream);
                    {
                        await tbThuCung.Imagefile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(tbThuCung);
                await _context.SaveChangesAsync();
                ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "ID", tbThuCung.IDloaiHang);
                return RedirectToAction(nameof(Index));
            }
            return View(tbThuCung);
        }

        // GET: TbThuCung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbThuCungs == null)
            {
                return NotFound();
            }

            var tbThuCung = await _context.TbThuCungs.FindAsync(id);
            if (tbThuCung == null)
            {
                return NotFound();
            }
            ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "ID", tbThuCung.IDloaiHang);
            return View(tbThuCung);
        }

        // POST: TbThuCung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaThuCung,Ten,Tuoi,GioiTinh,Giong,MoTa,Imagefile,IDloaiHang,TinhTrang,Gia,TrangThai")] TbThuCung tbThuCung)
        {
            if (id != tbThuCung.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(tbThuCung.Imagefile.FileName);
                    string extension = Path.GetExtension(tbThuCung.Imagefile.FileName);
                    tbThuCung.AnhTc = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/AnhPet", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await tbThuCung.Imagefile.CopyToAsync(fileStream);
                        {
                            await tbThuCung.Imagefile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(tbThuCung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThuCungExists(tbThuCung.ID))
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
            ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "ID", tbThuCung.IDloaiHang);
            return View(tbThuCung);
        }

        // GET: TbThuCung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbThuCungs == null)
            {
                return NotFound();
            }

            var tbThuCung = await _context.TbThuCungs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbThuCung == null)
            {
                return NotFound();
            }

            return View(tbThuCung);
        }

        // POST: TbThuCung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbThuCungs == null)
            {
                return Problem("Entity set 'ChtcContext.TbThuCungs'  is null.");
            }
            var tbThuCung = await _context.TbThuCungs
                 .Include(t => t.loaihangID)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (tbThuCung != null)
            {
                _context.TbThuCungs.Remove(tbThuCung);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThuCungExists(int id)
        {
          return (_context.TbThuCungs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
