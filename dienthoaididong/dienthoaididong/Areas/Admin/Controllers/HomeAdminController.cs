using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dienthoaididong.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            //kiểm tra đăng nhập
            if (Session["TaikhoanAdmin"] == null || Session["TaikhoanAdmin"].ToString() == "")
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

    }
}
