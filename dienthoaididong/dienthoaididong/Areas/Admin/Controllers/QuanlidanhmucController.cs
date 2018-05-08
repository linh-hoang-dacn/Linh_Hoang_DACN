using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dienthoaididong.Models.Entities;

namespace dienthoaididong.Areas.Admin.Controllers
{
    public class QuanlidanhmucController : Controller
    {
        //
        // GET: /Admin/Quanlidanhmuc/
       dienthoai db = new dienthoai();
        public ActionResult Index()
        {
            return View(db.theloaisps.ToList());
        }

        [ChildActionOnly]
        //public ActionResult MenuTrai()
        //{

        //    return PartialView(new DanhMucFunction().DanhMucs.ToList<theloaisp>());
        //}
        ////
        // GET: /DanhMuc/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DanhMuc/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DanhMuc/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DanhMuc/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /DanhMuc/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /DanhMuc/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DanhMuc/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
