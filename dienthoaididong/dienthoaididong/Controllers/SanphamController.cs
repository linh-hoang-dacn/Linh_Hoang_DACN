using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;
using dienthoaididong.Models.Function;


namespace dienthoaididong.Controllers
{
    public class SanphamController : Controller
    {
        //
        // GET: /Sanpham/
        public ActionResult Index()
        {
            return View();
        }
        //đưa ra sản phẩm moi
        public PartialViewResult dienthoaimoi()
        {
            var model = new SanPhamFunction().sanphams.Where(n => n.moi == 1 && n.style == 0).ToList();
            return PartialView(model);

        }
        //xem chi tiết sản phẩm
        public ActionResult xemchitiet(int masp)
        {
            sanpham sp = new SanPhamFunction().FindEntity(masp);
            return View(sp);
        }
        //đưa ra điện thoại liên quan
        public PartialViewResult dienthoailienquan(string theloai_id)
        {
            var model = new SanPhamFunction().sanphams.Where(n=>n.theloai_id==theloai_id).ToList();
            return PartialView(model);
        }
        //đưa ra điện thoại theo mục
        public ActionResult sanphamtheomuc(string id_theloai)
        {
            //lay ra the loai co theloai_id la id_theloai
            theloaisp theloai = new DanhMucFunction().FindEntity(id_theloai);

            //dua ra list san pham co theloai la id_theloai
           var model = new SanPhamFunction().sanphams.Where(n => n.theloai_id == id_theloai).ToList();
           
            if (model == null)
            {
                ViewBag.danhmuc = "Đang cập nhật";
                return null;               
            }
            else
            {
                ViewBag.danhmuc = theloai.theloai_name;
                return View(model);
            }
          
        }
    }
}
