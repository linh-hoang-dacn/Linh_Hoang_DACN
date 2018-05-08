using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;
using dienthoaididong.Models.Function;

using System.IO;
namespace dienthoaididong.Areas.Admin.Controllers
{
    
    public class QuanlisanphamController : Controller
    {
        //
        // GET: /Admin/Quanlisanpham/
        dienthoai db = new dienthoai();

        #region //đưa sản phẩm ra
     
        public ActionResult Index()
        {      
            return View(db.sanphams.Where(n=>n.moi==1).ToList());
        }
        public ActionResult Dienthoai()
        {
            return View(db.sanphams.Where(n=>n.style == 0).ToList());
        }
        public ActionResult Phukien()
        {
            return View(db.sanphams.Where(n => n.style == 1).ToList());
        }

        #endregion

        #region //thêm mới sản phẩm

        [HttpGet] //tạo trang để thêm
            //tạo action Themmoi
        public ActionResult Themmoi()
        {
            //đưa dữ liệu vào dropdownlist
            ViewBag.theloai_id = new SelectList(db.theloaisps.ToList(),"theloai_id","theloai_name");
            return View();
        }
        //pt này load ảnh + post dữ liệu lên
        [HttpPost]
        //[ValidateInput(false)]  //thuộc tính 
           
        public ActionResult Themmoi(sanpham sp, HttpPostedFileBase UrlAnh)
        {

            ViewBag.theloai_id = new SelectList(db.theloaisps.ToList(), "theloai_id", "theloai_name");
            //kiểm tra đường dẫn ảnh bìa
            if (UrlAnh == null)
            {
                ViewBag.Thongbao = "Chọn hình ảnh";
                return View();
            }

          //thêm vào cơ sở dữ liệu
            //kiểm tra sự tồn tại bên csdl

            if (ModelState.IsValid)
            {
                //lưu tên file
                var fileName = Path.GetFileName(UrlAnh.FileName);
               
                //lưu đường dẫn
                var path = Path.Combine(Server.MapPath("~/Hinhanh/hinhanhsp"), fileName);
                
                //kiểm tra hình ảnh đã tồn tại hay chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    UrlAnh.SaveAs(path);
                }
                sp.hinhanh_sp = UrlAnh.FileName;
                db.sanphams.Add(sp);
                db.SaveChanges();
            }

            return View();
        }
        #endregion

        #region  //chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Edit(int id)
        {
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.theloai_id = new SelectList(db.theloaisps.ToList(), "theloai_id", "theloai_name",sp.theloai_id);
            return View(sp);
        }

        [HttpPost]
        //[ValidateInput(false)]  //thuộc tính 
        public ActionResult Edit(sanpham sp)
        {
            //c1: tạo đối tượng
            //sanpham sp1 = db.sanphams.SingleOrDefault(n => n.sanpham_id = sp.sanpham_id);
            //sp1.sanpham_name = sp.sanpham_name;
            //db.SaveChanges();

            //c2:
            if (ModelState.IsValid)
            {
                
                //thực hiện cập nhật trong model
                db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            ViewBag.theloai_id = new SelectList(db.theloaisps.ToList(), "theloai_id", "theloai_name",sp.theloai_id);

            return RedirectToAction("Index");





        }

        #endregion

        #region//hiển thị chi tiết sản phẩm

        public ActionResult Details(int id)
        {
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.theloai_id = new SelectList(db.theloaisps.ToList(), "theloai_id", "theloai_name", sp.theloai_id);
            return View(sp);
        }
        #endregion

        #region//Xóa sản phẩm
        [HttpGet]
        public ActionResult Delete(int id)
        {
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.sanphams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion










    }
}
