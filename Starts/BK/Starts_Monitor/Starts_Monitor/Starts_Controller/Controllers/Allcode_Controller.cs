using MemoryData;
using ObjInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetaCompressionLibrary;

namespace Starts_Controller
{
    public class Allcode_Controller
    {
        public List<AllCode_Info> Get_AllCode_ByCdNameCdType(string p_cdname, string p_cdtype)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.AllCode_GetBy_CdNameCdType(p_cdname, p_cdtype);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<AllCode_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<AllCode_Info>();
            }
        }

        public List<AllCode_Info> AllCode_Get_All()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.AllCode_Gets();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<AllCode_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                throw ex;
            }
        }

        public bool AllCode_checkDatabase()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.AllCode_Gets();

                if (byteRecive.Length > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool AllCode_checkWCF()
        {
            try
            {
                string s = CommonData.c_serviceWCF.AllCode_CheckWCF();

                if (s == "OK")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }
    }
}
