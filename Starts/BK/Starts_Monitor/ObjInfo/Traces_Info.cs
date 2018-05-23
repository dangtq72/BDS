using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjInfo
{
    //Cac class dung cho trace log
    public class TraceInfo
    {
        protected decimal _Trace_Id;
        protected string _Trace_Object;
        protected string _Trace_Procedure;
        protected string _Trace_Value;
        protected string _Trace_User;
        protected DateTime _Trace_Datetime;

        // Trace_Id
        public decimal Trace_Id
        {
            get { return _Trace_Id; }
            set { _Trace_Id = value; }
        }

        //Trace_Object
        public string Trace_Object
        {
            get { return _Trace_Object; }
            set { _Trace_Object = value; }
        }

        //Trace_Procedure
        public string Trace_Procedure
        {
            get { return _Trace_Procedure; }
            set { _Trace_Procedure = value; }
        }

        //Trace_Value
        public string Trace_Value
        {
            get { return _Trace_Value; }
            set { _Trace_Value = value; }
        }

        //Trace_User
        public string Trace_User
        {
            get { return _Trace_User; }
            set { _Trace_User = value; }
        }

        //Trace_Datetime
        public DateTime Trace_Datetime
        {
            get { return _Trace_Datetime; }
            set { _Trace_Datetime = value; }
        }
    }
}
