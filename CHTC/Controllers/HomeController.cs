using CHTC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CHTC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChtcContext _context;

        public HomeController(ILogger<HomeController> logger, ChtcContext context)
        {
            _logger = logger;
            _context= context;
        }
        public IActionResult TrangChu()
        {
            return View();
        }
        public IActionResult Index()
        {

            // Khởi tạo đối tượng DbContext
            using (var db = new ChtcContext())
            {
                // Lấy danh sách sản phẩm từ bảng TbSanPham
                var products = db.TbSanPhams.ToList();
                var khach  = db.TbKhacHangs.ToList();
                // Tính tổng số lượng sản phẩm
                var totalQuantity = products.Count;
                // Tính tổng số lượng sản phẩm
                var totalKhach = products.Count;
                // Truyền giá trị totalQuantity sang View
                ViewBag.TotalQuantity = totalQuantity;
                ViewBag.TotalKhach = totalKhach;

                // Lấy danh sách sản phẩm từ bảng TbSanPham với điều kiện TinhTrang là đã bán 
                var tinhtrang  = db.TbSanPhams.Where(p => p.TinhTrang == true).ToList();

                // Đếm tổng số lượng sản phẩm
                var totaltinhTrang = tinhtrang.Count;

                // Truyền giá trị totalQuantity sang View
                ViewBag.TotalTinhTrang = totaltinhTrang;

                // Lấy danh sách sản phẩm từ bảng TbThuCung với điều kiện TinhTrang là đã tiêm
                var datiem  = db.TbThuCungs.Where(p => p.TinhTrang == true).ToList();

                // Đếm tổng số lượng thú cưng 
                var totaldatiem = datiem.Count;

                // Truyền giá trị totalDatiem sang View
                ViewBag.TotalDaTiem = totaldatiem;
            }
           /* if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return View("Index_Admin");
                }

                return View("Index_User");
            }*/
            return View();
        }

        public IActionResult Privacy()
        {
            using (var db = new ChtcContext())
            {
              //tính tổng số nhân viên trong cửa hàng
                var nhanvien = db.TbNhanViens.ToList();
                var totalNV = nhanvien.Count;
                ViewBag.ToTalNhanVien = totalNV;
            //tính số thú cưng chưa tiêm 
                var datiem = db.TbThuCungs.Where(p => p.TinhTrang == false).ToList();
                var totaldatiem = datiem.Count;
                ViewBag.TotalDaTiem = totaldatiem;
                //tính số thú cưng chưa tiêm 
                var sanpham = db.TbSanPhams.Where(p => p.TinhTrang == false).ToList();
                var totalsanpham = sanpham.Count;
                ViewBag.TotalSP = totalsanpham;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}