using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class Customer_Info
    {
        public decimal Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Identity_Card { get; set; }
        public string Address { get; set; }
        public string Tax_Code { get; set; }
        public decimal Customer_Type { get; set; }
        public decimal Is_Person { get; set; }
        public string Position { get; set; }

        public string Customer_Type_Name { get; set; }

        public string Created_By { get; set; }
        public string Modifi_By { get; set; }

        public DateTime Modifi_Date { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
