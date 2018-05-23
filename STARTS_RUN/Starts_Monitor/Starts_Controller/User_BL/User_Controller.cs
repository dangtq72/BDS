using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ObjInfo;
using System.Data.SqlClient;
using System.Data;
using MemoryData;
using System.Collections;
using ZetaCompressionLibrary;

namespace Starts_Controller
{
    public class User_Controller
    {
        public decimal User_Insert(User_Info p_User_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.User_Insert(p_User_Info.User_Name, p_User_Info.Pass, p_User_Info.User_Type, p_User_Info.FullName,
                    p_User_Info.Status, p_User_Info.Phone, p_User_Info.Group_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public List<User_Info> User_Get_All()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.User_Get_All();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<User_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<User_Info>();
            }
        }

        public bool User_Update(decimal p_User_Id, User_Info p_User_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.User_Update(p_User_Id, p_User_Info.User_Name, p_User_Info.Pass, p_User_Info.User_Type, p_User_Info.FullName,
                 p_User_Info.Status, p_User_Info.Phone, p_User_Info.Group_Id);
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
                return CommonData.c_serviceWCF.User_Delete(p_User_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public User_Info User_Login(string p_user_name, string p_pass)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.User_Login(p_user_name, p_pass);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);

                List<User_Info> _lst = CBO<User_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0) return _lst[0];
                else return null;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        public bool User_Update_Last_Login(decimal p_User_Id, DateTime p_last)
        {
            try
            {
                return CommonData.c_serviceWCF.User_Update_Last_Login(p_User_Id, p_last);
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
                return CommonData.c_serviceWCF.User_Update_Pass(p_User_Id, p_pass);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///  tăng trường đếm số lần ~ quyền cho user lên + 1 để báo log out khi ~ quyền
        /// </summary>
        public void User_Change_SetRight(decimal id)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.User_Change_SetRight(id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public List<User_FunctionsInfo> Send_Users_Get_MenuItem(string p_user_name)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Send_Users_Get_MenuItem(p_user_name);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<User_FunctionsInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<User_FunctionsInfo>();
            }
        }
    }
}
