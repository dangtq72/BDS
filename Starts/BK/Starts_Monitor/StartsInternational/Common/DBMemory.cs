using MemoryData;
using Starts_Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ObjInfo;

namespace StartsInternational.Common
{
    public class DBMemory
    {
        static Hashtable c_Allcode = new Hashtable();                                               //luu AllcodeInfo, key: cdname,cdval

        public static Hashtable c_hash_User = new Hashtable();                                      //luu UserInfo, key: Id

        public static List<User_FunctionsInfo> c_arrQuyen = new List<User_FunctionsInfo>();         //danh sách cách quyền của user
        public static Hashtable c_hash_Quyen = new Hashtable();                                     //danh sách cách quyền của user
        public static Hashtable c_hashFunctionList = new Hashtable();                               //danh sach cac function trong bang function

        public static List<User_Info> c_ar_Users = new List<User_Info>();                           // lưu danh sách các users
        public static Hashtable c_hash_Users = new Hashtable();                                     // lưu danh sách các users key là id của user đó

        public static Hashtable c_hs_Fee_Tenant_byContract = new Hashtable();                       // lưu các dữ liệu liên quan tới fee của ng cho thuê nhà
        public static Hashtable c_hs_Fee_Render_byContract = new Hashtable();                       // lưu các dữ liệu liên quan tới fee của ng thuê nhà

        public static List<Contract_Info> c_lst_contract_tennat = new List<Contract_Info>();        // lưu các dữ liệu liên quan tới hop dong ben cho thue nha
        public static List<Contract_Info> c_lst_contract_renter = new List<Contract_Info>();        // lưu các dữ liệu liên quan tới hop dong ben thue nha

