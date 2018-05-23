
using System;
using System.Linq;
using System.Text;
using System.Collections;
using ZetaCompressionLibrary;
using System.Data;
using ObjInfo;
using System.Data.SqlClient;
using System.Collections.Generic;
using MemoryData;

namespace Starts_Controller
{
    public class GroupUserController
    {
        public List<GroupUserInfo> GroupUser_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.GroupUser_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<GroupUserInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<GroupUserInfo>();
            }
        }

        public decimal GroupUser_Insert(GroupUserInfo p_GroupUserInfo)
        {
            try
            {
                return CommonData.c_serviceWCF.GroupUser_Insert(p_GroupUserInfo.Name, p_GroupUserInfo.Group_Type, p_GroupUserInfo.Note);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// update theo id GroupUser
        /// </summary>
        public bool GroupUser_Update(decimal id, GroupUserInfo p_GroupUserInfo)
        {
            try
            {
                return CommonData.c_serviceWCF.GroupUser_Update(id,p_GroupUserInfo.Name, p_GroupUserInfo.Group_Type, p_GroupUserInfo.Note);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// xoa GroupUser theo id
        /// </summary>
        public bool GroupUser_Delete(decimal id)
        {
            try
            {
                return CommonData.c_serviceWCF.GroupUser_Delete(id);

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }
    }
}
