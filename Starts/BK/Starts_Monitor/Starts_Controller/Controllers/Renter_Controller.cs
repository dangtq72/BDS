using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;

namespace Starts_Controller
{
    public class Renter_Controller
    {
        public List<Render_Info> Renter_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Renter_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Render_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Render_Info>();
            }
        }

        public Render_Info Renter_GetById(decimal p_Renter_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Renter_GetById(p_Renter_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Render_Info> _lst = CBO<Render_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0)
                {
                    return _lst[0];
                }
                else return new Render_Info();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Render_Info();
            }
        }

        public bool Renter_Delete(decimal p_Renter_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Renter_Delete(p_Renter_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Renter_Update(decimal p_Renter_Id, Render_Info p_Render_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Renter_Update(p_Renter_Id, p_Render_Info.Renter_Name, p_Render_Info.Phone, p_Render_Info.Fax, p_Render_Info.Identity_Card,
                    p_Render_Info.Address, p_Render_Info.Tax_Code, p_Render_Info.Representive, p_Render_Info.Users);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Renter_Insert(Render_Info p_Render_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Renter_Insert(p_Render_Info.Renter_Name, p_Render_Info.Phone, p_Render_Info.Fax, p_Render_Info.Identity_Card,
                    p_Render_Info.Address, p_Render_Info.Tax_Code, p_Render_Info.Representive, p_Render_Info.Users);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public List<Render_Info> Renter_Search(string p_Renter_Name)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Renter_Search(p_Renter_Name);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Render_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Render_Info>();
            }
        }
    }
}
