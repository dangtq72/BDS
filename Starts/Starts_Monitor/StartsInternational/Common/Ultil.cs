using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Windows;
using System.IO;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Data;

namespace StartsInternational.Common
{
    public class Ultil
    {

        public static ResourceDictionary GetResourceDictionaryfromString(string xamlResource)
        {
            try
            {
                if (xamlResource != "")
                {
                    StringReader _StringReader = new StringReader(xamlResource);
                    System.Xml.XmlReader _XmlReader = System.Xml.XmlReader.Create(_StringReader);

                    ResourceDictionary dict;
                    dict = (ResourceDictionary)System.Windows.Markup.XamlReader.Load(_XmlReader);
                    return dict;
                }
                else
                    return new ResourceDictionary();
            }
            catch
            {
                return new ResourceDictionary();
            }
        }

        public static string ResourceDictionary2String(ResourceDictionary p_ResourceDictionary)
        {
            try
            {
                System.Text.StringBuilder _sb = new System.Text.StringBuilder();
                StringWriter _sw = new StringWriter(_sb);

                System.Windows.Markup.XamlWriter.Save(p_ResourceDictionary, _sw);
                return _sb.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static string GetStringLeng(string ResourceKey)
        {
            try
            {
                if (App.Current.Resources.Contains(ResourceKey))
                    return (string)App.Current.Resources[ResourceKey];
                else
                    return ResourceKey;
            }
            catch
            {
                return ResourceKey;
            }
        }
        //Vutt thêm, lưu obj ResourceDictionary thành file xaml
        public static void SaveResourceDictionary2xaml(ResourceDictionary p_ResourceDictionary, string moduleName, string cultureName)
        {
            try
            {
                //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
                //XmlWriterSettings settings = new XmlWriterSettings();
                //settings.Indent = true;
                //StringBuilder sb = new StringBuilder();
                //string path;
                //path = Common.ConstPara.path + moduleName + "." + Thread.CurrentThread.CurrentCulture.ToString() + ".xaml";
                //XmlWriter writer = XmlWriter.Create(path, settings);
                //XamlWriter.Save(p_ResourceDictionary, writer);
            }
            catch
            {

            }
        }

        /// <summary>
        /// lấy năm trong khoảng
        /// </summary>
        public static ArrayList GetYear(int from, int to)
        {
            try
            {
                ArrayList _arryear = new ArrayList();
                for (int i = from; i <= to; i++)
                {
                    _arryear.Add(i);
                }
                return _arryear;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// lấy danh sách id trong chuỗi a|b|c|d ....
        /// </summary>
        /// <param name="qst">chuỗi truyền vào</param>
        /// <returns>trả ra danh sách id trong chuỗi</returns>
        public static ArrayList GetListIdFromString(string qst)
        {
            try
            {
                ArrayList _arr = new ArrayList();

                string[] words = qst.Split('|');
                foreach (string item in words)
                {
                    _arr.Add(Convert.ToDecimal(item));
                }
                return _arr;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// check xem các phần tử của mảng child có nằm trong mảng parent hay không
        /// </summary>
        /// <param name="arrparent">mảng cha</param>
        /// <param name="arrchild">mảng con</param>
        /// <returns>= false nếu sai</returns>
        public static bool CheckArrayIsChild(ArrayList arrparent, ArrayList arrchild)
        {
            try
            {
                bool _ck = true;
                if (arrchild.Count > arrparent.Count)
                    _ck = false;
                else if (arrchild.Count == 0)
                {
                    _ck = true; // nếu mà mảng con không có phần tử, áp dụng cho những trường hợp mà inputAllow = N và MatchtypeAllow = N
                }
                else
                {
                    for (int i = 0; i < arrchild.Count; i++)
                    {
                        string temchild = arrchild[i].ToString();

                        if (!CheckNumberInArray(temchild, arrparent))
                        {
                            _ck = false;
                            break;
                        }
                    }
                }
                return _ck;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// check xem số có thuộc mảng hay không
        /// </summary>
        public static bool CheckNumberInArray(string number, ArrayList Parent)
        {
            try
            {
                bool _ck = true;
                for (int i = 0; i < Parent.Count; i++)
                {
                    string tem = Parent[i].ToString();
                    if (tem == number)
                    {
                        _ck = true;
                        break;
                    }
                    else
                    {
                        _ck = false;
                    }
                }

                return _ck;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách các children control của 1 parent control. Đây là các childen theo Visual, tức là các childen mà hệ thống hiển thị.
        /// Ví dụ sử dụng: foreach (RibbonButton tb in FindVisualChildren<RibbonButton>(this))
        /// {
        ///         _str = _str + tb.Name + ";";
        /// }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                int n = System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj);

                for (int i = 0; i < n; i++)
                {
                    DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// Lấy danh sách các children control của 1 parent control. Đây là các childen theo Logical, tức là các childen mà khai báo. 
        /// Ví dụ sử dụng: foreach (RibbonButton tb in FindLogicalChildren<RibbonButton>(this))
        /// {
        ///         _str = _str + tb.Name + ";";
        /// }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindLogicalChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {

                foreach (object _obj in LogicalTreeHelper.GetChildren(depObj))
                {
                    if (_obj != null && _obj is T)
                    {
                        yield return (T)_obj;
                    }

                    if (_obj is DependencyObject)
                    {
                        foreach (T childOfChild in FindLogicalChildren<T>((DependencyObject)_obj))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Lay control cha cua 1 control bat ky
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static T FindLogicalParent<T>(DependencyObject depObj) where T : DependencyObject
        {
            try
            {
                T parent = default(T);
                if (depObj != null)
                {
                    DependencyObject _obj = LogicalTreeHelper.GetParent(depObj);
                    parent = _obj as T;
                    if (parent == null)
                    {
                        parent = FindLogicalParent<T>(_obj);
                    }
                }
                return parent;
            }
            catch
            {
                return default(T);
            }
        }

        public static string checkfunction(string menuitem)
        {
            try
            {
                string result = "";
                //foreach (User_FunctionsInfo quyen in  CommonData.c_arrQuyen)
                //{
                //    if (quyen.name == menuitem)
                //    {
                //        result = quyen.right;
                //        break;
                //    }
                //}
                return result;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return "";
            }
        }

        /// <summary>
        /// sắp xếp dữ liệu của mảng theo thứ tự tăng dần
        /// </summary>
        public static ArrayList SortData(ArrayList arr, string NameColumn)
        {
            try
            {
                ArrayList _arr = new ArrayList();
                DataGrid _gridtemp = new DataGrid();
                _gridtemp.ItemsSource = arr;
                SortDescription sortDesCrip11 = new SortDescription(NameColumn, ListSortDirection.Ascending);
                _gridtemp.Items.SortDescriptions.Add(sortDesCrip11);
                for (int i = 0; i < _gridtemp.Items.Count - 1; i++)
                {
                    _arr.Add(_gridtemp.Items[i]);
                }
                return _arr;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        /// <summary>
        /// sắp xếp dữ liệu của hash theo thứ tự tăng dần
        /// </summary>
        public static Hashtable Sort_Hash_Data(Hashtable p_hs, string NameColumn)
        {
            try
            {
                Hashtable _new_hs = new Hashtable();
                DataGrid _gridtemp = new DataGrid();
                _gridtemp.ItemsSource = p_hs.Values;
                SortDescription sortDesCrip11 = new SortDescription(NameColumn, ListSortDirection.Ascending);
                _gridtemp.Items.SortDescriptions.Add(sortDesCrip11);
                for (int i = 0; i < _gridtemp.Items.Count - 1; i++)
                {
                    _new_hs.Add(i, _gridtemp.Items[i]);
                }
                return p_hs;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new Hashtable();
            }
        }

        public static int GetRandomNumber(int p_from, int p_to)
        {
            try
            {
                Random rnd = new Random();
                return rnd.Next(p_from, p_to);
            }
            catch
            {
                return p_from;
            }
        }

    }
}
