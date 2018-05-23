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
        byte[] User_Login(string p_user_name, string p_pass);

        [OperationContract()]
        byte[] User_Get_All();

        [OperationContract()]
        bool User_Update_Last_Login(decimal p_User_Id, DateTime p_last);

        [OperationContract()]
        bool User_Update_Pass(decimal p_User_Id, string p_pass);

        [OperationContract()]
        bool User_Delete(decimal p_User_Id);

        [OperationContract()]
        decimal User_Insert(string p_User_Name, string p_pass, decimal p_user_type, string p_full_name, decimal p_status,
            string p_phone, decimal p_group_id);

        [OperationContract()]
        bool User_Update(decimal p_User_Id, string p_User_Name, string p_pass, decimal p_user_type, string p_full_name, decimal p_status,
            string p_phone, decimal p_group_id);

        [OperationContract()]
        byte[] Send_Users_Get_MenuItem(string p_user_name);
    }

    public partial class AppService : IAppService
    {
        public byte[] User_Login(string p_user_name, string p_pass)
        {
            try
            {
                byte[] byteReturn;
                User_DA _User_DA = new User_DA();
                DataSet ds = _User_DA.User_Login(p_user_name, p_pass);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] User_Get_All()
        {
            try
            {
                byte[] byteReturn;
                User_DA _User_DA = new User_DA();
                DataSet ds = _User_DA.User_Get_All();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool User_Update_Last_Login(decimal p_User_Id, DateTime p_last)
        {
            try
            {
                User_DA _User_DA = new User_DA();
                return _User_DA.User_Update_Last_Login(p_User_Id, p_last);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool User_Update_Pass(decimal p_User_Id, string p_pass)
        {
            try
            {
                User_DA _User_DA = new User_DA();
                return _User_DA.User_Update_Pass(p_User_Id, p_pass);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool User_Delete(decimal p_User_Id)
        {
            try
            {
                User_DA _User_DA = new User_DA();
                return _User_DA.User_Delete(p_User_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal User_Insert(string p_User_Name, string p_pass, decimal p_user_type, string p_full_name, decimal p_status,
            string p_phone, decimal p_group_id)
        {
            try
            {
                User_DA _User_DA = new User_DA();
                return _User_DA.User_Insert(p_User_Name, p_pass, p_user_type, p_full_name, p_status, p_phone, p_group_id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public bool User_Update(decimal p_User_Id, string p_User_Name, string p_pass, decimal p_user_type, string p_full_name, decimal p_status,
            string p_phone, decimal p_group_id)
        {
            try
            {
                User_DA _User_DA = new User_DA();
                return _User_DA.User_Update(p_User_Id,p_User_Name, p_pass, p_user_type, p_full_name, p_status, p_phone, p_group_id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public byte[] Send_Users_Get_MenuItem(string p_user_name)
        {
            try
            {
                byte[] byteReturn;
                User_DA _User_DA = new User_DA();
                DataSet ds = _User_DA.Send_Users_Get_MenuItem(p_user_name);

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
