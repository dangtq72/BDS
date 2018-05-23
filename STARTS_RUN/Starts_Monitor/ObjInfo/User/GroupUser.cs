using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo
{
    public class GroupUserInfo
    {
        private decimal _id;
        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private decimal _group_type;
        public decimal Group_Type
        {
            get { return _group_type; }
            set { _group_type = value; }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
    }
}
