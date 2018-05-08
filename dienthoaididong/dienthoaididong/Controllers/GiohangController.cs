using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;

namespace dienthoaididong.Controllers
{
    public class GiohangController : Controller
    {
        //
        // GET: /Giohang/
        dienthoai db = new dienthoai();

        // xây dựng phương thức

        #region Lấy Giỏ hàng 
        //Lấy giỏ hàng từ Session[Giohang]
        public List<Giohang> LayGiohang() //kiểu trả về là 1 list
        {
            //tạo listgiohang
            //phương thức as-> nếu Session["Giohang"] tồn tại thì ép kiểu. Không thì sẽ trả về null
            List<Giohang> listgiohang = Session["Giohang"] as List<Giohang>;//ép kiểu
            if (listgiohang == null)
            {
                //nếu giỏ hàng không tồn tại thì mình tiến hành khởi tạo list giỏ hàng 
                listgiohang = new List<Giohang>();              
                Session["Giohang"] = listgiohang;
            }
            return listgiohang;
        }
        #endregion

        #region  thêm giỏ hàng
        public ActionResult ThemGiohang(int ma_sp, string url)
        {
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == ma_sp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //khởi tạo giỏ hàng & lấy ra session giohang
            List<Giohang> listGiohang = LayGiohang();

            //kiểm tra sp đã tồn tại trong session[Giohang] hay chưa?
            Giohang gh_sp = listGiohang.Find(n => n.sanpham_id == ma_sp);
            if (gh_sp == null)
            {
                gh_sp = new Giohang(ma_sp);
                //add sản phẩm mới vào list
                listGiohang.Add(gh_sp);
                return Redirect(url);
            }
            else
            {
                gh_sp.soluong_sp++;
                return Redirect(url);
            }
        }
        #endregion

        #region cập nhật giỏ hàng
        public ActionResult CapnhatGiohang(int ma_sp, FormCollection f)
        {
            //kiểm tra mã sản phẩm 
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == ma_sp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //lấy giỏ hàng từ session
            List<Giohang> listGiohang = LayGiohang();

            //kiểm tra sản phẩm có tồn tại  trong session
            Giohang gh_sp = listGiohang.SingleOrDefault(n => n.sanpham_id == ma_sp);
            //nếu tồn tại cho sửa
            if (gh_sp != null)
            {
                gh_sp.soluong_sp = int.Parse(f["txtSoluong"].ToString());
               
            }

            //kh gửi biến model ,chỉ gọi về nỏ nên kh trả về view
            //lấy giá trị từ giỏ hàng
            return RedirectToAction("Giohang");

        }
#endregion

        #region  xóa giỏ hàng
        public ActionResult XoaGiohang(int ma_sp)
        {
            //kiểm tra mã sản phẩm 
            sanpham sp = db.sanphams.SingleOrDefault(n => n.sanpham_id == ma_sp);
            //nếu ghép sai mã sản phẩm thì trả về trang lỗi
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng từ session
            List<Giohang> listGiohang = LayGiohang();
            //kiểm tra sản phẩm có tồn tại  trong session
            Giohang gh_sp = listGiohang.SingleOrDefault(n => n.sanpham_id == ma_sp);
            //nếu tồn tại cho sửa
            if (gh_sp != null)
            {
                listGiohang.RemoveAll(n => n.sanpham_id == ma_sp);


            }
            if (listGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Giohang");

        }
#endregion

        #region Xây dựng trang giỏ hàng --view

        public ActionResult Giohang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Giohang> listGiohang = LayGiohang();
            return View(listGiohang);
        }
          #endregion 

        #region tính tổng số lượng 
        public int tongSL()
        {
            int tong_sl = 0;
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang != null)
            {
                tong_sl = listGiohang.Sum(n => n.soluong_sp);
            }
            return tong_sl;
        }
        #endregion

        #region tính tiền
        public int Tongtien()
        {
            int tongtien = 0;
            List<Giohang> listGiohang = Session["Giohang"] as List<Giohang>;
            if (listGiohang != null)
            {
                tongtien = listGiohang.Sum(n => n.thanhtien);
            }
            return tongtien;
        }
        #endregion

        #region Tạo partial Gior hàng --view
        public ActionResult GiohangPartial()
        {
            if (tongSL() == 0)
            {
                return PartialView();
            }
            ViewBag.Tongsoluong = tongSL();
            ViewBag.Tongtien = Tongtien();
            return PartialView();
        }
        #endregion

        #region Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGiohang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Giohang> listGiohang = LayGiohang();
            return View(listGiohang);
        }

        #endregion

        #region Đặt hàng
        [HttpPost]
        public ActionResult Dathang()
        {
            //kiểm tra đăng nhập
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }

            //Kiểm tra Hóa đơn
            if (Session["Giohang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //thêm đơn đặt hàng
            hoadon hd = new hoadon();
            khachhang kh = (khachhang)Session["Taikhoan"];
            List<Giohang> gh = LayGiohang();
            hd.khachhang_id = kh.khachhang_id;
            hd.ngaydat = DateTime.Now;

            db.hoadons.Add(hd);

            //lưu vào hóa đơn
            db.SaveChanges();

            //thêm chi tiết hóa đơn 
            foreach (var item in gh)
            {
                chitiethoadon cthd = new chitiethoadon();
                cthd.hoadon_id = hd.hoadon_id;
                cthd.sanpham_id = item.sanpham_id;
                cthd.soluong = item.soluong_sp;
                cthd.dongia = (Int32)item.gia_sp;
                db.chitiethoadons.Add(cthd);
            }
            //lưu vào chi tiết hóa đơn
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }




        #endregion
    }
}
