using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryData
{
    public enum Enum_Estate_Status
    {
        Chua_Thue = 0,          
        Da_Thue = 1              
    }

    public enum Enum_Extend_Contract
    {
        Extend = 1,
        Not_Extend = 0
    }

    public enum Enum_Estate_Type
    {
        Houseing = 1,
        Building = 2
    }

    public enum Enum_Contract_Type
    {
        Renter = 1,
        Tenant = 2
    }

    public enum Enum_Customer_Type
    {
        CaNhan = 1,
        ToChuc = 2
    }

    public enum Enum_Contract_Status
    {
        Con_Han = 0,
        Dong_Trc_Thoi_Han = 1,
        Het_Han = 2,
        Gia_Han = 3,
        Close = 4,
        Den_Han_Thong_Bao = 99
    }

    public enum Enum_Contract_Currency
    {
        VND = 0,
        USD = 1
    }

    public enum Enum_Fee_Status
    {
        No_Pay = 0,
        Payed = 1
    }

    public enum Enum_HanFee
    {
        QuaHan = 1,
        SapDenHan = 2
    }

    public enum Enum_Fee_Maturity
    {
        Option = -1,
        One = 0,
        One_Month = 1,
        Three_Month = 2,
        Six_Month = 3,
        One_Year = 4
    }

    public class ErrorLog
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
