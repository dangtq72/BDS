using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;

namespace Starts_Controller
{
    public class Tenant_Controller
    {
        public List<Tenant_Info> Tenant_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Tenant_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Tenant_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Tenant_Info>();
            }
        }

        public Tenant_Info Tenant_GetById(decimal p_Tenant_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Tenant_GetById(p_Tenant_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Tenant_Info> _lst = CBO<Tenant_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0)
                {
                    return _lst[0];
                }
                else return new Tenant_Info();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Tenant_Info();
            }
        }

        public bool Tenant_Delete(decimal p_Tenant_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Tenant_Delete(p_Tenant_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Tenant_Update(decimal p_Tenant_Id, Tenant_Info p_Tenant_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Tenant_Update(p_Tenant_Id, p_Tenant_Info.Tenant_Name, p_Tenant_Info.Phone, p_Tenant_Info.Fax, p_Tenant_Info.Identity_Card,
                    p_Tenant_Info.Address, p_Tenant_Info.Tax_Code, p_Tenant_Info.Representive, p_Tenant_Info.Position);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Tenant_Insert(Tenant_Info p_Tenant_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Tenant_Insert(p_Tenant_Info.Tenant_Name, p_Tenant_Info.Phone, p_Tenant_Info.Fax, p_Tenant_Info.Identity_Card,
                    p_Tenant_Info.Address, p_Tenant_Info.Tax_Code, p_Tenant_Info.Representive, p_Tenant_Info.Position);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public List<Tenant_Info> Tenant_Search(string p_name)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Tenant_Search(p_name);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Tenant_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Tenant_Info>();
            }
        }
    }
}
