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
    public class TbSanPhamController : BaseController
    {
        private readonly ChtcContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TbSanPhamController(ChtcContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: TbSanPham
        public async Task<IActionResult> Index()
        {
            if (!IsLogin)
            {
                return RedirectToAction("Login", "Account");
            }
            var chtcContext = _context.TbSanPhams.Include(t => t.loaihangID);
            return View(await chtcContext.ToListAsync());
        }

        // GET: TbSanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbSanPhams == null)
            {
                return NotFound();
            }

            var tbSanPham = await _context.TbSanPhams
                 .Include(t => t.loaihangID)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (tbSanPham == null)
            {
                return NotFound();
            }

            return View(tbSanPham);
        }

        // GET: TbSanPham/Create
        public IActionResult Create()
        {
            ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "ID");
            return View();
        }

        // POST: TbSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaSanPham,TenSanPham,MoTa,Imagefile,IDloaiHang,TinhTrang,Gia")] TbSanPham tbSanPham)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(tbSanPham.Imagefile.FileName);
                string extension = Path.GetExtension(tbSanPham.Imagefile.FileName);
                tbSanPham.AnhSp = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/AnhSp", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await tbSanPham.Imagefile.CopyToAsync(fileStream);
                    {
                        await tbSanPham.Imagefile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(tbSanPham);
                await _context.SaveChangesAsync();
                ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "TenLH", tbSanPham.IDloaiHang);
                return RedirectToAction(nameof(Index));
            }
            return View(tbSanPham);
        }

        // GET: TbSanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbSanPhams == null)
            {
                return NotFound();
            }

            var tbSanPham = await _context.TbSanPhams.FindAsync(id);
            if (tbSanPham == null)
            {
                return NotFound();
            }
            ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "TenLH", tbSanPham.IDloaiHang);
            return View(tbSanPham);
        }

        // POST: TbSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaSanPham,TenSanPham,MoTa,Imagefile,IDloaiHang,TinhTrang,Gia")] TbSanPham tbSanPham)
        {
            if (id != tbSanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(tbSanPham.Imagefile.FileName);
                    string extension = Path.GetExtension(tbSanPham.Imagefile.FileName);
                    tbSanPham.AnhSp = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/AnhSp", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await tbSanPham.Imagefile.CopyToAsync(fileStream);
                        {
                            await tbSanPham.Imagefile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(tbSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSanPhamExists(tbSanPham.ID))
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
            ViewData["IDloaiHang"] = new SelectList(_context.TbLoaiHangs, "ID", "ID", tbSanPham.IDloaiHang);
            return View(tbSanPham);
        }

        // GET: TbSanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbSanPhams == null)
            {
                return NotFound();
            }

            var tbSanPham = await _context.TbSanPhams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbSanPham == null)
            {
                return NotFound();
            }

            return View(tbSanPham);
        }

        // POST: TbSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbSanPhams == null)
            {
                return Problem("Entity set 'ChtcContext.TbSanPhams'  is null.");
            }
            var tbSanPham = await _context.TbSanPhams
                 .Include(t => t.loaihangID)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (tbSanPham != null)
            {
                _context.TbSanPhams.Remove(tbSanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSanPhamExists(int id)
        {
          return (_context.TbSanPhams?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
