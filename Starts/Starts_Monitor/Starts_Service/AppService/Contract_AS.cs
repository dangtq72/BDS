using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using MemoryData;
using ObjInfo;
using System.Data;
using ZetaCompressionLibrary;

namespace Starts_Service
{
    public partial interface IAppService
    {

        [OperationContract()]
        byte[] Contract_GetAll();

        [OperationContract()]
        byte[] Contract_GetByStatus(decimal p_status);

        [OperationContract()]
        byte[] Contract_GetBy_EstateObject(decimal p_Estate_Id);

        [OperationContract()]
        byte[] Contract_GetById(decimal Contract_Id);

        [OperationContract()]
        byte[] Contract_GetBy_RenterTenant(decimal p_Object_Id, decimal p_Object_Type);

        [OperationContract()]
        byte[] Contract_GetBy_Type(decimal p_Contract_Type);

        [OperationContract()]
        byte[] Contract_Render_Search(string p_Contract_Code, string p_status, string p_Payment_Status, string p_building, string Customer_Name);

        [OperationContract()]
        byte[] Contract_Search_ByContract_Type(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string p_building);

        [OperationContract()]
        byte[] Contract_Search(string p_Contract_Code, string p_status, string p_Payment_Status);

        [OperationContract()]
        byte[] Contract_Search_DenHanTB(string DateNow, string DateNow_Add);

        [OperationContract()]
        string Convert_Dola(decimal p_money);

        [OperationContract()]
        decimal Get_Max_Contract_Id();

        [OperationContract()]
        byte[] Get_Contract_Exprire_Date(string Contract_ToDate);

        [OperationContract()]
        bool Update_Status_Contract(decimal Contract_Id, decimal Status, string p_Modifi_By, DateTime p_Mofifi_Date);

        [OperationContract()]
        byte[] Contract_Search_ByExtend(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string p_building);

        [OperationContract()]
        byte[] Contract_Get_EstateByContract(decimal Estate_Id, decimal Contract_Type);

        [OperationContract()]
        byte[] Contract_GetByCode(string Contract_Code);

        #region các hàm liên quan tới thêm sửa xóa

        [OperationContract()]
        bool Contract_Delete(decimal p_Contract_Id);

        [OperationContract()]
        bool Contract_Update(decimal p_Contract_Id, string p_Contract_Code, string p_Contract_name, decimal p_Status, decimal p_Estate_Id, decimal p_Object_Id,
            decimal p_Contract_Type, decimal Price, decimal Fee, decimal Currency, decimal Fee_Status, DateTime Contract_FromDate, DateTime Contract_ToDate, decimal Term,
            decimal Pay_Count, decimal Object_Type, DateTime Contract_date, decimal FeeOnePay, string p_Modifi_By, DateTime p_Mofifi_Date, string Users, string Representive, DateTime Contract_ToDate_Ex);

        [OperationContract()]
        decimal Contract_Insert(string p_Contract_Code, string p_Contract_name, decimal p_Status, decimal p_Estate_Id, decimal p_Object_Id,
            decimal p_Contract_Type, decimal Price, decimal Fee, decimal Currency, decimal Fee_Status, DateTime Contract_FromDate, DateTime Contract_ToDate, decimal Term,
            decimal Pay_Count, decimal Object_Type, DateTime Contract_date, decimal FeeOnePay, string p_Created_by,
            DateTime p_Created_Date, string Users, string Representive, DateTime Contract_ToDate_Ex);
        #endregion
    }

