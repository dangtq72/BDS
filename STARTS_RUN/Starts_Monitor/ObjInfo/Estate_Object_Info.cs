using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class Estate_Object_Info
    {
        public decimal Estate_Id { get; set; }
        public string Estate_Code { get; set; }
        public decimal Building_Id { get; set; }
        public string Building_Name { get; set; }
        public string Estate_Name { get; set; }
        public decimal Estate_Type { get; set; }
        public string Estate_Type_Name { get; set; }

        public string Area { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public decimal Status { get; set; }
        public string Status_Name { get; set; }

        public string Object_Name { get; set; }
        public decimal Contract_Type { get; set; }
    }
}
