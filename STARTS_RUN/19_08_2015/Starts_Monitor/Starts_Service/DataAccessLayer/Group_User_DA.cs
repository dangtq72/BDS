using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class Group_User_DA
    {
        public DataSet GroupUser_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];
                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Group_UserGetAll", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        /// <summary>
        /// xoa GroupUser theo id
        /// </summary>
        public bool GroupUser_Delete(decimal id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Group_User_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// update theo id GroupUser
        /// </summary>
        public bool GroupUser_Update(decimal id, string p_name,decimal p_group_type,string p_note)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[4];

                int i = 0;
                spParameter[i] = new SqlParameter("@Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_name;

                i++;
                spParameter[i] = new SqlParameter("@Group_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_group_type;

                i++;
                spParameter[i] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_note;

                i++;
                spParameter[i] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Group_User_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal GroupUser_Insert(string p_name, decimal p_group_type, string p_note)
        {
            try
            {
                decimal _id = -1;
                SqlParameter[] spParameter = new SqlParameter[4];

                int i = 0;
                spParameter[i] = new SqlParameter("@Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_name;

                i++;
                spParameter[i] = new SqlParameter("@Group_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_group_type;

                i++;
                spParameter[i] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_note;

                i++;
                spParameter[i] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Group_User_Insert", spParameter);

                return Convert.ToDecimal(spParameter[i].Value);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

    }
}
