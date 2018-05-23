using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class User_Info
    {
        public decimal User_Id { get; set; }
        public string User_Name { get; set; }
        public string FullName { get; set; }
        public string Pass { get; set; }
        public DateTime Last_Login { get; set; }

        public int Status { get; set; }
        public int User_Type { get; set; }
        public string Phone { get; set; }

        public decimal Group_Id { get; set; }
        public string Us_Status_Name { get; set; }
        public string Group_Name { get; set; }
    }
}
