using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starts_Controller
{
    internal class CommonFunc
    {
        public static DateTime ConvertString2Date(string str)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(str, "dd/MM/yyyy", provider);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        public static DateTime ConvertStringTime2Date(string strTime)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(CorrectStringTime(strTime), "HH:mm:ss", provider);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
                throw ex;
            }
        }

        /// <summary>
        /// Chuan hoa chuoi ky tu Time truyen vao dam bao phai dung dinh dang HH:mm:ss
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        private static string CorrectStringTime(string strTime)
        {
            try
            {
                string _return = "00:00:00";
                string[] _arr = strTime.Split(':');

                if (_arr.Length >= 3)
                    _return = _arr[0].PadLeft(2, '0') + ":" + _arr[1].PadLeft(2, '0') + ":" + _arr[2].PadLeft(2, '0');
                return _return;
            }
            catch
            {
                return "00:00:00";
            }
        }

        #region Convert List to datatable

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion
    }
}