    public partial class AppService : IAppService
    {
        public byte[] Contract_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_GetByStatus(decimal p_status)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetByStatus(p_status);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_GetBy_EstateObject(decimal p_Estate_Id)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetBy_EstateObject(p_Estate_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_GetById(decimal Contract_Id)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetById(Contract_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_GetBy_RenterTenant(decimal p_Object_Id, decimal p_Object_Type)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetBy_RenterTenant(p_Object_Id, p_Object_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_GetBy_Type(decimal p_Contract_Type)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetBy_Type(p_Contract_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_Render_Search(string p_Contract_Code, string p_status, string p_Payment_Status, string p_building, string Customer_Name)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_Render_Search(p_Contract_Code, p_status, p_Payment_Status, p_building, Customer_Name);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_Search_ByContract_Type(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string p_building)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_Search_ByContract_Type(p_Contract_Type, p_Contract_Code, p_status, p_Payment_Status, p_building);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_Search(string p_Contract_Code, string p_status, string p_Payment_Status)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_Search(p_Contract_Code, p_status, p_Payment_Status);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_Search_DenHanTB(string DateNow, string DateNow_Add)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_Search_DenHanTB(DateNow, DateNow_Add);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_Search_ByExtend(string p_Contract_Type, string p_Contract_Code, string p_status, string p_Payment_Status, string p_building)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_Search_ByExtend(p_Contract_Type, p_Contract_Code, p_status, p_Payment_Status, p_building);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Get_Contract_Exprire_Date(string Contract_ToDate)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Get_Contract_Exprire_Date(Contract_ToDate);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public string Convert_Dola(decimal p_money)
        {
            try
            {
                Contract_DA _Contract_DA = new Contract_DA();
                return _Contract_DA.Convert_Dola(p_money);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        public decimal Get_Max_Contract_Id()
        {
            try
            {
                Contract_DA _Contract_DA = new Contract_DA();
                return _Contract_DA.Get_Max_Contract_Id();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public bool Update_Status_Contract(decimal Contract_Id, decimal Status, string p_Modifi_By, DateTime p_Mofifi_Date)
        {
            try
            {
                Contract_DA _Contract_DA = new Contract_DA();
                return _Contract_DA.Update_Status_Contract(Contract_Id, Status, p_Modifi_By, p_Mofifi_Date);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public byte[] Contract_Get_EstateByContract(decimal Estate_Id, decimal Contract_Type)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_Get_EstateByContract(Estate_Id, Contract_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Contract_GetByCode(string Contract_Code)
        {
            try
            {
                byte[] byteReturn;
                Contract_DA _Contract_DA = new Contract_DA();
                DataSet ds = _Contract_DA.Contract_GetByCode(Contract_Code);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }
        #region Các hàm liên quan tới thêm sửa xóa
        public bool Contract_Delete(decimal p_Contract_Id)
        {
            try
            {
                Contract_DA _Contract_DA = new Contract_DA();
                return _Contract_DA.Contract_Delete(p_Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Contract_Update(decimal p_Contract_Id, string p_Contract_Code, string p_Contract_name, decimal p_Status, decimal p_Estate_Id, decimal p_Object_Id,
            decimal p_Contract_Type, decimal Price, decimal Fee, decimal Currency, decimal Fee_Status, DateTime Contract_FromDate, DateTime Contract_ToDate, decimal Term,
            decimal Pay_Count, decimal Object_Type, DateTime Contract_date, decimal FeeOnePay, string p_Modifi_By, DateTime p_Mofifi_Date, string Users, string Representive, DateTime Contract_ToDate_Ex)
        {
            try
            {
                Contract_DA _Contract_DA = new Contract_DA();
                return _Contract_DA.Contract_Update(p_Contract_Id, p_Contract_Code, p_Contract_name, p_Status, p_Estate_Id, p_Object_Id,
                    p_Contract_Type, Price, Fee, Currency, Fee_Status, Contract_FromDate, Contract_ToDate, Term,
                    Pay_Count, Object_Type, Contract_date, FeeOnePay, p_Modifi_By, p_Mofifi_Date, Users, Representive, Contract_ToDate_Ex);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Contract_Insert(string p_Contract_Code, string p_Contract_name, decimal p_Status, decimal p_Estate_Id, decimal p_Object_Id,
            decimal p_Contract_Type, decimal Price, decimal Fee, decimal Currency, decimal Fee_Status, DateTime Contract_FromDate, DateTime Contract_ToDate, decimal Term,
            decimal Pay_Count, decimal Object_Type, DateTime Contract_date, decimal FeeOnePay, string p_Created_by,
            DateTime p_Created_Date, string Users, string Representive, DateTime Contract_ToDate_Ex)
        {
            try
            {
                Contract_DA _Contract_DA = new Contract_DA();
                return _Contract_DA.Contract_Insert(p_Contract_Code, p_Contract_name, p_Status, p_Estate_Id, p_Object_Id,
                    p_Contract_Type, Price, Fee, Currency, Fee_Status, Contract_FromDate, Contract_ToDate, Term,
                    Pay_Count, Object_Type, Contract_date, FeeOnePay, p_Created_by, p_Created_Date, Users, Representive, Contract_ToDate_Ex);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }
        #endregion

    }
}
