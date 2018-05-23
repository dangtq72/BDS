using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using ZetaCompressionLibrary;
using ObjInfo;
using MemoryData;
using Starts_Controller;

namespace Starts_Controller
{
    public class Function_GroupController
    {
        public bool Function_Group_DelByGroup(decimal id)
        {
            try
            {
                return CommonData.c_serviceWCF.Function_Group_DelByGroup(id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public void Function_Group_Insert_Batch(ArrayList p_arr,decimal p_group_id)
        {
            try
            {
                List<Function_GroupInfo> _list = new List<Function_GroupInfo>();
                Function_GroupInfo[] _arr = new Function_GroupInfo[p_arr.Count];

                for (int i = 0; i < p_arr.Count; i++)
                {
                    FunctionsInfo item = (FunctionsInfo)p_arr[i];
                    Function_GroupInfo _Function_GroupInfo = new Function_GroupInfo();
                    _Function_GroupInfo.Group_Id = p_group_id;
                    _Function_GroupInfo.Functionid = item.id;
                    _list.Add(_Function_GroupInfo);
                    _arr[i] = _Function_GroupInfo;
                }
                
                CommonData.c_serviceWCF.Function_Group_Insert_Batch(_arr);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public Hashtable Get_Function_ByGroup(decimal p_group_id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Get_Function_ByGroup(p_group_id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<FunctionsInfo> _lst = CBO<FunctionsInfo>.FillCollectionFromDataSet(ds);

                Hashtable _hs = new Hashtable();
                foreach (FunctionsInfo item in _lst)
                {
                    _hs[item.id] = item;
                }

                return _hs;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Hashtable();
            }
        }
    }
}
