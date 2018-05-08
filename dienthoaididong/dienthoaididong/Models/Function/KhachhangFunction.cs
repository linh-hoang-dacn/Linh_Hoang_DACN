using dienthoaididong.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dienthoaididong.Models.Function
{
    public class KhachhangFunction
    {
        dienthoai db = null;
        public KhachhangFunction()
        {
            db = new dienthoai();
        }
        //đưa ra sản phẩm
        public IQueryable<khachhang> khachangs
        {
            get { return db.khachhangs; }
        }

        //Find tìm kiếm
        public khachhang FindEntity(string name)
        {
            khachhang kh = db.khachhangs.Find(name);
            return kh;
        }
    }
}