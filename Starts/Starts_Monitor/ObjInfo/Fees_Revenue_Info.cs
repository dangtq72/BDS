using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class Fees_Revenue_Info
    {
        public decimal Fee_Id { get; set; }

        public decimal Contract_Id { get; set; }
        public decimal Object_Id { get; set; }
        public decimal Object_Type { get; set; }

        public decimal Fee { get; set; }
        public decimal Fee_Expected { get; set; }
        public decimal Debit_Amount { get; set; }

        public decimal Number_Payment { get; set; }

        public decimal Currency { get; set; }
        public decimal Pay_Status { get; set; }
        public string Pay_Status_Name { get; set; }

        public DateTime Pay_Date { get; set; }
        public DateTime Pay_Date_Expected { get; set; }
        public DateTime Date_Of_Bill { get; set; }

        public decimal Is_Extend { get; set; }
        public decimal Fee_Vnd { get; set; }
    }
}
