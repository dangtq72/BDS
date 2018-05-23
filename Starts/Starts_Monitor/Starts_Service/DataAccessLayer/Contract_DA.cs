using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class Contract_DA
    {

        public DataSet Contract_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_GetAll", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_GetByStatus(decimal p_status)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Status", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_status;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_GetByStatus", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_GetBy_EstateObject(decimal p_Estate_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Estate_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_GetBy_EstateObject", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_GetById(decimal Contract_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_GetById", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_GetBy_RenterTenant(decimal p_Object_Id, decimal p_Object_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                spParameter[0] = new SqlParameter("@Object_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Object_Id;

                spParameter[1] = new SqlParameter("@Object_Type", SqlDbType.Decimal);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Object_Type;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_GetBy_RenterTenant", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_GetBy_Type(decimal p_Contract_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Type", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Type;


                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_GetBy_Type", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Contract_Delete(decimal p_Contract_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Contract_Update(decimal p_Contract_Id, string p_Contract_Code, string p_Contract_name, decimal p_Status, decimal p_Estate_Id, decimal p_Object_Id,
            decimal p_Contract_Type, decimal Price, decimal Fee, decimal Currency, decimal Fee_Status, DateTime Contract_FromDate, DateTime Contract_ToDate, decimal Term,
            decimal Pay_Count, decimal Object_Type, DateTime Contract_date, decimal FeeOnePay, string p_Modifi_By, DateTime p_Mofifi_Date,
            string Users, string Representive, DateTime Contract_ToDate_Ex)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[23];

                int i = 0;
                spParameter[i] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Id;

                i++;
                spParameter[i] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Code;

                i++;
                spParameter[i] = new SqlParameter("@Contract_name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_name;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Status;

                i++;
                spParameter[i] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Estate_Id;

                i++;
                spParameter[i] = new SqlParameter("@Object_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Object_Id;

                i++;
                spParameter[i] = new SqlParameter("@Contract_Type", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Type;

                i++;
                spParameter[i] = new SqlParameter("@Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Price;

                i++;
                spParameter[i] = new SqlParameter("@Fee", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee;

                ////////////////
                i++;
                spParameter[i] = new SqlParameter("@Currency", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Currency;

                i++;
                spParameter[i] = new SqlParameter("@Fee_Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee_Status;

                i++;
                spParameter[i] = new SqlParameter("@Contract_FromDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_FromDate;

                i++;
                spParameter[i] = new SqlParameter("@Contract_ToDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_ToDate;

                i++;
                spParameter[i] = new SqlParameter("@Term", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Term;

                i++;
                spParameter[i] = new SqlParameter("@Pay_Count", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Pay_Count;

                i++;
                spParameter[i] = new SqlParameter("@Object_Type", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Object_Type;

                i++;
                spParameter[i] = new SqlParameter("@Contract_date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_date;

                i++;
                spParameter[i] = new SqlParameter("@FeeOnePay", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = FeeOnePay;

                i++;
                spParameter[i] = new SqlParameter("@Modifi_By", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Modifi_By;

                i++;
                spParameter[i] = new SqlParameter("@Mofifi_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Mofifi_Date;

                i++;
                spParameter[i] = new SqlParameter("@Users", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Users;

                i++;
                spParameter[i] = new SqlParameter("@Representive", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Representive;

                i++;
                spParameter[i] = new SqlParameter("@Contract_ToDate_Ex", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_ToDate_Ex;
                
                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Contract_Insert(string p_Contract_Code, string p_Contract_name, decimal p_Status, decimal p_Estate_Id, decimal p_Object_Id,
            decimal p_Contract_Type, decimal Price, decimal Fee, decimal Currency, decimal Fee_Status, DateTime Contract_FromDate, DateTime Contract_ToDate, decimal Term,
            decimal Pay_Count, decimal Object_Type, DateTime Contract_date, decimal FeeOnePay, string p_Created_by, DateTime p_Created_Date,
            string Users, string Representive, DateTime Contract_ToDate_Ex)
        {
            try
            {
                decimal _id = -1;
                SqlParameter[] spParameter = new SqlParameter[23];

                int i = 0;
                spParameter[i] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                i++;
                spParameter[i] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Code;

                i++;
                spParameter[i] = new SqlParameter("@Contract_name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_name;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Status;

                i++;
                spParameter[i] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Estate_Id;

                i++;
                spParameter[i] = new SqlParameter("@Object_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Object_Id;

                i++;
                spParameter[i] = new SqlParameter("@Contract_Type", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Type;

                i++;
                spParameter[i] = new SqlParameter("@Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Price;

                i++;
                spParameter[i] = new SqlParameter("@Fee", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee;

                ////////////////
                i++;
                spParameter[i] = new SqlParameter("@Currency", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Currency;

                i++;
                spParameter[i] = new SqlParameter("@Fee_Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee_Status;

                i++;
                spParameter[i] = new SqlParameter("@Contract_FromDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_FromDate;

                i++;
                spParameter[i] = new SqlParameter("@Contract_ToDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_ToDate;

                i++;
                spParameter[i] = new SqlParameter("@Term", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Term;

                i++;
                spParameter[i] = new SqlParameter("@Pay_Count", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Pay_Count;

                i++;
                spParameter[i] = new SqlParameter("@Object_Type", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Object_Type;

                i++;
                spParameter[i] = new SqlParameter("@Contract_date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_date;

                i++;
                spParameter[i] = new SqlParameter("@FeeOnePay", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = FeeOnePay;

                i++;
                spParameter[i] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Created_by;

                i++;
                spParameter[i] = new SqlParameter("@Created_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Created_Date;

                i++;
                spParameter[i] = new SqlParameter("@Users", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Users;

                i++;
                spParameter[i] = new SqlParameter("@Representive", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Representive;

                i++;
                spParameter[i] = new SqlParameter("@Contract_ToDate_Ex", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_ToDate_Ex;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Insert", spParameter);

                return Convert.ToDecimal(spParameter[0].Value);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Contract_Render_Search(string p_Contract_Code, string p_status, string p_Payment_Status,
            string p_building, string Customer_Name)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];
                spParameter[0] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Code;

                spParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_status;

                spParameter[2] = new SqlParameter("@Payment_Status", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Payment_Status;

                spParameter[3] = new SqlParameter("@Building", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_building;

                spParameter[4] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = Customer_Name;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Render_Search", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_Search_ByContract_Type(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string p_building)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];
                spParameter[0] = new SqlParameter("@Contract_Type", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Type;

                spParameter[1] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Contract_Code;

                spParameter[2] = new SqlParameter("@Status", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_status;

                spParameter[3] = new SqlParameter("@Payment_Status", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Payment_Status;

                spParameter[4] = new SqlParameter("@Building", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_building;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Search_ByContract_Type", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_Search(string p_Contract_Code, string p_status, string p_Payment_Status)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[3];

                spParameter[0] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Code;

                spParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_status;

                spParameter[2] = new SqlParameter("@Payment_Status", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Payment_Status;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Search", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_Search_DenHanTB(string DateNow, string DateNow_Add)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@DateNow", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = DateNow;

                spParameter[1] = new SqlParameter("@DateNow_Add", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = DateNow_Add;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Search_DenHanTB", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public string Convert_Dola(decimal p_money)
        {
            try
            {
                string _str = "";
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@Money", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_money;

                spParameter[1] = new SqlParameter("@Money_Str", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Output;
                spParameter[1].Value = _str;
                spParameter[1].Size = 500;
                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_converMoney", spParameter);

                return Convert.ToString(spParameter[1].Value);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        public decimal Get_Max_Contract_Id()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet _ds = SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_get_max_ContractId", spParameter);

                if (_ds != null && _ds.Tables.Count > 0)
                {
                    return Convert.ToDecimal(_ds.Tables[0].Rows[0]["Contract_Id"]);
                }
                else return -1;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Get_Contract_Exprire_Date(string Contract_ToDate)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_ToDate", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_ToDate;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_get_Contract_Exprire_Date", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Update_Status_Contract(decimal Contract_Id, decimal Status, string p_Modifi_By, DateTime p_Mofifi_Date)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[4];

                int i = 0;
                spParameter[i] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_Id;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Status;

                i++;
                spParameter[i] = new SqlParameter("@Modifi_By", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Modifi_By;

                i++;
                spParameter[i] = new SqlParameter("@Mofifi_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Mofifi_Date;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_update_status_contract", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public DataSet Contract_Search_ByExtend(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string p_building)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];
                spParameter[0] = new SqlParameter("@Contract_Type", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Type;

                spParameter[1] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Contract_Code;

                spParameter[2] = new SqlParameter("@Status", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_status;

                spParameter[3] = new SqlParameter("@Payment_Status", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Payment_Status;

                spParameter[4] = new SqlParameter("@Building", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_building;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Contract_Search_ByExtend", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_Get_EstateByContract(decimal Estate_Id, decimal Contract_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                spParameter[0] = new SqlParameter("@Estate_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Estate_Id;

                spParameter[1] = new SqlParameter("@Contract_Type", SqlDbType.Decimal);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Contract_Type;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_get_EstateByContract", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Contract_GetByCode(string Contract_Code)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Code", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_Code;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_get_contract_code", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}
