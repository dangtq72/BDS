using MemoryData;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class Function_Group_DA
    {
        public DataSet Function_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];
                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Function_GetAll", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Function_Group_DelByGroup(decimal p_group_id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@group_id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_group_id;

                  SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, System.Data.CommandType.StoredProcedure, "proc_Function_Group_Delete", spParameter);
                  return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public DataSet Get_Function_ByGroup(decimal p_group_id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@group_id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_group_id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_get_right_by_group_id", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public int Function_Group_Insert_Batch(List<Function_GroupInfo> _list)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigInfo.ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = "functions_group";

                    bulkCopy.ColumnMappings.Add("group_id", "group_id");
                    bulkCopy.ColumnMappings.Add("functionid", "functionid");

                    using (var datareader = new ObjectDataReader<Function_GroupInfo>(_list))
                    {
                        bulkCopy.WriteToServer(datareader);
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
