using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Starts_Service
{
    public class Extend_Contract_DA
    {
        public decimal Extend_Contract_Insert(decimal p_Contract_Id, DateTime Contract_FromDate, DateTime Contract_ToDate, DateTime Extend_Date, decimal Term,
          decimal Fee, decimal FeeOnePay, decimal Price, decimal Number_Extend)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[9];

                int i = 0;
                spParameter[i] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Id;

                i++;
                spParameter[i] = new SqlParameter("@Contract_FromDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_FromDate;

                i++;
                spParameter[i] = new SqlParameter("@Contract_ToDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_ToDate;

                i++;
                spParameter[i] = new SqlParameter("@Extend_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Extend_Date;

                i++;
                spParameter[i] = new SqlParameter("@Term", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Term;

                i++;
                spParameter[i] = new SqlParameter("@Fee", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee;

                i++;
                spParameter[i] = new SqlParameter("@FeeOnePay", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = FeeOnePay;

                i++;
                spParameter[i] = new SqlParameter("@Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Price;

                i++;
                spParameter[i] = new SqlParameter("@Number_Extend", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Number_Extend;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Extend_Contract_Insert", spParameter);

                return 0;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Extend_Contract_Update(decimal p_Contract_Id, DateTime Contract_FromDate, DateTime Contract_ToDate, DateTime Extend_Date, decimal Term,
          decimal Fee, decimal FeeOnePay, decimal Price, decimal Fee_Status, decimal Extend_Contract_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[10];

                int i = 0;
                spParameter[i] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Contract_Id;

                i++;
                spParameter[i] = new SqlParameter("@Contract_FromDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_FromDate;

                i++;
                spParameter[i] = new SqlParameter("@Contract_ToDate", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Contract_ToDate;

                i++;
                spParameter[i] = new SqlParameter("@Extend_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Extend_Date;

                i++;
                spParameter[i] = new SqlParameter("@Term", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Term;

                i++;
                spParameter[i] = new SqlParameter("@Fee", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee;

                i++;
                spParameter[i] = new SqlParameter("@FeeOnePay", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = FeeOnePay;

                i++;
                spParameter[i] = new SqlParameter("@Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Price;

                i++;
                spParameter[i] = new SqlParameter("@Fee_Status", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Fee_Status;

                i++;
                spParameter[i] = new SqlParameter("@Extend_Contract_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = Extend_Contract_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Extend_Contract_Update", spParameter);

                return 0;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Extend_Contract_GetByContractId(decimal Contract_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_Id;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Extend_Contract_GetById", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public decimal Get_Number_ExtendContract(decimal Contract_Id)
        {
            try
            {
                decimal _id = -1;

                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@Contract_Id", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Contract_Id;

                spParameter[1] = new SqlParameter("@Number_Extend", SqlDbType.Decimal);
                spParameter[1].Direction = ParameterDirection.Output;
                spParameter[1].Value = _id;

                SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_get_max_ExtendContract", spParameter);

                return Convert.ToDecimal(spParameter[1].Value);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
