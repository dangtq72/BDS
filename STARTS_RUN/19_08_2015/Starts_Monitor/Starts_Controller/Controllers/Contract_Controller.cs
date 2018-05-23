using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;

namespace Starts_Controller
{
    public class Contract_Controller
    {
        public List<Contract_Info> Contract_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_GetByStatus(decimal p_status)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetByStatus(p_status);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_GetBy_EstateObject(decimal p_Estate_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetBy_EstateObject(p_Estate_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public Contract_Info Contract_GetById(decimal Contract_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetById(Contract_Id);
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

        public List<Contract_Info> Contract_GetBy_RenterTenant(decimal p_Object_Id, decimal p_Object_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetBy_RenterTenant(p_Object_Id, p_Object_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_GetBy_Type(decimal p_Object_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetBy_Type(p_Object_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_Render_Search(string p_Contract_Code, string p_status, string p_Payment_Status, string Building, string Customer_Name)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_Render_Search(p_Contract_Code, p_status, p_Payment_Status, Building, Customer_Name);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        /// <summary>
        /// Lấy các hợp đồng có sắp hết hạn (1,5 -2 tháng)
        /// </summary>
        public List<Contract_Info> Contract_Search_DenHanTB(string DateNow, string DateNow_Add)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_Search_DenHanTB(DateNow, DateNow_Add);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_Search_ByContract_Type(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string Building)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_Search_ByContract_Type(p_Contract_Type, p_Contract_Code, p_status, p_Payment_Status, Building);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_Search_ByExtend(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string Building)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_Search_ByExtend(p_Contract_Type, p_Contract_Code, p_status, p_Payment_Status, Building);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Contract_Search(string p_Contract_Code, string p_status, string p_Payment_Status)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_Search(p_Contract_Code, p_status, p_Payment_Status);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public List<Contract_Info> Get_Contract_Exprire_Date(string Contract_ToDate)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Get_Contract_Exprire_Date(Contract_ToDate);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Contract_Info>();
            }
        }

        public bool Contract_Delete(decimal p_Contract_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Contract_Delete(p_Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Contract_Update(decimal p_Contract_Id, Contract_Info p_Contract_Info,Contract_Info p_old)
        {
            try
            {
                Traces_Log_Controllers _traceControler = new Traces_Log_Controllers();
                _traceControler.Trace_Insert("CONTRACT", "UPDATE", p_Contract_Info.Modifi_By, p_Contract_Info, p_old);

                return CommonData.c_serviceWCF.Contract_Update(p_Contract_Id, p_Contract_Info.Contract_Code, p_Contract_Info.Contract_Name,
                    p_Contract_Info.Status, p_Contract_Info.Estate_Id, p_Contract_Info.Object_Id, p_Contract_Info.Contract_Type, p_Contract_Info.Price,
                    p_Contract_Info.Fee, p_Contract_Info.Currency, p_Contract_Info.Fee_Status, p_Contract_Info.Contract_FromDate, p_Contract_Info.Contract_ToDate,
                    p_Contract_Info.Term, p_Contract_Info.Pay_Count, p_Contract_Info.Object_Type, p_Contract_Info.Contract_Date, p_Contract_Info.FeeOnePay,
                    p_Contract_Info.Modifi_By, p_Contract_Info.Modifi_Date, p_Contract_Info.Users, p_Contract_Info.Representive, p_Contract_Info.Contract_ToDate_Ex);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Contract_Insert(Contract_Info p_Contract_Info)
        {
            try
            {
                Traces_Log_Controllers _traceControler = new Traces_Log_Controllers();
                _traceControler.Trace_Insert("CONTRACT", "INSERT", p_Contract_Info.Created_By, p_Contract_Info);

                return CommonData.c_serviceWCF.Contract_Insert(p_Contract_Info.Contract_Code, p_Contract_Info.Contract_Name,
                    p_Contract_Info.Status, p_Contract_Info.Estate_Id, p_Contract_Info.Object_Id, p_Contract_Info.Contract_Type, p_Contract_Info.Price,
                    p_Contract_Info.Fee, p_Contract_Info.Currency, p_Contract_Info.Fee_Status, p_Contract_Info.Contract_FromDate, p_Contract_Info.Contract_ToDate,
                    p_Contract_Info.Term, p_Contract_Info.Pay_Count, p_Contract_Info.Object_Type, p_Contract_Info.Contract_Date, p_Contract_Info.FeeOnePay,
                    p_Contract_Info.Created_By, p_Contract_Info.Created_Date, p_Contract_Info.Users, p_Contract_Info.Representive, p_Contract_Info.Contract_ToDate_Ex);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public string Convert_Dola(decimal p_money)
        {
            try
            {
                return CommonData.c_serviceWCF.Convert_Dola(p_money);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return p_money.ToString();
            }
        }

        public decimal Get_Max_Contract_Id()
        {
            try
            {
                return CommonData.c_serviceWCF.Get_Max_Contract_Id();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public bool Update_Status_Contract(decimal p_Contract_Id, decimal Status, string Modifi_By, DateTime Modifi_Date)
        {
            try
            {
                return CommonData.c_serviceWCF.Update_Status_Contract(p_Contract_Id, Status, Modifi_By, Modifi_Date);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool CheckEstateByContract(decimal Estate_Id, decimal Contract_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_Get_EstateByContract(Estate_Id, Contract_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Contract_Info> _lst = CBO<Contract_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0)
                    return false;
                else return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Check_ExistContractCode(string Contract_Code)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Contract_GetByCode(Contract_Code);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    return false;
                else return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }
    }
}
