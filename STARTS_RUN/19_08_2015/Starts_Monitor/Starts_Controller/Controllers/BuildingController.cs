using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;


namespace Starts_Controller
{
    public class BuildingController
    {
        public List<Building_Info> Building_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Building_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Building_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Building_Info>();
            }
        }

        public List<Building_Info> GetBuildingInEstate(decimal Building_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.GetBuildingInEstate(Building_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Building_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Building_Info>();
            }
        }

        public List<Building_Info> Building_Search(string p_name)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Building_Search(p_name);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Building_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Building_Info>();
            }
        }

        public decimal Building_Insert(Building_Info Building_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Building_Insert(Building_Info.Building_Name, Building_Info.Address, Building_Info.Building_Code, Building_Info.Notes);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Building_Update(decimal p_id, Building_Info Building_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Building_Update(p_id, Building_Info.Building_Name, Building_Info.Address, Building_Info.Notes);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public bool Building_Delete(decimal Building_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Building_Delete(Building_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Check_Exit_EstateInBuilding(decimal Building_Id)
        {
            try
            {
                List<Building_Info> _lst = GetBuildingInEstate(Building_Id);
                if (_lst.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }
    }
}
