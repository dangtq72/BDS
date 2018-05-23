using System;
using System.Collections.Generic;
using System.Text;
using MemoryData;
using ObjInfo;
using ZetaCompressionLibrary;
using System.Data;
namespace Starts_Controller
{
    public class Extend_Contract_Controller
    {
        public List<Extend_Contract_Info> Extend_Contract_GetByContractId(decimal Contract_Id)
        {
            try
            {
                byte[] byteRecive = CommonData.c_serviceWCF.Extend_Contract_GetByContractId(Contract_Id);
                DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                return CBO<Extend_Contract_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new List<Extend_Contract_Info>();
            }
        }

        public decimal Extend_Contract_Insert( Extend_Contract_Info p_Extend_Contract_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Extend_Contract_Insert(p_Extend_Contract_Info.Contract_Id, p_Extend_Contract_Info.Contract_FromDate, p_Extend_Contract_Info.Contract_ToDate,
                   p_Extend_Contract_Info.Extend_Date, p_Extend_Contract_Info.Term, p_Extend_Contract_Info.Fee, p_Extend_Contract_Info.FeeOnePay, p_Extend_Contract_Info.Price, p_Extend_Contract_Info.Number_Extend);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Extend_Contract_Update(Extend_Contract_Info p_Extend_Contract_Info)
        {
            try
            {
                return CommonData.c_serviceWCF.Extend_Contract_Update(p_Extend_Contract_Info.Contract_Id, p_Extend_Contract_Info.Contract_FromDate, p_Extend_Contract_Info.Contract_ToDate,
                   p_Extend_Contract_Info.Extend_Date, p_Extend_Contract_Info.Term, p_Extend_Contract_Info.Fee,
                   p_Extend_Contract_Info.FeeOnePay, p_Extend_Contract_Info.Price, p_Extend_Contract_Info.Fee_Status, p_Extend_Contract_Info.Extend_Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Get_Number_ExtendContract(decimal Contract_Id)
        {
            try
            {
                return CommonData.c_serviceWCF.Get_Number_ExtendContract(Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
