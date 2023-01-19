using System;

namespace QrLib
{
    public class QRBean
    {
        public string payLoad{ get; set; }

        public string pointOIMethod{ get; set; }

        public string masterMerchant{ get; set; } // to chuc dang ky like master merchant

        public string merchantCode{ get; set; }

        public string merchantCC{ get; set; }

        public string ccy{ get; set; }

        public string amount{ get; set; }

        public string tipAndFee{ get; set; }

        public string fixedFee{ get; set; }

        public string percentFee{ get; set; }

        public string countryCode{ get; set; }

        public string merchantName{ get; set; }

        public string merchantCity{ get; set; }

        public string pinCode{ get; set; }

        public string addtionalData{ get; set; }

        public string term{ get; set; } // Ky cuoc hoa don
        public string crc16{ get; set; }

        public QRAddtionalBean addtionalBean{ get; set; }
    }
}