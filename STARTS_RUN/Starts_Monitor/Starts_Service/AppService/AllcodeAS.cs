
using System;
using System.ServiceModel;
using System.Data;
using ZetaCompressionLibrary;

using MemoryData;
using System.ServiceModel.Channels;
using WServiceGetData;


namespace Starts_Service
{
    [ServiceContract()]
    public partial interface IAppService
    {
        [OperationContract()]
        byte[] AllCode_Gets();

        [OperationContract()]
        byte[] AllCode_GetBy_CdNameCdType(string p_cdtype, string p_cdname);

        [OperationContract()]
        string AllCode_CheckWCF();

        [OperationContract()]
        DateTime Get_Current_Date_Computer_Run_Service();

    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                   ConcurrencyMode = ConcurrencyMode.Multiple,
                   UseSynchronizationContext = false)]
    public partial class AppService : IAppService
    {
        public static int StartRun()
        {
            try
            {
                ConfigInfo.GetConfig();
                if (Check_Connect_DataBase() == false)
                {
                    return -2;
                }
                return 0;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return -1;
            }
        }

        public AppService()
        {
            //OperationContext context = OperationContext.Current;
            //MessageProperties messageProperties = context.IncomingMessageProperties;
            //RemoteEndpointMessageProperty endpointProperty =
            //    messageProperties[RemoteEndpointMessageProperty.Name]
            //    as RemoteEndpointMessageProperty;
        }

        public byte[] AllCode_Gets()
        {
            try
            {
                byte[] byteReturn;
                AllCodeDA objAllCodeDA = new AllCodeDA();
                DataSet ds = objAllCodeDA.AllCode_Gets();

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }

        public byte[] AllCode_GetBy_CdNameCdType(string p_cdtype, string p_cdname)
        {
            try
            {
                byte[] byteReturn;
                AllCodeDA objAllCodeDA = new AllCodeDA();
                DataSet ds = objAllCodeDA.AllCode_GetBy_CdNameCdType(p_cdtype, p_cdname);

                byteReturn = CompressionHelper.CompressDataSet(ds);
                return byteReturn;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return new byte[0];
            }
        }
 

        public string AllCode_CheckWCF()
        {
            return "OK";
        }

        /// <summary>
        /// lấy ngày hệ thống trên máy chạy service
        /// </summary>
        /// <returns></returns>
        public DateTime Get_Current_Date_Computer_Run_Service()
        {
            try
            {
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return DateTime.Now;
            }
        }

        static bool Check_Connect_DataBase()
        {
            try
            {
                AllCodeDA objAllCodeDA = new AllCodeDA();
                DataSet ds = objAllCodeDA.AllCode_Gets();

                if (ds != null && ds.Tables.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return false;
            }
        }

    }
}
