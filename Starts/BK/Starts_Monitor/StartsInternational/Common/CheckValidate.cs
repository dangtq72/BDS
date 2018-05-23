using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using AvalonDock;

namespace StartsInternational
{
    public class CheckValidate
    {
        public bool checkReleaseRate(string p_strReleaseRate)
        {
            try
            {
                bool _ck = false;
                int _dau2cham_cout = 0;
                int _dau2cham_vitri = 0;
                int counter = 0;
                int convertedPw;
                CharEnumerator charEnum = p_strReleaseRate.GetEnumerator();

                if (Convert.ToInt32(p_strReleaseRate[0]) == 32 || Convert.ToInt32(p_strReleaseRate[0]) == 48 || Convert.ToInt32(p_strReleaseRate[0]) == 58 || Convert.ToInt32(p_strReleaseRate[counter]) == 58)
                {
                    return false;
                }
                else
                {
                    #region check chuoi neu ktu dau va cuoi ko phai la dau 2 cham, ky tu dau tien ko phai la so 0 hoac khoang trang
                    while (charEnum.MoveNext())
                    {
                        convertedPw = Convert.ToInt32(p_strReleaseRate[counter]);
                        if ((convertedPw >= 48) && (convertedPw <= 57))
                        {   //ky tu so
                            _ck = true;
                        }
                        else if (convertedPw == 58 && _dau2cham_cout < 2)
                        {

                            _dau2cham_vitri = counter;
                            _dau2cham_cout += 1;
                            _ck = true;
                        }
                        else
                        {
                            _ck = false;
                            break;
                        }

                        counter++;
                    }
                    #endregion
                }

                if (_ck == true)
                {
                    //check xem dau 2 cham o vi tri dau tien hay cuoi cung 
                    if (_dau2cham_cout == 0 || Convert.ToInt32(p_strReleaseRate[_dau2cham_vitri + 1]) == 48)
                    {
                        _ck = false;
                    }
                }

                return _ck;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool CheckValidDate(string str)
        {
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.CurrentCulture;
            DateTime temp;

            try
            {
                temp = DateTime.ParseExact(str, "dd/MM/yyyy", provider);

                if (temp < DateTime.ParseExact("01/01/1800", "dd/MM/yyyy", provider))
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        // xem lai neu st khong phai la so
        public static bool CheckDecimal(string st)
        {
            //string Str = textBox1.Text.Trim();
            decimal Num;

            bool isNum = decimal.TryParse(st, out Num);

            if (isNum)
                return true;

            else
                return false;
        }

        public static bool CheckInt32(string st)
        {
            //string Str = textBox1.Text.Trim();
            int  Num;

            bool isNum = int.TryParse(st, out Num);

            if (isNum)
                return true;

            else
                return false;
        }

        public static bool CheckInt(string st)
        {
            //string Str = textBox1.Text.Trim();
            Int64 Num;

            Int64.TryParse(st, out Num);

            if (Num > 0 || st.Equals("0"))
                return true;
            else
                return false;
        }

        // xem lai neu st khong phai la so
        public static bool CheckDecimal_duong(string st)
        {
            //string Str = textBox1.Text.Trim();
            decimal Num;

            bool isNum = decimal.TryParse(st, out Num);

            if (isNum)
            {
                if (Num >= 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        //check du lieu la Ty le( 0< tl < 100) - HuongLL
        public static bool CheckRate(string st)
        {
            decimal Num;

            bool isNum = decimal.TryParse(st, out Num);

            if (isNum && Num > 0)
            {
                return true;
            }
            else
                return false;
        }

        // xem lai neu st khong phai la so
        public static bool CheckDecimal_am(string st)
        {
            //string Str = textBox1.Text.Trim();
            decimal Num;

            decimal.TryParse(st, out Num);

            if (Num < 0)
                return false;
            else
                return true;
        }

        // sangdd sửa 
        public static bool Check_dauPhay(string st)
        {
            bool _ck = false;
            if (st.Contains(",") == true)
            {
                _ck = true;
            }
            return _ck;

        }

        // sangdd sửa 
        public static bool Check_dauCham(string st)
        {
            bool _ck = false;
            if (st.Contains(".") || st.Contains("*") || st.Contains("+"))
            {
                _ck = true;
            }
            return _ck;

        }

        // sangdd sửa 
        //Kiểm tra khoảng trắng trong chuỗi.True tức là chuỗi có khoảng trắng.
        public static bool check_Space(string str)
        {
            bool _ck = false;
            if (str.Contains(" "))
            {
                _ck = true;
            }

            return _ck;
        }

        //VuTT sửa
        // Kiểm tra chuỗi có chứa dấu nháy ko.  
        public static bool check_dauNhay(string str)
        {
            //int k = str.Length;
            bool _ck = false;

            //for (int i = 0; i < k; i++)
            //{
            //    int ac = Convert.ToInt16(str[i]);
            if (str.Contains("\"") || str.Contains("'"))
            {
                _ck = true;
            }

            //}

            return _ck;
        }

        public static bool checkkytudacbiet(string s1)
        {
            try
            {
                if (s1.Contains("@") == true || s1.Contains("#") == true || s1.Contains("!") == true
                    || s1.Contains("$") == true || s1.Contains("%") == true || s1.Contains("^") == true
                    || s1.Contains("&") == true || s1.Contains("*") == true || s1.Contains("(") == true
                    || s1.Contains(")") == true || s1.Contains("_") == true
                    || s1.Contains("=") == true || s1.Contains("+") == true || s1.Contains("\\") == true
                    || s1.Contains("|") == true || s1.Contains("`") == true || s1.Contains("~") == true
                    || s1.Contains("<") == true || s1.Contains(">") == true || s1.Contains("?") == true
                    || s1.Contains("/") == true || s1.Contains(".") == true || s1.Contains("{") == true
                    || s1.Contains("}") == true || s1.Contains("[") == true || s1.Contains("]") == true
                    || s1.Contains(";") == true || s1.Contains(":") == true || s1.Contains(",") == true
                    || s1.Contains(Convert.ToString('"')) == true || s1.Contains("'") == true)
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// check all là khoảng trắng- dangtq
        /// = true là chứa all space
        /// </summary>
        public static bool CheckAllSpace(string s)
        {
            try
            {
                bool _ck = false;
                int counter = 0;
                int convertedPw;
                CharEnumerator charEnum = s.GetEnumerator();
                while (charEnum.MoveNext())
                {
                    convertedPw = Convert.ToInt32(s[counter]);

                    if (convertedPw == 32)
                    {
                        _ck = true;
                    }
                    else
                    {
                        _ck = false;
                        break;
                    }
                    counter++;
                }
                return _ck;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// dang tq check so nguyen ap dung cho cac truong tien te va hien thi dau , ngan cach 
        /// </summary>
        /// <param name="strnewAcc"></param>
        /// <returns></returns>
        public static bool CheckIsMoney(string strnewAcc)
        {
            try
            {
                bool _ck = false;
                int counter = 0;
                int convertedPw;
                CharEnumerator charEnum = strnewAcc.GetEnumerator();
                while (charEnum.MoveNext())
                {
                    convertedPw = Convert.ToInt32(strnewAcc[counter]);

                    if ((convertedPw >= 48) && (convertedPw <= 57))
                    {
                        _ck = true;
                    }
                    else if ((convertedPw == 44) || (convertedPw == 46))//dau phay va dau cham
                    {
                        _ck = true;
                    }
                    else
                    {
                        _ck = false;
                        break;
                    }
                    counter++;
                }

                return _ck;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// dang tq check so số thập phân 
        /// </summary>
        /// <param name="strnewAcc"></param>
        /// <returns></returns>
        public static bool checksothapphan(string strnewAcc)
        {
            try
            {
                bool _ck = false;
                int counter = 0;
                int convertedPw;
                CharEnumerator charEnum = strnewAcc.GetEnumerator();
                int count = 0;
                while (charEnum.MoveNext())
                {
                    convertedPw = Convert.ToInt32(strnewAcc[counter]);

                    if ((convertedPw >= 48) && (convertedPw <= 57))
                    {
                        _ck = true;
                    }
                    else if (convertedPw == 46 && count <= 0)//dau phay va dau cham
                    {
                        _ck = true;
                        count++;
                    }
                    else
                    {
                        _ck = false;
                        break;
                    }
                    counter++;
                }

                return _ck;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// dang tq check so số thập phân 
        /// </summary>
        /// <param name="strnewAcc"></param>
        /// <returns></returns>
        public static bool CheckSoThapPhan(string strnewAcc, int p_number_afer_cham)
        {
            try
            {
                //32,454.454000
                bool _ck = false;
                int counter = 0;
                int convertedPw;
                CharEnumerator charEnum = strnewAcc.GetEnumerator();
                int count = 0;
                int count_after_46 = 0;
                bool _is_46 = false;
                while (charEnum.MoveNext())
                {
                    convertedPw = Convert.ToInt32(strnewAcc[counter]);

                    if ((convertedPw >= 48) && (convertedPw <= 57))
                    {
                        _ck = true;
                        if (_is_46)
                        {
                            count_after_46++;
                            // không chỉ cho ấn 
                            if (count_after_46 > p_number_afer_cham)
                            {
                                _ck = false;
                                break;
                            }
                        }
                    }
                    else if (convertedPw == 46 || convertedPw == 44)//dau phay va dau cham
                    {
                        _ck = true;
                        if (convertedPw == 46) // dấu .
                        {
                            count++;
                            _is_46 = true;
                            // không cho ấn 2 dấu .
                            if (count > 1)
                            {
                                _ck = false;
                                break;
                            }
                        }
                        else
                        {
                            // nếu có dấu . rồi mà ấn thêm dấu , thì ko cho ấn
                            if (_is_46)
                            {
                                _ck = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        _ck = false;
                        break;
                    }
                    counter++;
                }

                return _ck;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// check all là khoảng trắng- dangtq
        /// = true là chứa all space
        /// </summary>
        public static bool checkAllSpace(string s)
        {
            try
            {
                bool _ck = false;
                int counter = 0;
                int convertedPw;
                CharEnumerator charEnum = s.GetEnumerator();
                while (charEnum.MoveNext())
                {
                    convertedPw = Convert.ToInt32(s[counter]);

                    if (convertedPw == 32)
                    {
                        _ck = true;
                    }
                    else
                    {
                        _ck = false;
                        break;
                    }
                    counter++;
                }
                return _ck;

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }


        /// <summary>
        /// Kiểm tra xem có lớn hơn 0 hay không
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool CheckGiaDuong(string st)
        {
            try
            {
                if (st.Contains(",") || st.Contains("."))
                    return false;
                else
                {
                    decimal Num;

                    bool isNum = decimal.TryParse(st, out Num);

                    if (isNum)
                    {
                        decimal.TryParse(st, out Num);
                        if (Num < 0)
                            return false;
                        else return true;
                    }
                    else
                        return false;
                }
            }
            catch  
            {
                return false;
            }
        }
    }
}
