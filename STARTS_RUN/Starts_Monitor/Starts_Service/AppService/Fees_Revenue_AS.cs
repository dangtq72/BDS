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
        byte[] Fees_Revenue_GetAll();

        [OperationContract()]
        byte[] Fees_Revenue_GetByContract(decimal p_Contract_Id);

        [OperationContract()]
        byte[] Fees_Revenue_GetByObject(decimal p_Object_Id, decimal p_Object_Type);

        [OperationContract()]
        bool Fees_Revenue_Update(decimal p_Fee_Id, DateTime p_Pay_Date, decimal p_Fee, decimal p_status, decimal Debit_Amount);

        [OperationContract()]
        bool Fees_Revenue_Insert(decimal Contract_Id, decimal Object_Id, decimal Object_Type,
          decimal Currency, decimal Number_Payment, DateTime Pay_Date_Expected, DateTime Pay_Date, decimal Fee_Expected, decimal Fee,
          decimal Pay_Status, DateTime Date_Of_Bill, decimal Debit_Amount, decimal Is_Extend, decimal Fee_Vnd);

        [OperationContract()]
        bool Fees_Revenue_DeleteByContract(decimal p_Contract_Id);

        [OperationContract()]
        byte[] Fees_Revenue_GetByObjectType(decimal p_Object_Type);

        [OperationContract()]
        byte[] Fees_Report(string FromDate, string ToDate, string Created_By, string Estate_Code, string Users, string Customer_Name);
    }

    public partial class AppService : IAppService
    {
        public byte[] Fees_Revenue_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                DataSet ds = _Fees_Revenue_DA.Fees_Revenue_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Fees_Revenue_GetByContract(decimal p_Contract_Id)
        {
            try
            {
                byte[] byteReturn;
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                DataSet ds = _Fees_Revenue_DA.Fees_Revenue_GetByContract(p_Contract_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Fees_Revenue_GetByObject(decimal p_Object_Id, decimal p_Object_Type)
        {
            try
            {
                byte[] byteReturn;
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                DataSet ds = _Fees_Revenue_DA.Fees_Revenue_GetByObject(p_Object_Id, p_Object_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Fees_Revenue_GetByObjectType(decimal p_Object_Type)
        {
            try
            {
                byte[] byteReturn;
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                DataSet ds = _Fees_Revenue_DA.Fees_Revenue_GetByObjectType(p_Object_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool Fees_Revenue_Update(decimal p_Fee_Id, DateTime p_Pay_Date, decimal p_Fee, decimal p_status, decimal Debit_Amount)
        {
            try
            {
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                return _Fees_Revenue_DA.Fees_Revenue_Update(p_Fee_Id, p_Pay_Date, p_Fee, p_status, Debit_Amount);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Fees_Revenue_Insert(decimal Contract_Id, decimal Object_Id, decimal Object_Type,
          decimal Currency, decimal Number_Payment, DateTime Pay_Date_Expected, DateTime Pay_Date, decimal Fee_Expected, decimal Fee,
          decimal Pay_Status, DateTime Date_Of_Bill, decimal Debit_Amount, decimal Is_Extend, decimal Fee_Vnd)
        {
            try
            {
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                return _Fees_Revenue_DA.Fees_Revenue_Insert(Contract_Id, Object_Id, Object_Type,
                    Currency, Number_Payment, Pay_Date_Expected, Pay_Date, Fee_Expected, Fee, Pay_Status, Date_Of_Bill, Debit_Amount, Is_Extend, Fee_Vnd);
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
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                return _Fees_Revenue_DA.Fees_Revenue_DeleteByContract(p_Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public byte[] Fees_Report(string FromDate, string ToDate, string Created_By, string Estate_Code, string Users, string Customer_Name)
        {
            try
            {
                byte[] byteReturn;
                Fees_Revenue_DA _Fees_Revenue_DA = new Fees_Revenue_DA();
                DataSet ds = _Fees_Revenue_DA.Fees_Report(FromDate, ToDate, Created_By, Estate_Code, Users, Customer_Name);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }
    }
}
