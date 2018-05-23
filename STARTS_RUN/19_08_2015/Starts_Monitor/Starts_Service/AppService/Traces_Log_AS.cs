using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ZetaCompressionLibrary;

namespace Starts_Service
{
    public partial interface IAppService
    {
        [OperationContract()]
        byte[] trace_Search(string p_object, string p_user, string p_frmdate, string p_todate);

        [OperationContract()]
        void Trace_Insert(string Trace_Object, string Trace_Procedure, string strvalue, string Trace_User, System.DateTime dateTime);
    }

    public partial class AppService : IAppService
    {
        public byte[] trace_Search(string p_object, string p_user, string p_frmdate, string p_todate)
        {
            try
            {
                Traces_Log_DA _TraceDA = new Traces_Log_DA();
                DataSet ds = _TraceDA.trace_Search(p_object, p_user, p_frmdate, p_todate);
                return CompressionHelper.CompressDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public void Trace_Insert(string Trace_Object, string Trace_Procedure, string strvalue, string Trace_User, System.DateTime dateTime)
        {
            try
            {
                Traces_Log_DA _TraceDA = new Traces_Log_DA();
                _TraceDA.Trace_Insert(Trace_Object, Trace_Procedure, strvalue, Trace_User, dateTime);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

    }
}
