using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;
using dienthoaididong.Models.Function;


namespace dienthoaididong.Controllers
{
    public class DanhmucController : Controller
    {
        //
        // GET: /Danhmuc/
        dienthoai db = new dienthoai();

        public PartialViewResult danhmucdienthoai()
        {
            return PartialView(db.theloaisps.Where(n => n.phukien == 0).ToList());
        }
        public PartialViewResult danhmucphukien()
        {
            return PartialView(db.theloaisps.Where(n => n.phukien == 1).ToList());
        }

    }
}
