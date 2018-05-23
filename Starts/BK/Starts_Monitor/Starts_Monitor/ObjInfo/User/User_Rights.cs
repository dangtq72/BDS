using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjInfo
{

    public class User_RightsInfo
    {

        private decimal _id;
        private decimal _userid;
        private string _funcid;
        private decimal _authcode;

        public decimal id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public string User_Name { get; set; }

        public string funcid
        {
            get { return _funcid; }
            set { _funcid = value; }
        }

        public decimal authcode
        {
            get { return _authcode; }
            set { _authcode = value; }
        }
    }

    public class User_FunctionsInfo
    {
        private string _functionId;
        private decimal _groupId;
        private string _prid;
        //private decimal _right;
        private string _name;
        private decimal _lev;
        private string _last;
        private decimal _authcode;

        private System.Windows.Visibility _Show;
        private decimal _Full_Right;
        private System.Windows.Media.Brush _br_n;

        public User_FunctionsInfo()
        {

        }

        public User_FunctionsInfo(User_FunctionsInfo p_copy)
        {
            this._functionId = p_copy.functionId;
            this._groupId = p_copy._groupId;

            this._authcode = p_copy._authcode;
            this._name = p_copy._name;
            this._lev = p_copy._lev;
            this._prid = p_copy._prid;
            this._last = p_copy._last;
            this._Show = p_copy._Show;
            this._Full_Right = p_copy._Full_Right;
            this._br_n = p_copy._br_n;
        }

        public string functionId
        {
            get { return _functionId; }
            set { _functionId = value; }
        }

        public decimal groupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string prid
        {
            get { return _prid; }
            set { _prid = value; }
        }

        public string last
        {
            get { return _last; }
            set { _last = value; }
        }

        public decimal authcode
        {
            get { return _authcode; }
            set { _authcode = value; }
        }

        public decimal Full_Right
        {
            get { return _Full_Right; }
            set { _Full_Right = value; }
        }

        public System.Windows.Visibility Show
        {
            get
            {
                return _Show;
            }
            set { _Show = value; }
        }

        public System.Windows.Media.Brush Br_N
        {
            get
            {
                return _br_n;
            }
            set { _br_n = value; }
        }
    }
}
