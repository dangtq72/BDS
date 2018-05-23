using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class Traces_Log_DA
    {
        public DataSet trace_Search(string p_object, string p_user, string p_frmdate, string p_todate)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[4];
                spParameter[0] = new SqlParameter("@p_object", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_object;

                spParameter[1] = new SqlParameter("@p_user", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_user;

                spParameter[2] = new SqlParameter("@p_frmdate", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_frmdate;

                spParameter[3] = new SqlParameter("@p_todate", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_todate;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_traces_log_search", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public void Trace_Insert(string trace_object, string trace_procedure, string trace_value, string trace_user, DateTime trace_datetime)
        {

            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];
                spParameter[0] = new SqlParameter("@TRACE_OBJECT", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = trace_object;

                spParameter[1] = new SqlParameter("@TRACE_PROCEDURE", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = trace_procedure;

                spParameter[2] = new SqlParameter("@TRACE_VALUE", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = trace_value;

                spParameter[3] = new SqlParameter("@TRACE_USER", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = trace_user;

                spParameter[4] = new SqlParameter("@TRACE_DATETIME", SqlDbType.Date);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = trace_datetime;

                SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_traces_log_insert", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }

        }
    }
}
