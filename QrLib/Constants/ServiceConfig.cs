using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QrLib
{
    public class ServiceConfig
    {
        public static string QR_IMAGE_TYPE = "png";
        public static int QR_IMAGE_SIZE = 255;
        public static string QR_IMAGE_FOLDER = "/resources/qrcode/";
        public static string QR_VIEW_PATH = "http://10.22.7.103:8080/QRCreateAPIRestV2/resources/qrcode/";
        public static string QR_VIEW_PATH_INTERNET = "http://14.160.87.122:8080/QRCreateAPIRestV2/resources/qrcode/";
        public static string API_ID = "restcreateqr";

        public static string LIST_PAYLOAD = "01,02";

        public static string PAYLOAD_FORMAT_INDICATOR = "01";
        public static string POINT_OF_METHOD_DONG = "12";
        public static string POINT_OF_METHOD_TINH = "11";

        public static string CCY = "704";

    }
}