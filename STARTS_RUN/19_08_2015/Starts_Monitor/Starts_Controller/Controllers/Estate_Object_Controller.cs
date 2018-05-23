using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;

namespace Starts_Controller
{
    public class Estate_Object_Controller
    {
        public List<Estate_Object_Info> Estate_Object_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Estate_Object_Info>();
            }
        }

        public List<Estate_Object_Info> Estate_Object_GetStatus(decimal p_status)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetStatus(p_status);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Estate_Object_Info>();
            }
        }

        public List<Estate_Object_Info> Estate_Object_GetType(decimal p_Estate_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetType(p_Estate_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Estate_Object_Info>();
            }
        }

        public Estate_Object_Info Estate_Object_GetById(decimal p_Estate_Id, decimal p_contract_type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetById(p_Estate_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Estate_Object_Info> _lst = CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);
                if (_lst.Count > 0)
                {
                    foreach (Estate_Object_Info item in _lst)
                    {
                        if (item.Contract_Type == p_contract_type)
                        {
                            return item;
                        }
                    }
                }
                else return new Estate_Object_Info();

                return new Estate_Object_Info();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Estate_Object_Info();
            }
        }

        public Estate_Object_Info Estate_Object_GetById_All(decimal p_Estate_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetById(p_Estate_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Estate_Object_Info> _lst = CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);


                if (_lst.Count > 0)
                {
                    return _lst[0];
                }
                else
                    return new Estate_Object_Info();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Estate_Object_Info();
            }
        }

        public List<Estate_Object_Info> Estate_Object_Search(string p_Estate_Name, string p_Estate_Type, string p_Status)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_Search(p_Estate_Name, p_Estate_Type, p_Status);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Estate_Object_Info>();
            }
        }

        /// <summary>
        /// Xem thằng căn hộ này có thằng nào thuê/ hay cho thuê hay chưa
        /// </summary>
        public Contract_Info Estate_Object_GetByObject(decimal p_Estate_Id, decimal p_Object_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetByObject(p_Estate_Id, p_Object_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Contract_Info> _lst = CBO<Contract_Info>.FillCollectionFromDataSet(ds);
                if (_lst.Count > 0)
                {
                    return _lst[0];
                }
                else return new Contract_Info();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Contract_Info();
            }
        }

        public bool Estate_Object_Delete(decimal p_Estate_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Estate_Object_Delete(p_Estate_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Estate_Object_Update(decimal p_Estate_Id, Estate_Object_Info p_Estate_Object_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Estate_Object_Update(p_Estate_Id, p_Estate_Object_Info.Estate_Name, p_Estate_Object_Info.Estate_Type,
                    p_Estate_Object_Info.Area, p_Estate_Object_Info.Status, p_Estate_Object_Info.Note);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Estate_Object_Insert(Estate_Object_Info p_Estate_Object_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Estate_Object_Insert(p_Estate_Object_Info.Estate_Name, p_Estate_Object_Info.Estate_Type,
                    p_Estate_Object_Info.Area, p_Estate_Object_Info.Status, p_Estate_Object_Info.Note, p_Estate_Object_Info.Estate_Code, p_Estate_Object_Info.Building_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public bool Check_Exit_EstateInContract(decimal p_Estate_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Check_Exit_EstateInContract(p_Estate_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Contract_Info> _lst = CBO<Contract_Info>.FillCollectionFromDataSet(ds);
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

        public List<Estate_Object_Info> Estate_Object_GetCbo(decimal Contract_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Estate_Object_GetCbo(Contract_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Estate_Object_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Estate_Object_Info>();
            }
        }
    }
}
