using MemoryData;
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Text;
using ZetaCompressionLibrary;

namespace Starts_Service
{
    public partial interface IAppService
    {
        [OperationContract()]
        byte[] GroupUser_GetAll();

        [OperationContract()]
        bool GroupUser_Delete(decimal id);

        [OperationContract()]
        bool GroupUser_Update(decimal id, string p_name,decimal p_group_type,string p_note);

        [OperationContract()]
        decimal GroupUser_Insert(string p_name, decimal p_group_type, string p_note);
    }

    public partial class AppService : IAppService
    {
        public byte[] GroupUser_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Group_User_DA _Group_User_DA = new Group_User_DA();
                DataSet ds = _Group_User_DA.GroupUser_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool GroupUser_Delete(decimal id)
        {
            try
            {
                Group_User_DA _Group_User_DA = new Group_User_DA();
                return _Group_User_DA.GroupUser_Delete(id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool GroupUser_Update(decimal id, string p_name, decimal p_group_type, string p_note)
        {
            try
            {
                Group_User_DA _Group_User_DA = new Group_User_DA();
                return _Group_User_DA.GroupUser_Update(id, p_name,p_group_type,p_note);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal GroupUser_Insert(string p_name, decimal p_group_type, string p_note)
        {
            try
            {
                Group_User_DA _Group_User_DA = new Group_User_DA();
                return _Group_User_DA.GroupUser_Insert(p_name, p_group_type,p_note);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
