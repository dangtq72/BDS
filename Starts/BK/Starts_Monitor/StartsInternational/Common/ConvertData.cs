using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Collections;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace StartsInternational.Common
{
    class ConvertData
    {
        #region Lay ngay, thang, nam
        public static string GetYear(string strdate)
        {
            try
            {
                if (CheckValidate.CheckValidDate(strdate) == true)
                {
                    DateTime _dt;
                    _dt = ConvertString2Date(strdate);
                    return _dt.Year.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }

        }
        public static string g_DockingName = "DockManager";

        //
        public static string GetMonth(string strdate)
        {
            try
            {
                if (CheckValidate.CheckValidDate(strdate) == true)
                {
                    DateTime _dt;
                    _dt = ConvertString2Date(strdate);
                    return _dt.Month.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }

        }
        //
        public static string GetDay(string strdate)
        {
            try
            {
                if (CheckValidate.CheckValidDate(strdate) == true)
                {
                    DateTime _dt;
                    _dt = ConvertString2Date(strdate);
                    return _dt.Day.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }

        }
        #endregion

        /// <summary>
        /// Chuyen chu thuong thanh chu hoa
        /// </summary>
        public static string Upper(string str)
        {
            try
            {
                return str.ToUpper();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Chuyen chu hoa thanh chu thuong
        /// </summary>
        public static string Lower(string str)
        {
            try
            {
                return str.ToLower();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string ConvertDate2String(DateTime p_date)
        {
            try
            {
                return p_date.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                return "";
            }
        }

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

        public static DateTime ConvertString2Date_MMddYYY(string str)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(str, "MM/dd/yyyy", provider);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Convert string to date định dạng MM/dd/yyyy
        /// </summary>
        public static DateTime ConvertString2Date_MMddyyyy(string str)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(str, "MM/dd/yyyy", provider);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime ConvertStringGMT2Date(string str)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                return DateTime.ParseExact(str, "yyyy/MM/dd", provider);
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

        #region VuTT mã hóa
        public static string Encrypt(string toEncrypt)
        {
            try
            {
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] hashedBytes;
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(toEncrypt));
                StringBuilder s = new StringBuilder();
                foreach (byte _hashedByte in hashedBytes)
                {
                    s.Append(_hashedByte.ToString("x2"));
                }
                return s.ToString();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return "";
            }
        }

        #endregion

        #region Dinh dang kieu Money


        public static String ConvertString2Money(string str)
        {

            try
            {
                decimal _st = Convert.ToDecimal(str);
                //"{0:0.##}"
                //"{0:0,0 VND}"
                if (_st < 10 && _st > -10) return str;
                else
                    return String.Format("{0:0,0.##}", _st);

            }
            catch
            {
                return "";
            }
        }


        public static String ConvertString2StrInt(string str)
        {

            try
            {
                decimal _st = Convert.ToDecimal(str);
                //"{0:0.##}"
                //"{0:0,0 VND}"
                return String.Format("{0:0,0.##}", _st);

            }
            catch
            {
                return "";
            }
        }
        //Ham chuyen string dang Money ve Decimal.
        public static Decimal ConvertStringMoney2Decimal(string soTien)
        {
            try
            {
                Decimal tid = Convert.ToDecimal(soTien);
                return tid;
            }
            catch
            {
                return -1;
            }

        }
        #endregion

        #region private method

        #endregion

        /// <summary>
        /// dangtq check so nguyen ap dung cho cac truong tien te va khoi luong nguyen va hien thi dau , ngan cach 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string NhapMoney(TextBox txt)
        {
            try
            {
                if (!CheckValidate.CheckIsMoney(txt.Text) && txt.Text != "")
                {
                    string s = txt.Text;
                    if (s.Length > 1)
                        txt.Text = s.Remove(s.Length - 1, 1);
                    else txt.Text = "";
                    txt.Select(txt.Text.Length, 0);
                }
                return txt.Text;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        /// <summary>
        /// check so số thập phân 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string NhapSoTp(TextBox txt)
        {
            try
            {
                if (!CheckValidate.checksothapphan(txt.Text) && txt.Text != "")
                {
                    string s = txt.Text;
                    if (s.Length > 1)
                        txt.Text = s.Remove(s.Length - 1, 1);
                    else txt.Text = "";
                    txt.Select(txt.Text.Length, 0);
                }
                return txt.Text;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        #region Convert DataTable Dangtq

        public static void ConvertArrayListToDataTable(ArrayList arrayList, ref DataTable p_dt)
        {
            if (arrayList.Count != 0)
            {
                ConvertObjectToDataTableSchema(arrayList[0], ref p_dt);
                FillData(arrayList, p_dt);
            }
        }

        static void ConvertObjectToDataTableSchema(Object o, ref DataTable dt)
        {
            PropertyInfo[] properties = o.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                DataColumn dc = new DataColumn(property.Name);
                dc.DataType = property.PropertyType;
                dt.Columns.Add(dc);
            }
        }

        private static void FillData(ArrayList arrayList, DataTable dt)
        {
            foreach (Object o in arrayList)
            {
                DataRow dr = dt.NewRow();
                PropertyInfo[] properties = o.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    dr[property.Name] = property.GetValue(o, null);
                }
                dt.Rows.Add(dr);
            }
        }

        public static DataTable ConvertToDatatable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion

        #region Convert Money

        static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        static string Chu_USD(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "zero";
                    break;
                case "1":
                    result = "one";
                    break;
                case "2":
                    result = "two";
                    break;
                case "3":
                    result = "three";
                    break;
                case "4":
                    result = "four";
                    break;
                case "5":
                    result = "five";
                    break;
                case "6":
                    result = "six";
                    break;
                case "7":
                    result = "seven";
                    break;
                case "8":
                    result = "eigth";
                    break;
                case "9":
                    result = "nine";
                    break;
            }
            return result;
        }

        static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";
            }


            return Ktach;

        }

        public static string ConvertMoneyToStr(double gNum)
        {
            try
            {
                if (gNum == 0)
                    return "Không đồng";

                string lso_chu = "";
                string tach_mod = "";
                string tach_conlai = "";
                double Num = Math.Round(gNum, 0);
                string gN = Convert.ToString(Num);
                int m = Convert.ToInt32(gN.Length / 3);
                int mod = gN.Length - m * 3;
                string dau = "[+]";

                // Dau [+ , - ]
                if (gNum < 0)
                    dau = "[-]";
                dau = "";

                // Tach hang lon nhat
                if (mod.Equals(1))
                    tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
                if (mod.Equals(2))
                    tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
                if (mod.Equals(0))
                    tach_mod = "000";
                // Tach hang con lai sau mod :
                if (Num.ToString().Length > 2)
                    tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

                ///don vi hang mod 
                int im = m + 1;
                if (mod > 0)
                    lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
                /// Tach 3 trong tach_conlai

                int i = m;
                int _m = m;
                int j = 1;
                string tach3 = "";
                string tach3_ = "";

                while (i > 0)
                {
                    tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                    tach3_ = tach3;
                    lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                    m = _m + 1 - j;
                    if (!tach3_.Equals("000"))
                        lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                    tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                    i = i - 1;
                    j = j + 1;
                }
                if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                    lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
                if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                    lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
                if (lso_chu.Trim().Length > 0)
                    lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

                return lso_chu.ToString().Trim();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return gNum.ToString();
            }

        }

        #endregion
    }
}
