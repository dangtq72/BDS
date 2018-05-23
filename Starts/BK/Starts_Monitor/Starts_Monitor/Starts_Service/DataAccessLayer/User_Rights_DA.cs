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
    public class User_Rights_DA
    {
        public void User_Rights_DelByUser(string p_user_name)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_user_name;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_DelUserRight_ByUser", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public void Delete_User_Right_By_UserFuntion(string p_user_name, string p_fun_id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@username", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_user_name;

                spParameter[1] = new SqlParameter("@fun_id", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_fun_id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_DelUserRight_ByUser", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public int User_Rights_Insert_Barth(List<User_RightsInfo> _list)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigInfo.ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = "user_rights";

                    bulkCopy.ColumnMappings.Add("User_Name", "User_Name");
                    bulkCopy.ColumnMappings.Add("funcid", "funcid");
                    bulkCopy.ColumnMappings.Add("authcode", "authcode");

                    using (var datareader = new ObjectDataReader<User_RightsInfo>(_list))
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

        public DataSet User_Rights_GetByUser(decimal p_group_id, string p_username)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@p_group_id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_group_id;

                spParameter[1] = new SqlParameter("@p_username", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_username;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_user_rights_getbyUser", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}
