
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using ZetaCompressionLibrary;

using ObjInfo;
using MemoryData;

namespace Starts_Controller
{

    public class User_RightsController
    {
        /// <summary>
        /// lấy quyền theo user, type (nhóm người sử dụng), và theo hệ thống
        /// </summary>
        /// <returns></returns>
        public ArrayList User_Rights_GetByUser(decimal p_group_id, string p_username)
        {
            try
            {
                byte[] byteGetbyRight = CommonData.c_serviceWCF.User_Rights_GetByUser(p_group_id, p_username); // lấy danh sách quyền của user theo hệ thống

                DataSet dsGetbyRight = CompressionHelper.DecompressDataSet(byteGetbyRight);

                ArrayList arrGetbyRight = CBO.FillCollectionFromDataSet(dsGetbyRight, typeof(User_FunctionsInfo));

                // sắp sếp thằng nào là con thì cho thêm 1 khoảng trắng vào
                ArrayList functionTree = GetChildofFunction(arrGetbyRight);

                return functionTree;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        /// <summary>
        /// sắp sếp thằng nào là con thì cho thêm 1 khoảng trắng vào
        /// </summary>
        /// <param name="arrAllFunction"></param>
        /// <param name="p_lang"></param>
        /// <returns></returns>
        private ArrayList GetChildofFunction(ArrayList arrAllFunction)
        {
            try
            {
                ArrayList new_arr = new ArrayList();
                string _cach = "          ";

                foreach (User_FunctionsInfo _info in arrAllFunction)
                {
                    if (_info.prid == "0")
                    {
                        new_arr.Add(_info);
                        User_FunctionsInfo _tem = new User_FunctionsInfo(_info);

                        //Lấy những function con từ function cha
                        BuidlTreeFuction(_tem, _info.functionId.ToString(), arrAllFunction, ref new_arr, _cach);
                    }

                }
                return new_arr;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        /// <summary>
        /// Lấy những function con từ function cha
        /// </summary>
        private void BuidlTreeFuction(User_FunctionsInfo p_parentItem, string p_parentID, ArrayList arrAllFunction, ref ArrayList new_arr, string cach)
        {
            try
            {
                foreach (User_FunctionsInfo _info in arrAllFunction)
                {
                    if (_info.prid == p_parentID)
                    {

                        if (p_parentItem.authcode == 0)
                        {
                            p_parentItem.authcode = _info.authcode;
                        }
                        _info.name = cach + _info.name;
                        new_arr.Add(_info);
                        BuidlTreeFuction(_info, _info.functionId.ToString(), arrAllFunction, ref new_arr, cach + "          ");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public void Delete_User_Right_By_UserFuntion(string p_username, string p_fun_id)
        {
            try
            {
                CommonData.c_serviceWCF.Delete_User_Right_By_UserFuntion(p_username, p_fun_id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public void User_Rights_DelByUser(string username)
        {
            try
            {
                CommonData.c_serviceWCF.User_Rights_DelByUser(username);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public void User_Rights_Insert_Barth(List<User_RightsInfo> p_lst)
        {
            try
            {
                User_RightsInfo[] _arr = new User_RightsInfo[p_lst.Count];
                for (int i = 0; i < p_lst.Count; i++)
                {
                    User_RightsInfo _User_RightsInfo = (User_RightsInfo)p_lst[i];
                    _arr[i] = _User_RightsInfo;
                }

                CommonData.c_serviceWCF.User_Rights_Insert_Barth(_arr);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }

        }
    }
}
