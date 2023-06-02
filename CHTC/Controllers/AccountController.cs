using CHTC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CHTC.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ChtcContext _context;
        public AccountController(ChtcContext context)
        {
            _context = context;
        }
        //Get user/login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ID, TaiKhoan, MatKhau,Quyen ")] TbTaiKhoan model)
        {

            if (ModelState.IsValid)
            {
                //Kiem tra TaiKhoan co ton tai ko
                var loginUser = await _context.TbTaiKhoans.FirstOrDefaultAsync(m => m.TaiKhoan == model.TaiKhoan);
                if (loginUser == null)
                {
                    ModelState.AddModelError("", "Dang nhap that bai");
                    return View(model);
                }
                else
                {
                    //Kiem tra ma MD5 cua pass hien tai co khop voi MD5 cua pass da luu ko
                    SHA256 hashMethod = SHA256.Create();

                    if (Util.Cryptography.VeryfyHash(hashMethod, model.MatKhau, loginUser.MatKhau))
                    {
                        CurrentUser = loginUser.TaiKhoan;
                        var cv = (from c in _context.TbTaiKhoans where c.TaiKhoan == model.TaiKhoan select c.Quyen).SingleOrDefault();
                        if (cv == true)
                        {
                            //nếu =1 là admin
                            HttpContext.Session.SetInt32("Quyen",1);
                        }
                        else
                        {
                            //Nếu =0 là nhân viên
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng Nhập Thất Bại!!");
                        return View(model);
                    }
                }
            }
            return View(model);
        }

           
        

        /*if (ModelState.IsValid)
        {
            //Kiem tra TaiKhoan co ton tai ko
            var loginUser = await _context.TbTaiKhoans.FirstOrDefaultAsync(m => m.TaiKhoan == model.TaiKhoan);
            if (loginUser == null)
            {
                ModelState.AddModelError("", "Dang nhap that bai");
                return View(model);
            }
            else
            {
                //Kiem tra ma MD5 cua pass hien tai co khop voi MD5 cua pass da luu ko
                SHA256 hashMethod = SHA256.Create();

                if (Util.Cryptography.VeryfyHash(hashMethod, model.MatKhau, loginUser.MatKhau))
                {
                    //Luu trang thai user
                    CurrentUser = loginUser.TaiKhoan;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap that bai");
                    return View(model);
                }
            }
        }
        return View(model);
    }*/



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("TaiKhoan,MatKhau")] TbTaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                SHA256 hashMethod = SHA256.Create();
                model.MatKhau = Util.Cryptography.GetHash(hashMethod, model.MatKhau);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));

            }
            return View(model);
        }
        public IActionResult Logout()
        {
            CurrentUser = "";
            return RedirectToAction("Login");
        }
    }
}
