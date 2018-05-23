using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Starts_Service
{
    public class Fees_Revenue_DA
    {
        public DataSet Fees_Revenue_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_All", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Fees_Revenue_Update(decimal p_Fee_Id, DateTime p_Pay_Date, decimal p_Fee, decimal p_status, decimal Debit_Amount)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];
                spParameter[0] = new SqlParameter("@Fee_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Fee_Id;

                spParameter[1] = new SqlParameter("@Pay_Date", SqlDbType.Date);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Pay_Date;

                spParameter[2] = new SqlParameter("@Fee", SqlDbType.Decimal);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Fee;

                spParameter[3] = new SqlParameter("@Status", SqlDbType.Decimal);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_status;

                spParameter[4] = new SqlParameter("@Debit_Amount", SqlDbType.Decimal);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = Debit_Amount;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Fees_Revenue_Insert(decimal Contract_Id, decimal Object_Id, decimal Object_Type,
            decimal Currency,decimal Number_Payment,DateTime Pay_Date_Expected,DateTime Pay_Date,decimal Fee_Expected, decimal Fee,
            decimal Pay_Status, DateTime Date_Of_Bill, decimal Debit_Amount, decimal Is_Extend, decimal Fee_Vnd)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[14];

                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_Id;

                spParameter[1] = new SqlParameter("@Object_Id", SqlDbType.Decimal);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Object_Id;

                spParameter[2] = new SqlParameter("@Object_Type", SqlDbType.Decimal);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = Object_Type;

                spParameter[3] = new SqlParameter("@Currency", SqlDbType.Decimal);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = Currency;

                spParameter[4] = new SqlParameter("@Number_Payment", SqlDbType.Decimal);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = Number_Payment;

                spParameter[5] = new SqlParameter("@Pay_Date_Expected", SqlDbType.Date);
                spParameter[5].Direction = ParameterDirection.Input;
                spParameter[5].Value = Pay_Date_Expected;

                spParameter[6] = new SqlParameter("@Pay_Date", SqlDbType.Date);
                spParameter[6].Direction = ParameterDirection.Input;
                spParameter[6].Value = Pay_Date;

                spParameter[7] = new SqlParameter("@Fee_Expected", SqlDbType.Decimal);
                spParameter[7].Direction = ParameterDirection.Input;
                spParameter[7].Value = Fee_Expected;

                spParameter[8] = new SqlParameter("@Fee", SqlDbType.Decimal);
                spParameter[8].Direction = ParameterDirection.Input;
                spParameter[8].Value = Fee;

                spParameter[9] = new SqlParameter("@Pay_Status", SqlDbType.Decimal);
                spParameter[9].Direction = ParameterDirection.Input;
                spParameter[9].Value = Pay_Status;

                spParameter[10] = new SqlParameter("@Date_Of_Bill", SqlDbType.Date);
                spParameter[10].Direction = ParameterDirection.Input;
                spParameter[10].Value = Date_Of_Bill;

                spParameter[11] = new SqlParameter("@Debit_Amount", SqlDbType.Decimal);
                spParameter[11].Direction = ParameterDirection.Input;
                spParameter[11].Value = Debit_Amount;

                spParameter[12] = new SqlParameter("@Is_Extend", SqlDbType.Decimal);
                spParameter[12].Direction = ParameterDirection.Input;
                spParameter[12].Value = Is_Extend;

                spParameter[13] = new SqlParameter("@Fee_Vnd", SqlDbType.Decimal);
                spParameter[13].Direction = ParameterDirection.Input;
                spParameter[13].Value = Fee_Vnd;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_Insert", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Fees_Revenue_DeleteByContract(decimal p_Contract_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_DeleteByContractID", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public DataSet Fees_Revenue_GetByContract(decimal p_Contract_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Contract_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_GetByContract", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Fees_Revenue_GetByObject(decimal p_Object_Id, decimal p_Object_Type)
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

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_GetByObject", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Fees_Revenue_GetByObjectType(decimal p_Object_Type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Object_Type", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Object_Type;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Fees_Revenue_GetByType", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet Fees_Report(string FromDate, string ToDate, string Created_By, string Estate_Code, string Users, string Customer_Name)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[6];

                int i = 0;
                spParameter[i] = new SqlParameter("@FromDate", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = FromDate;

                i++;
                spParameter[i] = new SqlParameter("@ToDate", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = ToDate;

                i++;
                spParameter[i] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Created_By;

                i++;
                spParameter[i] = new SqlParameter("@Estate_Code", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Estate_Code;

                i++;
                spParameter[i] = new SqlParameter("@Users", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Users;

                i++;
                spParameter[i] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Customer_Name;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Report_Fee", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

    }
}
