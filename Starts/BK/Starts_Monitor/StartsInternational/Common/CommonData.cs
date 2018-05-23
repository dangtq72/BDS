using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using ObjInfo;

namespace StartsInternational
{
    public enum ReturnValue
    {
        Susscess = 1,          //Neu thanh cong
        Error = -1             //Neu khong thanh cong
    }

    public class CommonData
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ArrayList c_arrQuyen = new ArrayList(); //danh sách cách quyền của user
        public static User_Info c_Urser_Info = new User_Info();
        public static string ExcelDesignFilePath = "report//";
        public static string c_All_Content = "--ALL--";
        public static string c_All_Value = "ALL";
        public static int RowTotalDock = 100;//Dung phan trang trong cac Dock
        //public static string c_all_value = "--ALL--";

        static string _ConnectionString = "";

        public static string ConnectionString
        {
            get
            {
                if (_ConnectionString == "")
                {
                    try
                    {
                        _ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                    }
                    catch
                    {
                        _ConnectionString = "";
                    }
                }

                return _ConnectionString;

            }
        }

        static int _day_quaHan = -1;

        public static int C_DayOfFee
        {
            get
            {
                if (_day_quaHan == -1)
                {
                    try
                    {
                        _day_quaHan = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["DayOfFee"]);
                    }
                    catch
                    {
                        _day_quaHan = 10;
                    }
                }

                return _day_quaHan;

            }
        }

        //Chuỗi kết nối đến File Excel (Bo di dung trong Controller.)
        public static string connectionStringExcel = "";

        public static string getcon(string fileName, string ex)
        {
            try
            {
                switch (ex)
                {
                    case ".xls": //Excel 97-03
                        connectionStringExcel = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=YES\";");
                        break;
                    case ".xlsx": //Excel 07
                        connectionStringExcel = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"");
                        break;
                }
                return connectionStringExcel;
            }
            catch
            {
                return "";
            }
        }
    }

    public enum Status_Type
    {
        ConHang = 1,
        DaBan = 0
    }

    public enum Form_Type
    {
        Insert = 0,
        Update = 1,
        View = 2
    }

    public enum User_Status_Type
    {
        Active = 1,
        UnActive = 0
    }
}
