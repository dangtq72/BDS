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
        byte[] Estate_Object_GetAll();

        [OperationContract()]
        byte[] Estate_Object_GetStatus(decimal p_status);

        [OperationContract()]
        byte[] Estate_Object_GetById(decimal p_Estate_Id);

        [OperationContract()]
        byte[] Estate_Object_GetType(decimal p_Estate_Type);

        [OperationContract()]
        byte[] Estate_Object_GetByObject(decimal p_Estate_Id, decimal p_Object_Type);

        [OperationContract()]
        bool Estate_Object_Update(decimal p_Estate_Id, string p_Estate_Name, decimal p_Estate_Type, string p_Area, decimal p_Status, string p_note);

        [OperationContract()]
        bool Estate_Object_Delete(decimal p_Estate_Id);

        [OperationContract()]
        decimal Estate_Object_Insert(string p_Estate_Name, decimal p_Estate_Type, string p_Area, decimal p_Statu, string p_notes, string p_Estate_Code, decimal Building_Id);

        [OperationContract()]
        byte[] Check_Exit_EstateInContract(decimal p_Estate_Id);

        [OperationContract()]
        byte[] Estate_Object_Search(string p_Estate_Name, string p_Estate_Type, string p_Status);

        [OperationContract()]
        byte[] Estate_Object_GetCbo(decimal Contract_Type);
    }

    public partial class AppService : IAppService
    {
        public byte[] Estate_Object_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Estate_Object_GetStatus(decimal p_status)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_GetStatus(p_status);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Estate_Object_GetType(decimal p_Estate_Type)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_GetType(p_Estate_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Estate_Object_GetById(decimal p_Estate_Id)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_GetById(p_Estate_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Estate_Object_GetByObject(decimal p_Estate_Id, decimal p_Object_Type)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_GetByObject(p_Estate_Id, p_Object_Type);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool Estate_Object_Delete(decimal p_Estate_Id)
        {
            try
            {
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                return _Estate_Object_DA.Estate_Object_Delete(p_Estate_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Estate_Object_Update(decimal p_Estate_Id, string p_Estate_Name, decimal p_Estate_Type, string p_Area, decimal p_Status, string p_note)
        {
            try
            {
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                return _Estate_Object_DA.Estate_Object_Update(p_Estate_Id, p_Estate_Name, p_Estate_Type, p_Area, p_Status, p_note);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Estate_Object_Insert(string p_Estate_Name, decimal p_Estate_Type, string p_Area, decimal p_Status, string p_note,string p_Estate_Code, decimal Building_Id)
        {
            try
            {
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                return _Estate_Object_DA.Estate_Object_Insert(p_Estate_Name, p_Estate_Type, p_Area, p_Status, p_note, p_Estate_Code,Building_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public byte[] Check_Exit_EstateInContract(decimal p_Estate_Id)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Check_Exit_EstateInContract(p_Estate_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Estate_Object_Search(string p_Estate_Name, string p_Estate_Type, string p_Status)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_Search(p_Estate_Name,p_Estate_Type,p_Status);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] Estate_Object_GetCbo(decimal Contract_Type)
        {
            try
            {
                byte[] byteReturn;
                Estate_Object_DA _Estate_Object_DA = new Estate_Object_DA();
                DataSet ds = _Estate_Object_DA.Estate_Object_GetCbo(Contract_Type);

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
