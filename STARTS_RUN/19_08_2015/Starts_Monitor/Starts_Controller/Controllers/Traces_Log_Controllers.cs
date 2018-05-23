using MemoryData;
using ObjInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using ZetaCompressionLibrary;

namespace Starts_Controller
{
    public class Traces_Log_Controllers
    {
        public ArrayList Trace_Search(string p_object, string p_user, string p_frmdate, string p_todate)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.trace_Search(p_object, p_user, p_frmdate, p_todate);

                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);

                return CBO.FillCollectionFromDataSet(ds, typeof(TraceInfo));
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public void Trace_Insert(string Trace_Object, string Trace_Procedure, string Trace_User, object newObj)
        {
            try
            {
                string strvalue = obj2String(newObj);
                CommonData.c_serviceWCF.Trace_Insert(Trace_Object, Trace_Procedure, strvalue, Trace_User, DateTime.Now);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public void Trace_Insert(string Trace_Object, string Trace_Procedure, string Trace_User, object new_obj, object old_obj)
        {
            try
            {
                string strvalue = obj2String(old_obj, new_obj);
                CommonData.c_serviceWCF.Trace_Insert(Trace_Object, Trace_Procedure, strvalue, Trace_User, DateTime.Now);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                throw ex;
            }

        }
        public string obj2String(object old_obj, object new_obj)
        {
            try
            {
                Type type_old_obj = old_obj.GetType();
                StringBuilder sb = new StringBuilder();
                PropertyInfo[] pi_old_obj = type_old_obj.GetProperties();
                int n = pi_old_obj.Length;
                PropertyInfo _pi;
                sb.Append(pi_old_obj[0].Name);
                sb.Append(ConstPara.FieldValue);
                sb.Append(GetpropertyValue(pi_old_obj[0], old_obj));
                sb.Append(ConstPara.Field);
                for (int i = 1; i < n; i++)
                {
                    _pi = pi_old_obj[i];
                    if (GetpropertyValue(_pi, old_obj) == GetpropertyValue(_pi, new_obj))
                    {
                        sb.Append(_pi.Name);
                        sb.Append(ConstPara.FieldValue);
                        sb.Append(GetpropertyValue(_pi, old_obj));
                        sb.Append(ConstPara.Field);
                    }
                    else
                    {
                        sb.Append(_pi.Name);
                        sb.Append(ConstPara.FieldValue);
                        if (GetpropertyValue(_pi, old_obj) == null || GetpropertyValue(_pi, old_obj) == ""
                            || GetpropertyValue(_pi, old_obj) == "1/1/0001" || GetpropertyValue(_pi, old_obj) == "01/01/0001")
                            sb.Append("");
                        else
                        {
                            sb.Append(GetpropertyValue(_pi, old_obj));
                            sb.Append("=>");
                        }
                        if (GetpropertyValue(_pi, new_obj) == null || GetpropertyValue(_pi, new_obj) == ""
                            || GetpropertyValue(_pi, new_obj) == "1/1/0001" || GetpropertyValue(_pi, new_obj) == "01/01/0001")
                            sb.Append("");
                        else
                        {
                            if (sb.ToString().Substring(sb.Length - 3, 1) == ConstPara.FieldValue.ToString())
                                sb = sb.Remove(sb.Length - 2, 2);
                            else
                                sb.Append(GetpropertyValue(_pi, new_obj));
                        }
                        sb.Append(ConstPara.Field);
                        //
                        if (sb.ToString().Substring(sb.Length - 3, 2) == "=>")
                            sb = sb.Remove(sb.Length - 3, 2);
                    }
                }
                return sb.ToString().Trim(';');
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        /// Chuyển đối tượng thành string. 
        public string obj2String(object obj)
        {
            try
            {
                //LinhNN-20/12/2011 sua: lấy tất cả theo property, kiểm tra thuộc tính null
                System.Type type = obj.GetType();
                StringBuilder sb = new StringBuilder();
                PropertyInfo[] pi = type.GetProperties();

                foreach (PropertyInfo _pi in pi)
                {
                    sb.Append(_pi.Name);
                    sb.Append(ConstPara.FieldValue);
                    if (GetpropertyValue(_pi, obj) == null || GetpropertyValue(_pi, obj) == "" || GetpropertyValue(_pi, obj) == "1/1/0001" || GetpropertyValue(_pi, obj) == "01/01/0001")
                        sb.Append("");
                    else
                        sb.Append(GetpropertyValue(_pi, obj));
                    sb.Append(ConstPara.Field);
                }
                return sb.ToString().Trim(ConstPara.Field);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        private string GetpropertyValue(PropertyInfo p_pro, object p_obj)
        {
            try
            {
                if (p_pro.GetValue(p_obj, null) == null)
                {
                    return Null.GetNullStringValue(p_pro.GetType());
                }
                else
                {
                    if (p_pro.PropertyType == typeof(System.DateTime))
                    {
                        return ((DateTime)p_pro.GetValue(p_obj, null)).ToShortDateString();
                    }
                    else
                    {
                        return p_pro.GetValue(p_obj, null).ToString();
                    }
                }
            }
            catch
            {
                return "";
            }
        }

    }
}
