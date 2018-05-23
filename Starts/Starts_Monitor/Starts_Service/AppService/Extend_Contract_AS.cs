using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using MemoryData;
using ObjInfo;
using System.Data;
using ZetaCompressionLibrary;

namespace Starts_Service
{
    public partial interface IAppService
    {
        [OperationContract()]
        decimal Extend_Contract_Insert(decimal p_Contract_Id, DateTime Contract_FromDate, DateTime Contract_ToDate, DateTime Extend_Date, decimal Term,
          decimal Fee, decimal FeeOnePay, decimal Price, decimal Number_Extend);

        [OperationContract()]
        decimal Extend_Contract_Update(decimal p_Contract_Id, DateTime Contract_FromDate, DateTime Contract_ToDate, DateTime Extend_Date, decimal Term,
          decimal Fee, decimal FeeOnePay, decimal Price, decimal Fee_Status, decimal Extend_Contract_Id);

        [OperationContract()]
        byte[] Extend_Contract_GetByContractId(decimal Contract_Id);

        [OperationContract()]
        decimal Get_Number_ExtendContract(decimal Contract_Id);
    }

    public partial class AppService : IAppService
    {
        public decimal Extend_Contract_Insert(decimal p_Contract_Id, DateTime Contract_FromDate, DateTime Contract_ToDate, DateTime Extend_Date, decimal Term,
          decimal Fee, decimal FeeOnePay, decimal Price, decimal Number_Extend)
        {
            try
            {
                Extend_Contract_DA _Extend_Contract_DA = new Extend_Contract_DA();
                return _Extend_Contract_DA.Extend_Contract_Insert(p_Contract_Id, Contract_FromDate, Contract_ToDate, Extend_Date, Term, Fee, FeeOnePay, Price, Number_Extend);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public decimal Extend_Contract_Update(decimal p_Contract_Id, DateTime Contract_FromDate, DateTime Contract_ToDate, DateTime Extend_Date, decimal Term,
         decimal Fee, decimal FeeOnePay, decimal Price, decimal Fee_Status, decimal Extend_Contract_Id)
        {
            try
            {
                Extend_Contract_DA _Extend_Contract_DA = new Extend_Contract_DA();
                return _Extend_Contract_DA.Extend_Contract_Update(p_Contract_Id, Contract_FromDate, Contract_ToDate, Extend_Date, Term, Fee, FeeOnePay, Price, Fee_Status, Extend_Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }


        public byte[] Extend_Contract_GetByContractId(decimal Contract_Id)
        {
            try
            {
                byte[] byteReturn;
                Extend_Contract_DA _Extend_Contract_DA = new Extend_Contract_DA();
                DataSet ds = _Extend_Contract_DA.Extend_Contract_GetByContractId(Contract_Id);
                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public decimal Get_Number_ExtendContract(decimal Contract_Id)
        {
            try
            {
                Extend_Contract_DA _Extend_Contract_DA = new Extend_Contract_DA();
                return _Extend_Contract_DA.Get_Number_ExtendContract(Contract_Id);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
