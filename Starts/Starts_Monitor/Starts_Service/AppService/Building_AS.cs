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
        byte[] Building_GetAll();

        [OperationContract()]
        bool Building_Delete(decimal Building_Id);

        [OperationContract()]
        byte[] GetBuildingInEstate(decimal Building_Id);

        [OperationContract()]
        decimal Building_Update(decimal Building_Id, string Buiding_Name, string Address, string Notes);

        [OperationContract()]
        decimal Building_Insert(string Buiding_Name, string Address, string Building_Code, string Notes);

        [OperationContract()]
        byte[] Building_Search(string Building_Name);
    }

    public partial class AppService : IAppService
    {
        public byte[] Building_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Building_DA _Building_DA = new Building_DA();
                DataSet ds = _Building_DA.Building_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] GetBuildingInEstate(decimal Building_Id)
        {
            try
            {
                byte[] byteReturn;
                Building_DA _Building_DA = new Building_DA();
                DataSet ds = _Building_DA.GetBuildingInEstate(Building_Id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool Building_Delete(decimal Building_Id)
        {
            try
            {
                Building_DA _Building_DA = new Building_DA();
                return _Building_DA.Building_Delete(Building_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Building_Update(decimal Building_Id, string Buiding_Name, string Address, string Notes)
        {
            try
            {
                Building_DA _Building_DA = new Building_DA();
                return _Building_DA.Building_Update(Building_Id, Buiding_Name, Address, Notes);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Building_Insert(string Buiding_Name, string Address, string Building_Code, string Notes)
        {
            try
            {
                Building_DA _Building_DA = new Building_DA();
                return _Building_DA.Building_Insert(Buiding_Name, Address, Building_Code,Notes);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public byte[] Building_Search(string Building_Name)
        {
            try
            {
                byte[] byteReturn;
                Building_DA _Building_DA = new Building_DA();
                DataSet ds = _Building_DA.Building_Search(Building_Name);

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
