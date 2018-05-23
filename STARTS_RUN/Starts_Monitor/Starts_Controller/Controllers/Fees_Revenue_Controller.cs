using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;

namespace Starts_Controller
{
    public class Fees_Revenue_Controller
    {
        public List<Fees_Revenue_Info> Fees_Revenue_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Fees_Revenue_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Fees_Revenue_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Fees_Revenue_Info>();
            }
        }

        public List<Fees_Revenue_Info> Fees_Revenue_GetByContract(decimal p_Contract_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Fees_Revenue_GetByContract(p_Contract_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Fees_Revenue_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Fees_Revenue_Info>();
            }
        }

        public List<Fees_Revenue_Info> Fees_Revenue_GetByObject(decimal p_Object_Id, decimal p_Object_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Fees_Revenue_GetByObject(p_Object_Id, p_Object_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Fees_Revenue_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Fees_Revenue_Info>();
            }
        }

        public List<Fees_Revenue_Info> Fees_Revenue_GetByObjectType(decimal p_Object_Type)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Fees_Revenue_GetByObjectType(p_Object_Type);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Fees_Revenue_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Fees_Revenue_Info>();
            }
        }

        public bool Fees_Revenue_Update(Fees_Revenue_Info Fees_Revenue_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Fees_Revenue_Update(Fees_Revenue_Info.Fee_Id, Fees_Revenue_Info.Pay_Date, Fees_Revenue_Info.Fee,
                    Fees_Revenue_Info.Pay_Status, Fees_Revenue_Info.Debit_Amount);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Fees_Revenue_Insert(Fees_Revenue_Info p_Fees_Revenue_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Fees_Revenue_Insert(p_Fees_Revenue_Info.Contract_Id, p_Fees_Revenue_Info.Object_Id, p_Fees_Revenue_Info.Object_Type,
                    p_Fees_Revenue_Info.Currency, p_Fees_Revenue_Info.Number_Payment, p_Fees_Revenue_Info.Pay_Date_Expected, p_Fees_Revenue_Info.Pay_Date,
                    p_Fees_Revenue_Info.Fee_Expected, p_Fees_Revenue_Info.Fee, p_Fees_Revenue_Info.Pay_Status,
                    p_Fees_Revenue_Info.Date_Of_Bill, p_Fees_Revenue_Info.Debit_Amount, p_Fees_Revenue_Info.Is_Extend, p_Fees_Revenue_Info.Fee_Vnd);
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
                return CommonData.c_serviceWCF.Fees_Revenue_DeleteByContract(p_Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Fee_Report_Info> Fees_Report(string FromDate, string ToDate, string Created_By, string Estate_Code, string Users, string Customer_Name)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Fees_Report(FromDate, ToDate, Created_By, Estate_Code, Users, Customer_Name);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Fee_Report_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Fee_Report_Info>();
            }
        }
    }
}
