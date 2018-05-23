using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    public class FunctionsInfo
    {
        private string _name;
        private string _id;
        private string _prid;
        private decimal _lev;
        private string _last;
        private decimal _moduleid;
        private string _status;
        private string _objname;
        private string _shortcut;
        private string _notes;
        private decimal _deleted;
        private string _created_by;
        private DateTime _created_date;
        private string _modified_by;
        private DateTime _modified_date;
        private string _system_type;
        private string _name_eng;
        private decimal _ofgroup;
        private System.Windows.Visibility _Show;
        private System.Windows.Media.Brush _br_n;
        private string _status_name;


        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string prid
        {
            get { return _prid; }
            set { _prid = value; }
        }
        public decimal lev
        {
            get { return _lev; }
            set { _lev = value; }
        }
        public string last
        {
            get { return _last; }
            set { _last = value; }
        }
        public decimal moduleid
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string objname
        {
            get { return _objname; }
            set { _objname = value; }
        }
        public string shortcut
        {
            get { return _shortcut; }
            set { _shortcut = value; }
        }
        public string notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        public decimal deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }
        public string created_by
        {
            get { return _created_by; }
            set { _created_by = value; }
        }
        public DateTime created_date
        {
            get { return _created_date; }
            set { _created_date = value; }
        }
        public string modified_by
        {
            get { return _modified_by; }
            set { _modified_by = value; }
        }
        public DateTime modified_date
        {
            get { return _modified_date; }
            set { _modified_date = value; }
        }

        public string System_Type
        {
            get { return _system_type; }
            set { _system_type = value; }
        }

        public string Name_Eng
        {
            get { return _name_eng; }
            set { _name_eng = value; }
        }

        public decimal ofgroup
        {
            get { return _ofgroup; }
            set { _ofgroup = value; }
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

        public string Status_Name
        {
            get { return _status_name; }
            set { _status_name = value; }
        }
    }
}
