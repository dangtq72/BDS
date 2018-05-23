using System;
using System.Collections.Generic;
using System.Data;
using MemoryData;
using System.Text;
using System.Data.SqlClient;

namespace Starts_Service
{
    public class User_DA
    {
        public DataSet User_Login(string p_user_name, string p_pass)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_user_name;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_pass;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Login", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet User_Get_All()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];
                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Get_All", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool User_Update_Last_Login(decimal p_User_Id, DateTime p_last)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                int i = 0;
                spParameter[i] = new SqlParameter("@Last_Login", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_last;

                i++;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Update_Last", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool User_Update_Pass(decimal p_User_Id, string p_pass)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                int i = 0;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Id;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_pass;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Update_Pass", spParameter);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool User_Delete(decimal p_User_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_User_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal User_Insert(string p_User_Name, string p_pass, decimal p_user_type, string p_full_name, decimal p_status,
            string p_phone, decimal p_group_id)
        {
            try
            {
                decimal _id = -1;

                SqlParameter[] spParameter = new SqlParameter[8];

                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Name;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_pass;

                i++;
                spParameter[i] = new SqlParameter("@User_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_user_type;

                i++;
                spParameter[i] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_full_name;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_status;

                i++;
                spParameter[i] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_phone;

                i++;
                spParameter[i] = new SqlParameter("@Group_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_group_id;

                i++;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Insert", spParameter);

                return Convert.ToDecimal(spParameter[i].Value);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public bool User_Update(decimal p_User_Id, string p_User_Name, string p_pass, decimal p_user_type, string p_full_name, decimal p_status,
            string p_phone, decimal p_group_id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[8];

                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Name;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_pass;

                i++;
                spParameter[i] = new SqlParameter("@User_Type", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_user_type;

                i++;
                spParameter[i] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_full_name;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_status;

                i++;
                spParameter[i] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_phone;

                i++;
                spParameter[i] = new SqlParameter("@Group_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_group_id;

                i++;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_User_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public DataSet Send_Users_Get_MenuItem(string p_user_name)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_user_name;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_users_getMenuItem", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}
