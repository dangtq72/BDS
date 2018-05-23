
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

namespace Starts_Controller
{


    public class FunctionsController
    {
        public ArrayList Function_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Function_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                ArrayList arr = CBO.FillCollectionFromDataSet(ds, typeof(FunctionsInfo));

                return GetChildofFunction(arr);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList GetChildofFunction(ArrayList arrAllFunction)
        {
            ArrayList new_arr = new ArrayList();
            string _cach = "          ";

            foreach (FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == "0")
                {
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, _info.id, arrAllFunction, ref new_arr, _cach);
                }
            }
            return new_arr;
        }

        public void BuidlTreeFuction(FunctionsInfo p_parentItem, string p_parentID, ArrayList arrAllFunction, ref ArrayList new_arr, string cach)
        {
            foreach (FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == p_parentID)
                {
                    _info.name = cach + _info.name;
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, _info.id, arrAllFunction, ref new_arr, cach + "          ");
                }
            }
        }

        public ArrayList GetParentOfFunction(ArrayList arr, ArrayList arrAllFunction)
        {
            try
            {
                ArrayList new_arr = new ArrayList();

                foreach (FunctionsInfo _info in arr)
                {
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, arrAllFunction, ref new_arr);
                }
                return new_arr;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public void BuidlTreeFuction(FunctionsInfo p_ChildItem, ArrayList arrAllFunction, ref ArrayList new_arr)
        {
            try
            {
                foreach (FunctionsInfo _info in arrAllFunction)
                {
                    if (p_ChildItem.prid == _info.id)
                    {
                        new_arr.Add(_info);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public ArrayList Function_Check_Not_Same(string p_id)
        {
            try
            {
                //byte[] byteRecive = Common.CommonData.c_serviceWCF.Function_Check_Not_Same(p_id);
                //DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                //ArrayList arr = CBO.FillCollectionFromDataSet(ds, typeof(FunctionsInfo));

                //return arr;

                return new ArrayList();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

    }
}
