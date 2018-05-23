
using System;
using System.Collections.Generic;
using System.Data;
using Starts_Service;
using System.Data.SqlClient;
using MemoryData;

namespace WServiceGetData
{
    public class AllCodeDA
    {

        public AllCodeDA()
        { }

        /// <summary>
        /// Lấy toàn bộ bảng allcode
        /// </summary>
        /// <returns></returns>
        public DataSet AllCode_Gets()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_GetBy_All", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }

        public DataSet AllCode_GetBy_CdNameCdType(string p_cdtype, string p_cdname)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@CdName", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_cdname;

                spParameter[1] = new SqlParameter("@CdType", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_cdtype;

                return SqlHelper.ExecuteDataset(ConfigInfo.ConnectionString, CommandType.StoredProcedure, "proc_GetBy_Name_Type", spParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new DataSet();
            }
        }


    }
}
