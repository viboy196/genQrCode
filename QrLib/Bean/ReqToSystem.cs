using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QrLib
{
    public class ReqToSystem
    {
        public string tokenKey{ get; set; }
        public string apiID{ get; set; }
        public string urlFolder{ get; set; }
        public QRBean qrBean{ get; set; }
        public string productName{ get; set; } // Ten san pham
        public string imageName{ get; set; } // Ten cua hinh anh dinh kem voi Qrcode do 
        public string creator{ get; set; }
        public string payType{ get; set; }
        public Boolean ismobileApp{ get; set; }
        public string sphere{ get; set; }
    }
}