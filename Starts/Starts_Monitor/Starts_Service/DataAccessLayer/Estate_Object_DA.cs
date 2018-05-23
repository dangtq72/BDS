using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Starts_Service
{
    public class Estate_Object_DA
    {

        public DataSet Estate_Object_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_All", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Estate_Object_GetStatus(decimal p_status)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_status;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_GetByStatus", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Estate_Object_GetType(decimal p_Estate_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Estate_Type", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Type;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_GetByStatus", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Estate_Object_GetById(decimal p_Estate_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_GetId", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Estate_Object_GetByObject(decimal p_Estate_Id, decimal p_Object_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Id;

                spParameter[0] = new SqlParameter("@Object_Type", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Object_Type;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_GetByObject", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Estate_Object_Update(decimal p_Estate_Id, string p_Estate_Name, decimal p_Estate_Type, string p_Area, decimal p_Status, string p_note)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[6];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Id;

                spParameter[1] = new SqlParameter("@Estate_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Estate_Name;

                spParameter[2] = new SqlParameter("@Estate_Type", SqlDbType.Decimal);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Estate_Type;

                spParameter[3] = new SqlParameter("@Area", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Area;

                spParameter[4] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_Status;

                spParameter[5] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[5].Direction = ParameterDirection.Input;
                spParameter[5].Value = p_note;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Estate_Object_Delete(decimal p_Estate_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Estate_Object_Insert(string p_Estate_Name, decimal p_Estate_Type, string p_Area, decimal p_Status, string p_note, string p_Estate_Code, decimal Building_Id)
        {
            try
            {
                decimal _id = -1;

                SqlParameter[] spParameter = new SqlParameter[8];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Output;
                spParameter[0].Value = _id;

                spParameter[1] = new SqlParameter("@Estate_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Estate_Name;

                spParameter[2] = new SqlParameter("@Estate_Type", SqlDbType.Decimal);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Estate_Type;

                spParameter[3] = new SqlParameter("@Area", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Area;

                spParameter[4] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_Status;

                spParameter[5] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[5].Direction = ParameterDirection.Input;
                spParameter[5].Value = p_note;

                spParameter[6] = new SqlParameter("@Estate_Code", SqlDbType.NVarChar);
                spParameter[6].Direction = ParameterDirection.Input;
                spParameter[6].Value = p_Estate_Code;

                spParameter[7] = new SqlParameter("@Building_Id", SqlDbType.Decimal);
                spParameter[7].Direction = ParameterDirection.Input;
                spParameter[7].Value = Building_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_Insert", spParameter);

                return Convert.ToDecimal(spParameter[0].Value);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Check_Exit_EstateInContract(decimal p_Estate_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Check_Exit_EstateInContract", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Estate_Object_Search(string p_Estate_Name, string p_Estate_Type, string p_Status)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[3];
                spParameter[0] = new SqlParameter("@Estate_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Name;

                spParameter[1] = new SqlParameter("@Estate_Type", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Estate_Type;

                spParameter[2] = new SqlParameter("@Status", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Status;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_Search", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Estate_Object_GetCbo(decimal Contract_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Type", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_Type;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_GetCbo", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}
