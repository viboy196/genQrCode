using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QrLib
{
  public class QRTag
    {
    public static String PAY_LOAD = "00";

    public static String POINT_OI_METHOD = "01";

    public static String MC_ACCOUNT = "26";

    public static String MC_ACCOUNT_GUID = "00";

    public static String MC_ACCOUNT_MC_ID = "01";

    public static String MC_CATEGORY_CODE = "52";

    public static String CCY = "53";

    public static String AMOUNT = "54";

    public static String TIP_AND_FEE = "55";

    public static String FIXED_FEE = "56";

    public static String PERCENT_FEE = "57";

    public static String COUNTRY_CODE = "58";

    public static String MC_NAME = "59";

    public static String MC_CITY = "60";

    public static String MC_PIN_CODE = "61";

    public static String ADDTIONAL_DATA = "62";

    public static String CRC16 = "63";

    /**
     * For addtional data of Qrcode
     */
    public static String BILL_NUMBER = "01";

    public static String STORE_ID = "03"; // Terminal name

    public static String LOYALTY_NUMBER = "04";

    public static String REFERENCE_NUMBER = "05";

    public static String CUSTOMER_ID = "06";

    public static String TERMINAL_ID = "07";

    public static String PERPOSE = "08";

    public static String CONSUMER_DATA = "09";

    public static String ADDRESS = "A";

    public static String MOBILE = "M";

    public static String EMAIL = "E";

    public static String EXPIRE_DATE = "51";

    public static String CHECK_SUM_ADDTIONAL = "52";

    public static String TERM = "80";
  
    public static String CRC_LENGHT = "04";
  }
}