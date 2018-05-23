using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class Contract_Info
    {
        public decimal Contract_Id { get; set; }
        public string Contract_Code { get; set; }
        public string Contract_Name { get; set; }

        public decimal Status { get; set; }
        public string Status_Name { get; set; }

        public decimal Estate_Id { get; set; }
        public string Estate_Code { get; set; }
        public string Estate_Name { get; set; }
        public decimal Object_Id { get; set; }
        public string Object_Name { get; set; }

        public decimal Object_Type { get; set; }
        public decimal Contract_Type { get; set; }
        public string Contract_Type_Name { get; set; }

        public decimal Price { get; set; }
        public decimal Fee { get; set; }
        public decimal Currency { get; set; }

        public decimal Fee_Status { get; set; }
        public string Fee_Status_Name { get; set; }

        public DateTime Contract_FromDate { get; set; }
        public DateTime Contract_ToDate { get; set; }
        public decimal Term { get; set; }
        public DateTime Contract_Date { get; set; }
        public decimal Pay_Count { get; set; }
        public decimal FeeOnePay { get; set; }

        public string Created_By { get; set; }
        public string Modifi_By { get; set; }

        public DateTime Modifi_Date { get; set; }
        public DateTime Created_Date { get; set; }

        public string Users { get; set; }
        public string Representive { get; set; }
        public DateTime Contract_ToDate_Ex { get; set; }

        public decimal Number_Extend { get; set; }
        //public decimal Fee_Vnd { get; set; }
    }
}
