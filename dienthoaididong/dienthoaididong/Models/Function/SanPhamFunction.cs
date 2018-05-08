using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dienthoaididong.Models.Entities;


namespace dienthoaididong.Models.Function
{
    public class SanPhamFunction
    {
        dienthoai db = null;      
        public SanPhamFunction()
        {
            db = new dienthoai();
        }
        //đưa ra sản phẩm
        public IQueryable<sanpham> sanphams
        {
            get { return db.sanphams; }
        }

        //Find tìm kiếm
        public sanpham FindEntity(int ma_sp)
        {
            sanpham sp = db.sanphams.Find(ma_sp);
            return sp;
        }

    }
}