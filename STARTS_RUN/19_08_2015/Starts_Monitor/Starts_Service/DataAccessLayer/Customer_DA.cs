using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class Customer_DA
    {
        public DataSet Customer_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Customer_GetAll", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Customer_GetById(decimal Customer_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Customer_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Customer_ById", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Customer_Check_In_Contract(decimal Customer_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Customer_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_check_exis_customer_in_Contract", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Customer_Delete(decimal Customer_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Customer_Id;

                SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Customer_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Customer_Update(decimal Customer_Id, string Customer_Name, string p_Phone, string p_Fax, string p_Identity_Card,
            string p_Address, string p_Tax_Code, decimal Customer_Type, decimal Is_Person, string Position)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[10];
                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Customer_Id;

                spParameter[1] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Customer_Name;

                spParameter[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Phone;

                spParameter[3] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Fax;

                spParameter[4] = new SqlParameter("@Identity_Card", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_Identity_Card;

                spParameter[5] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[5].Direction = ParameterDirection.Input;
                spParameter[5].Value = p_Address;

                spParameter[6] = new SqlParameter("@Tax_Code", SqlDbType.NVarChar);
                spParameter[6].Direction = ParameterDirection.Input;
                spParameter[6].Value = p_Tax_Code;

                spParameter[7] = new SqlParameter("@Customer_Type", SqlDbType.Decimal);
                spParameter[7].Direction = ParameterDirection.Input;
                spParameter[7].Value = Customer_Type;

                spParameter[8] = new SqlParameter("@Is_Person", SqlDbType.Decimal);
                spParameter[8].Direction = ParameterDirection.Input;
                spParameter[8].Value = Is_Person;

                spParameter[9] = new SqlParameter("@Position", SqlDbType.NVarChar);
                spParameter[9].Direction = ParameterDirection.Input;
                spParameter[9].Value = Position;

                SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Customer_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Customer_Insert(string Customer_Name, string p_Phone, string p_Fax, string p_Identity_Card,
            string p_Address, string p_Tax_Code, decimal Customer_Type, decimal Is_Person, string Position)
        {
            try
            {
                decimal _id = -1;

                SqlParameter[] spParameter = new SqlParameter[10];
                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Output;
                spParameter[0].Value = _id;

                spParameter[1] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Customer_Name;

                spParameter[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Phone;

                spParameter[3] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Fax;

                spParameter[4] = new SqlParameter("@Identity_Card", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_Identity_Card;

                spParameter[5] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[5].Direction = ParameterDirection.Input;
                spParameter[5].Value = p_Address;

                spParameter[6] = new SqlParameter("@Tax_Code", SqlDbType.NVarChar);
                spParameter[6].Direction = ParameterDirection.Input;
                spParameter[6].Value = p_Tax_Code;

                spParameter[7] = new SqlParameter("@Customer_Type", SqlDbType.Decimal);
                spParameter[7].Direction = ParameterDirection.Input;
                spParameter[7].Value = Customer_Type;

                spParameter[8] = new SqlParameter("@Is_Person", SqlDbType.Decimal);
                spParameter[8].Direction = ParameterDirection.Input;
                spParameter[8].Value = Is_Person;

                spParameter[9] = new SqlParameter("@Position", SqlDbType.NVarChar);
                spParameter[9].Direction = ParameterDirection.Input;
                spParameter[9].Value = Position;

                SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Customer_Insert", spParameter);

                return Convert.ToDecimal(spParameter[0].Value);

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Customer_Search(string p_Tenant_Name, string p_Phone)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                spParameter[0] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Tenant_Name;

                spParameter[1] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Phone;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Customer_Search", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}
