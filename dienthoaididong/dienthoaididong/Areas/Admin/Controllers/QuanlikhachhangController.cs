using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;

namespace dienthoaididong.Areas.Admin.Controllers
{
    public class QuanlikhachhangController : Controller
    {
        //
        // GET: /Admin/Quanlikhachhang/

        dienthoai db = new dienthoai();
        public ActionResult Index()
        {
            return View(db.khachhangs);
        }

        #region //thêm mới khách hàng

        [HttpGet] //tạo trang để thêm
        //tạo action Themmoi
        public ActionResult Themmoi()
        {
            //đưa dữ liệu vào dropdownlist
            return View();
        }
        //pt này load ảnh + post dữ liệu lên
        [HttpPost]
        public ActionResult Themmoi(khachhang kh)
        {
            db.khachhangs.Add(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }     
        #endregion


        #region  //chỉnh sửa khachhang
        [HttpGet]
        public ActionResult Edit(int makh)
        {
            khachhang kh = db.khachhangs.SingleOrDefault(n => n.khachhang_id == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }

        [HttpPost]
        //[ValidateInput(false)]  //thuộc tính 
        public ActionResult Edit(khachhang kh)
        {
            //c1: tạo đối tượng
            //sanpham sp1 = db.sanphams.SingleOrDefault(n => n.sanpham_id = sp.sanpham_id);
            //sp1.sanpham_name = sp.sanpham_name;
            //db.SaveChanges();

            //c2:
            if (ModelState.IsValid)
            {
                //thực hiện cập nhật trong model
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
             
            }
            return RedirectToAction("Index");
        }

        #endregion
      
        #region  //xem chi tiet khach hang
          [HttpGet]
        public ActionResult Details(int makh)
        {
            khachhang kh = db.khachhangs.SingleOrDefault(n => n.khachhang_id == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
      
        #endregion

        #region //xóa khách hàng
        [HttpGet]
        public ActionResult Delete(int makh)
        {
            khachhang kh = db.khachhangs.SingleOrDefault(n => n.khachhang_id == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int makh)
        {
            khachhang kh = db.khachhangs.SingleOrDefault(n => n.khachhang_id == makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.khachhangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
