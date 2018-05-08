using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;

namespace dienthoaididong.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        dienthoai db = new dienthoai();
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Dangnhap(FormCollection f,string url )
        {
            
           
            string s_taikhoan = f["txtEmail"].ToString();
            string s_matkhau = f["txtPassword"].ToString();
            User ad = db.Users.SingleOrDefault(n => n.Taikhoan == s_taikhoan && n.Matkhau == s_matkhau);
            if (ad != null)
            {
                ViewBag.Thongbao = "Đăng nhập thành công!";
                //luu lại tài khoản
                Session["TaikhoanAdmin"] = ad;
                Session["tenadmin"] = s_taikhoan;
                return RedirectToAction("Index", "HomeAdmin");
                
            }
            ViewBag.Thongbao = " Tên tài khoản hoặc mật khẩu không đúng!!!";
            return View();
        }       

    }
}
