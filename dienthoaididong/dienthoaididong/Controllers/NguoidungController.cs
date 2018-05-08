using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;
using dienthoaididong.Models.Function;


namespace dienthoaididong.Controllers
{
    public class NguoidungController : Controller
    {
        //
        // GET: /Nguoidung/
        dienthoai db = new dienthoai();

        #region //Đăng ký

        [HttpGet] //phương thức truyền 
        public ActionResult Dangky()
        {        
            return View();
        }
        [HttpPost]//pt truyền các giá trị value

        [ValidateAntiForgeryToken]
        public ActionResult Dangky(khachhang kh, string url)
        {
            if (ModelState.IsValid)
            {
                //cho dữ liệu vào databse ->table khachhang
                db.khachhangs.Add(kh);
                //lưu vào cơ sở dữ liệu
                db.SaveChanges();
                Session["Taikhoan"] = kh;
                Session["tentaikhoan"] = kh.khachhang_taikhoan;
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        #endregion

        #region //Đăng nhập
        public ActionResult Dangnhap()
        {
            Session["Giohang"] = null;
            Session["Taikhoan"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection f,string url)
        {
            
            string s_taikhoan = f["txttaikhoan"].ToString();
            string s_matkhau = f["txtmatkhau"].ToString();
            khachhang kh = db.khachhangs.SingleOrDefault(n => n.khachhang_taikhoan == s_taikhoan && n.khachhang_matkhau == s_matkhau);
            if (kh != null)
            {
                ViewBag.Thongbao = "Đăng nhập thành công!";
                //luu lại tài khoản
                Session["Taikhoan"] = kh;
                Session["tentaikhoan"] = s_taikhoan;
                return RedirectToAction("Index","Home");
            }

            ViewBag.Thongbao = " Tên tài khoản hoặc mật khẩu không đúng!!!";
            return View();
        }


        //xem thông tin cá nhân
        #endregion

        #region //Thông tin cá nhân
       
        public ActionResult Details()
        {
            if (Session["Taikhoan"] == null )
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Session["Taikhoan"]);
        }

        #endregion

        #region  //chỉnh sửa khachhang
        [HttpGet]
        public ActionResult Edit(string ma_kh)
        {
            if (Session["Taikhoan"] == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Session["Taikhoan"]);
        }

        [HttpPost]
        //[ValidateInput(false)]  //thuộc tính 
        public ActionResult Edit(khachhang kh)
        {
            
            if (ModelState.IsValid)
            {
                //thực hiện cập nhật trong model
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Session["Taikhoan"] = kh;
            }
            return RedirectToAction("Details","Nguoidung");
        }

        #endregion

    }
}
