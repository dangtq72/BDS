using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;

namespace Starts_Controller
{
    public class Customer_Controller
    {
        public List<Customer_Info> Customer_GetAll()
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Customer_GetAll();
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Customer_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Customer_Info>();
            }
        }

        public Customer_Info Customer_GetById(decimal Customer_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Customer_GetById(Customer_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                List<Customer_Info> _lst = CBO<Customer_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0)
                {
                    return _lst[0];
                }
                else return new Customer_Info();
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new Customer_Info();
            }
        }

        public bool Customer_Delete(decimal Customer_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Customer_Delete(Customer_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Customer_Check_In_Contract(decimal Customer_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Customer_Check_In_Contract(Customer_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int _count = Convert.ToInt16(ds.Tables[0].Rows[0]["count_c"].ToString());

                    if (_count > 0)
                    {
                        return false;
                    }
                    else return true;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Customer_Update(decimal Customer_Id, Customer_Info p_Customer_Info,Customer_Info p_old)
        {
            try
            {
                Traces_Log_Controllers _traceControler = new Traces_Log_Controllers();
                _traceControler.Trace_Insert("CUSTOMER", "UPDATE", p_Customer_Info.Modifi_By, p_Customer_Info, p_old);


                return CommonData.c_serviceWCF.Customer_Update(Customer_Id, p_Customer_Info.Customer_Name, p_Customer_Info.Phone, p_Customer_Info.Fax, p_Customer_Info.Identity_Card,
                    p_Customer_Info.Address, p_Customer_Info.Tax_Code, p_Customer_Info.Customer_Type, p_Customer_Info.Is_Person, p_Customer_Info.Position);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Customer_Insert(Customer_Info p_Customer_Info)
        {
            try
            {
                Traces_Log_Controllers _traceControler = new Traces_Log_Controllers();
                _traceControler.Trace_Insert("CUSTOMER", "INSERT", p_Customer_Info.Created_By, p_Customer_Info);

                return CommonData.c_serviceWCF.Customer_Insert(p_Customer_Info.Customer_Name, p_Customer_Info.Phone, p_Customer_Info.Fax, p_Customer_Info.Identity_Card,
                    p_Customer_Info.Address, p_Customer_Info.Tax_Code, p_Customer_Info.Customer_Type, p_Customer_Info.Is_Person, p_Customer_Info.Position);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public List<Customer_Info> Customer_Search(string p_name, string p_Phone)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Customer_Search(p_name, p_Phone);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Customer_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Customer_Info>();
            }
        }
    }
}
