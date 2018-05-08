using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dienthoaididong.Models.Entities;

namespace dienthoaididong.Models.Function
{
    public class DanhMucFunction
    {
        dienthoai db = null;
        public DanhMucFunction()
        {
            db = new dienthoai();
        }
        //đưa ra sản phẩm
        public IQueryable<theloaisp> theloais
        {
            get { return db.theloaisps; }
        }
        public theloaisp FindEntity(string theloai_id)
        {
            theloaisp theloai = db.theloaisps.Find(theloai_id);
            return theloai;
        }
    }
}