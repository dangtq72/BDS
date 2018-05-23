using System;
using MemoryData;

namespace Starts_Controller
{
    internal class CommonData
    {
        //public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static StartsServiceWcf.AppServiceClient _serviceWCF;//service dùng chung cho cả hệ thống
        static object objLockService_ = new object();

        public static StartsServiceWcf.AppServiceClient c_serviceWCF
        {
            get
            {
                try
                {
                    lock (objLockService_)
                    {

                        if (_serviceWCF == null)
                        {
                            _serviceWCF = new StartsServiceWcf.AppServiceClient();
                            SetDefaultServiceConfig();
                        }
                        else if (_serviceWCF.State == System.ServiceModel.CommunicationState.Faulted)
                        {
                            _serviceWCF.Abort();
                            _serviceWCF = new StartsServiceWcf.AppServiceClient();
                            SetDefaultServiceConfig();
                        }
                        else if (_serviceWCF.State == System.ServiceModel.CommunicationState.Closed)
                        {
                            _serviceWCF = new StartsServiceWcf.AppServiceClient();
                            SetDefaultServiceConfig();
                        }

                        //mỗi lần gọi sẽ test kết nối, nếu kết nối ok thì sẽ set lại sendtimeout thành 10 phút
                        _serviceWCF.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(30);
                        string s = _serviceWCF.AllCode_CheckWCF();
                        if (s == "OK")
                        {
                            _serviceWCF.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10);
                        }
                        return _serviceWCF;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.log.Error(ex.ToString());
                    return new StartsServiceWcf.AppServiceClient();
                }
            }
        }

        //8/1/2013 LinhNN rem lai, chac khong can nua
        // 28/1/2013 DangTQ em mở ra vì nó ko mở cổng tới wcf khi bị mất kết nối
        public static void RestartWCFService()
        {
            try
            {
                if (_serviceWCF == null)
                {
                    _serviceWCF = new StartsServiceWcf.AppServiceClient();
                    SetDefaultServiceConfig();
                }
                else
                {
                    _serviceWCF.Abort();
                    _serviceWCF = new StartsServiceWcf.AppServiceClient();
                    SetDefaultServiceConfig();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
            }
        }

        private static void SetDefaultServiceConfig()
        {
            try
            {
                _serviceWCF.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(20);
                _serviceWCF.Endpoint.Binding.SendTimeout = TimeSpan.FromSeconds(20);
                _serviceWCF.Endpoint.Binding.OpenTimeout = TimeSpan.FromMinutes(1);
                _serviceWCF.Endpoint.Binding.CloseTimeout = TimeSpan.FromSeconds(10);

            }
            catch
            {
            }
        }

    }

    public class ConstPara
    {
        public const char Field = (char)0x02; //phan cach giua cac field
        public const char FieldValue = (char)0x01A;//phan cach giua field va value
    }
}
