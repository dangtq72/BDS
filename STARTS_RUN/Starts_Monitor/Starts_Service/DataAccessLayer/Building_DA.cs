using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Starts_Service
{
    public class Building_DA
    {
        public DataSet Building_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_buiding_getall", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public bool Building_Delete(decimal Building_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Building_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Building_Id;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Buiding_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public DataSet GetBuildingInEstate(decimal Building_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Building_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Building_Id;

               return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Estate_Object_GetByBuilding", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public decimal Building_Insert(string Buiding_Name, string Address, string Building_Code, string Notes)
        {
            try
            {
                decimal _id = -1;

                SqlParameter[] spParameter = new SqlParameter[5];
                spParameter[0] = new SqlParameter("@Building_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Output;
                spParameter[0].Value = _id;

                spParameter[1] = new SqlParameter("@Building_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Buiding_Name;

                spParameter[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = Address;

                spParameter[3] = new SqlParameter("@Building_Code", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = Building_Code;

                spParameter[4] = new SqlParameter("@Notes", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = Notes;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Building_Insert", spParameter);

                return Convert.ToDecimal(spParameter[0].Value);

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Building_Update(decimal Building_Id, string Buiding_Name, string Address, string Notes)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[4];
                spParameter[0] = new SqlParameter("@Building_Id", SqlDbType.Decimal);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Building_Id;

                spParameter[1] = new SqlParameter("@Building_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Buiding_Name;

                spParameter[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = Address;

                spParameter[3] = new SqlParameter("@Notes", SqlDbType.NVarChar);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = Notes;

                SqlHelper.ExecuteNonQuery(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Building_Update", spParameter);

                return 0;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public DataSet Building_Search(string Building_Name)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Building_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Building_Name;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_Building_Search", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }
    }
}
