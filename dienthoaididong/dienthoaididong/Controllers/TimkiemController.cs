using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;


namespace dienthoaididong.Controllers
{
    public class TimkiemController : Controller
    {
        //
        // GET: /Timkiem/
        dienthoai db = new dienthoai();
        [HttpPost]
        public ActionResult Ketquatimkiem(FormCollection f)
        {
            string tukhoa = f["txtTimkiem"].ToString();
            List<sanpham> listsp = db.sanphams.Where(n => n.sanpham_name.Contains(tukhoa)).ToList();

            //phân trang
            //chưa làm
            if (listsp.Count == 0)
            {
                ViewBag.thongbao = "Không tìm thấy dữ liệu";
                //return View(db.sanphams.OrderBy(n=>n.sanpham_name));
            }

            return View(listsp.OrderBy(n => n.sanpham_name).ToList());
        }


    }
}