        /// <summary>
        /// load tham số hệ thống
        /// </summary>
        public static void LoadParamSystem()
        {
            try
            {
                LoadAllCode();

                LoadUsers();

                LoadFeeTenant();

                LoadFeeRender();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        static void LoadUsers()
        {
            try
            {
                lock (c_hash_User.SyncRoot)
                {
                    c_ar_Users.Clear();
                    User_Controller _usercontrol = new User_Controller();

                    c_ar_Users = _usercontrol.User_Get_All();
                    c_hash_Users.Clear();
                    foreach (User_Info item in c_ar_Users)
                    {
                        c_hash_Users[item.User_Id] = item;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        static void LoadAllCode()
        {
            try
            {
                lock (c_Allcode.SyncRoot)
                {
                    Allcode_Controller _AllCodeController = new Allcode_Controller();
                    c_Allcode.Clear();
                    List<AllCode_Info> _lst_al = _AllCodeController.AllCode_Get_All();
                    if (_lst_al.Count > 0)
                    {
                        foreach (AllCode_Info item in _lst_al)
                        {
                            if (c_Allcode.ContainsKey(item.CdName + "|" + item.CdType) == false)
                            {
                                List<AllCode_Info> _lst = new List<AllCode_Info>();
                                _lst.Add(item);
                                c_Allcode[item.CdName + "|" + item.CdType] = _lst;
                            }
                            else
                            {
                                List<AllCode_Info> _lst = (List<AllCode_Info>)c_Allcode[item.CdName + "|" + item.CdType];
                                _lst.Add(item);
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public static void LoadFeeTenant()
        {
            try
            {
                #region Fee
                lock (c_hs_Fee_Tenant_byContract.SyncRoot)
                {
                    Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();
                    c_hs_Fee_Tenant_byContract.Clear();

                    List<Fees_Revenue_Info> _lst_al = _Fees_Revenue_Controller.Fees_Revenue_GetByObjectType((decimal)Enum_Contract_Type.Tenant);

                    if (_lst_al.Count > 0)
                    {
                        foreach (Fees_Revenue_Info item in _lst_al)
                        {
                            if (c_hs_Fee_Tenant_byContract.ContainsKey(item.Contract_Id) == false)
                            {
                                List<Fees_Revenue_Info> _lst = new List<Fees_Revenue_Info>();
                                _lst.Add(item);
                                c_hs_Fee_Tenant_byContract[item.Contract_Id] = _lst;
                            }
                            else
                            {
                                List<Fees_Revenue_Info> _lst = (List<Fees_Revenue_Info>)c_hs_Fee_Tenant_byContract[item.Contract_Id];
                                _lst.Add(item);
                            }

                        }
                    }
                } 
                #endregion

                #region Hợp đồng

                Contract_Controller c_Contract_Controller = new Contract_Controller();
                c_lst_contract_tennat = c_Contract_Controller.Contract_GetBy_Type((decimal)Enum_Contract_Type.Tenant);
                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public static void LoadFeeRender()
        {
            try
            {
                #region Fee
                lock (c_hs_Fee_Render_byContract.SyncRoot)
                {
                    Fees_Revenue_Controller _Fees_Revenue_Controller = new Fees_Revenue_Controller();
                    c_hs_Fee_Render_byContract.Clear();

                    List<Fees_Revenue_Info> _lst_al = _Fees_Revenue_Controller.Fees_Revenue_GetByObjectType((decimal)Enum_Contract_Type.Renter);

                    if (_lst_al.Count > 0)
                    {
                        foreach (Fees_Revenue_Info item in _lst_al)
                        {
                            if (c_hs_Fee_Render_byContract.ContainsKey(item.Contract_Id) == false)
                            {
                                List<Fees_Revenue_Info> _lst = new List<Fees_Revenue_Info>();
                                _lst.Add(item);
                                c_hs_Fee_Render_byContract[item.Contract_Id] = _lst;
                            }
                            else
                            {
                                List<Fees_Revenue_Info> _lst = (List<Fees_Revenue_Info>)c_hs_Fee_Render_byContract[item.Contract_Id];
                                _lst.Add(item);
                            }
                        }
                    }
                } 
                #endregion

                #region Hợp đồng

                Contract_Controller c_Contract_Controller = new Contract_Controller();
                c_lst_contract_renter = c_Contract_Controller.Contract_GetBy_Type((decimal)Enum_Contract_Type.Renter);
                #endregion
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public static void LoadFunctionUsers()
        {
            try
            {
                FunctionsController _FunctionsController = new FunctionsController();
                ArrayList _arr = _FunctionsController.Function_GetAll();
                c_hashFunctionList.Clear();
                foreach (FunctionsInfo _FuncInfo in _arr)
                {
                    if (_FuncInfo.objname != null && _FuncInfo.objname != "")
                        c_hashFunctionList[_FuncInfo.objname] = _FuncInfo;
                }

                User_Controller _UserControler = new User_Controller();
                c_arrQuyen = _UserControler.Send_Users_Get_MenuItem(CommonData.c_Urser_Info.User_Name);
                c_hash_Quyen.Clear();
                foreach (User_FunctionsInfo item in c_arrQuyen)
                {
                    if (item.name != null)
                        c_hash_Quyen[item.name] = item;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        public static List<AllCode_Info> AllCode_GetBy_CdNameCdType(string p_cdname, string p_cdtype)
        {
            try
            {

                if (c_Allcode.ContainsKey(p_cdname + "|" + p_cdtype))
                {
                    List<AllCode_Info> _lst = new List<AllCode_Info>();

                    List<AllCode_Info> _lst_tem = (List<AllCode_Info>)c_Allcode[p_cdname + "|" + p_cdtype];

                    foreach (AllCode_Info item in _lst_tem)
                    {
                        _lst.Add(item);
                    }

                    return _lst;
                }
                else return new List<AllCode_Info>();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<AllCode_Info>();
            }
        }

        /// <summary>
        /// Kiểm tra xem có phải là sắp đến thời hạn đóng phí môi giới hay không ( quá hạn trong vòng 10 ngày)
        /// </summary>
        public static bool KiemTra_SapDenHan_ThanhToan(decimal p_Contract_Id)
        {
            try
            {
                if (DBMemory.c_hs_Fee_Tenant_byContract.ContainsKey(p_Contract_Id) == false)
                {
                    return false;
                }

                List<Fees_Revenue_Info> _lst_Fee = (List<Fees_Revenue_Info>)DBMemory.c_hs_Fee_Tenant_byContract[p_Contract_Id];

                foreach (Fees_Revenue_Info item in _lst_Fee)
                {
                    if (item.Pay_Status == (decimal)Enum_Fee_Status.No_Pay &&
                        DateTime.Now.AddDays(CommonData.C_DayOfFee).Date >= item.Pay_Date_Expected.Date)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra xem có phải là quá hạn đóng phí môi giới hay không ( quá hạn trong vòng 10 ngày)
        /// </summary>
        public static bool KiemTra_QuaHan_ThanhToan(decimal p_Contract_Id)
        {
            try
            {
                if (DBMemory.c_hs_Fee_Tenant_byContract.ContainsKey(p_Contract_Id) == false)
                {
                    return false;
                }

                List<Fees_Revenue_Info> _lst_Fee = (List<Fees_Revenue_Info>)DBMemory.c_hs_Fee_Tenant_byContract[p_Contract_Id];

                foreach (Fees_Revenue_Info item in _lst_Fee)
                {
                    if (item.Pay_Status == (decimal)Enum_Fee_Status.No_Pay &&
                        DateTime.Now.Date >= item.Pay_Date_Expected.Date)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }
    }
}
