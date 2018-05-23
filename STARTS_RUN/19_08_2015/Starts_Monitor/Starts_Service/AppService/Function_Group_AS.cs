using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using MemoryData;
using System.Data;
using ZetaCompressionLibrary;
using ObjInfo;

namespace Starts_Service
{
    public partial interface IAppService
    {
        [OperationContract()]
        byte[] Function_GetAll();

        [OperationContract()]
        bool Function_Group_DelByGroup(decimal p_group_id);

        [OperationContract()]
        byte[] Get_Function_ByGroup(decimal p_group_id);

        [OperationContract()]
        int Function_Group_Insert_Batch(Function_GroupInfo[] p_arr);
    }

    public partial class AppService : IAppService
    {
        public byte[] Function_GetAll()
        {
            try
            {
                byte[] byteReturn;
                Function_Group_DA _Function_Group_DA = new Function_Group_DA();
                DataSet ds = _Function_Group_DA.Function_GetAll();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public bool Function_Group_DelByGroup(decimal p_group_id)
        {
            try
            {
                Function_Group_DA _Function_Group_DA = new Function_Group_DA();
                return _Function_Group_DA.Function_Group_DelByGroup(p_group_id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public byte[] Get_Function_ByGroup(decimal p_group_id)
        {
            try
            {
                byte[] byteReturn;
                Function_Group_DA _Function_Group_DA = new Function_Group_DA();
                DataSet ds = _Function_Group_DA.Get_Function_ByGroup(p_group_id);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public int Function_Group_Insert_Batch(Function_GroupInfo[] p_arr)
        {
            try
            {
                List<Function_GroupInfo> p_lst = new List<Function_GroupInfo>();

                for (int i = 0; i < p_arr.Length; i++)
                {
                    Function_GroupInfo item = p_arr[i];
                    p_lst.Add(item);
                }
                Function_Group_DA _Function_Group_DA = new Function_Group_DA();
                return _Function_Group_DA.Function_Group_Insert_Batch(p_lst);

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

    }
}
