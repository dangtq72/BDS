using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class Extend_Contract_Info
    {
        public decimal Contract_Id { get; set; }
        public DateTime Contract_FromDate { get; set; }
        public DateTime Contract_ToDate { get; set; }
        public DateTime Extend_Date { get; set; }
        public decimal Term { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeOnePay { get; set; }
        public decimal Price { get; set; }
        public decimal Number_Extend { get; set; }
        public decimal Fee_Status { get; set; }
        public decimal Extend_Contract_Id { get; set; }
    }
}
