using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class Fee_Report_Info
    {
        public string Estate_Name { get; set; }
        public string Estate_Code { get; set; }

        public DateTime Contract_FromDate { get; set; }
        public DateTime Contract_ToDate { get; set; }
        public decimal Currency { get; set; }
        public string Users { get; set; }
        public string Customer_Name { get; set; }

        public decimal PhiMoiGio { get; set; }
        public decimal PhiMoiGio_VND { get; set; }
        public decimal PhiMoiGio_USD { get; set; }

        public DateTime HanChuyenTien { get; set; }
        public decimal TienDaVe { get; set; }
        public decimal TienDaVe_VND { get; set; }
        public decimal TienDaVe_USD { get; set; }

        public decimal TienChuaVe { get; set; }
        public decimal TienChuaVe_VND { get; set; }
        public decimal TienChuaVe_USD { get; set; }

        public decimal Fee_Expected { get; set; }
        public decimal Number_Payment { get; set; }

        public decimal Contract_Id { get; set; }
        public decimal Estate_Id { get; set; }
        public decimal Object_Id { get; set; }
        public string Representive { get; set; }
        public DateTime Contract_ToDate_Ex { get; set; }
        public decimal Price { get; set; }
        public decimal Contract_Type { get; set; }
        public decimal Term { get; set; }
        public decimal Fee_Vnd { get; set; }
    }
}
