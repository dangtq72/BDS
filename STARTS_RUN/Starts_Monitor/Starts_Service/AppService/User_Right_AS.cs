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
        void User_Rights_DelByUser(string p_user_name);

        [OperationContract()]
        void Delete_User_Right_By_UserFuntion(string p_user_name, string p_fun_id);

        [OperationContract()]
        int User_Rights_Insert_Barth(User_RightsInfo[] p_arr);

        [OperationContract()]
        byte[] User_Rights_GetByUser(decimal p_group_id, string p_username);
    }

    public partial class AppService : IAppService
    {
        public void User_Rights_DelByUser(string p_user_name)
        {
            try
            {
                User_Rights_DA _User_Rights_DA = new User_Rights_DA();
                _User_Rights_DA.User_Rights_DelByUser(p_user_name);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public void Delete_User_Right_By_UserFuntion(string p_user_name, string p_fun_id)
        {
            try
            {
                User_Rights_DA _User_Rights_DA = new User_Rights_DA();
                _User_Rights_DA.Delete_User_Right_By_UserFuntion(p_user_name, p_fun_id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public int User_Rights_Insert_Barth(User_RightsInfo[] p_arr)
        {
            try
            {
                List<User_RightsInfo> p_lst = new List<User_RightsInfo>();

                for (int i = 0; i < p_arr.Length; i++)
                {
                    User_RightsInfo item = p_arr[i];
                    p_lst.Add(item);
                }
                User_Rights_DA _User_Rights_DA = new User_Rights_DA();
                return _User_Rights_DA.User_Rights_Insert_Barth(p_lst);

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public byte[] User_Rights_GetByUser(decimal p_group_id, string p_username)
        {
            try
            {
                byte[] byteReturn;
                User_Rights_DA _User_Rights_DA = new User_Rights_DA();
                DataSet ds = _User_Rights_DA.User_Rights_GetByUser(p_group_id, p_username);

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
