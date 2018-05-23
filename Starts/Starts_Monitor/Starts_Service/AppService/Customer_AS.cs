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
        byte[] Customer_GetAll();

        [OperationContract()]
        byte[] Customer_GetById(decimal p_Tenant_Id);

        [OperationContract()]
        bool Customer_Delete(decimal Customer_Id);

        [OperationContract()]
        bool Customer_Update(decimal Customer_Id, string Customer_Name, string p_Phone, string p_Fax, string p_Identity_Card,
            string p_Address, string p_Tax_Code, decimal Customer_Type, decimal Is_Person, string Position);

        [OperationContract()]
        decimal Customer_Insert(string Customer_Name, string p_Phone, string p_Fax, string p_Identity_Card,
            string p_Address, string p_Tax_Code, decimal Customer_Type, decimal Is_Person, string Position);

        [OperationContract()]
        byte[] Customer_Search(string p_Tenant_Name, string p_Phone);

        [OperationContract()]
        byte[] Customer_Check_In_Contract(decimal Customer_Id);
    }

    public partial class AppService : IAppService
    {
        public byte[] Customer_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Customer_DA _Customer_DA = new Customer_DA();
                DataSet ds = _Customer_DA.Customer_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Customer_GetById(decimal p_Tenant_Id)
        {
            try
            {
                byte[] byteReturn;
                Customer_DA _Customer_DA = new Customer_DA();
                DataSet ds = _Customer_DA.Customer_GetById(p_Tenant_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool Customer_Delete(decimal Customer_Id)
        {
            try
            {
                Customer_DA _Customer_DA = new Customer_DA();
                return _Customer_DA.Customer_Delete(Customer_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public byte[] Customer_Check_In_Contract(decimal Customer_Id)
        {
            try
            {
                byte[] byteReturn;
                Customer_DA _Customer_DA = new Customer_DA();
                DataSet ds = _Customer_DA.Customer_Check_In_Contract(Customer_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool Customer_Update(decimal Customer_Id, string Customer_Name, string p_Phone, string p_Fax, string p_Identity_Card,
            string p_Address, string p_Tax_Code, decimal Customer_Type, decimal Is_Person, string Position)
        {
            try
            {
                Customer_DA _Customer_DA = new Customer_DA();
                return _Customer_DA.Customer_Update(Customer_Id, Customer_Name, p_Phone, p_Fax, p_Identity_Card, p_Address, p_Tax_Code, Customer_Type, Is_Person, Position);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Customer_Insert(string Customer_Name, string p_Phone, string p_Fax, string p_Identity_Card,
            string p_Address, string p_Tax_Code, decimal Customer_Type, decimal Is_Person, string Position)
        {
            try
            {
                Customer_DA _Customer_DA = new Customer_DA();
                return _Customer_DA.Customer_Insert(Customer_Name, p_Phone, p_Fax, p_Identity_Card, p_Address, p_Tax_Code, Customer_Type, Is_Person, Position);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public byte[] Customer_Search(string p_Tenant_Name, string p_Phone)
        {
            try
            {
                byte[] byteReturn;
                Customer_DA _Customer_DA = new Customer_DA();
                DataSet ds = _Customer_DA.Customer_Search(p_Tenant_Name, p_Phone);

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
