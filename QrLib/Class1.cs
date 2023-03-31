using System.Globalization;
using System.Text;

namespace QrLib
{
    public class GenQr
    {

        private string VND = "VND";
        private string EMPTY = "";

        public string formatString(string str)
        {
            var newOdd = str.Replace(" ", "%20");
            return newOdd;
        }
        public string genQrBy(string billNumber, string amount, string? expDate = null, string? desc = null)
        {
            RequestCreateQrcode data = new RequestCreateQrcode();

            data.masterMerCode = "970489";
            data.merchantCode = "0101826120";
            data.merchantType = "01";
            data.merchantName = "Cong ty procons";
            data.terminalId = "104004962202"; // Mã này cố định
            data.ccy = "704"; // Mã này cố định
            data.merchantCC = "4900";
            data.merchantCity = "Ha Noi";
            data.terminalName = "SHW";

            if (desc != null)
            {
                data.desc = desc;
            }
            data.amount = amount;
            data.payType = QRCode.PAY_TYPE_01; // "01"
            data.countryCode = "VN";
            data.billNumber = billNumber;
            data.txnId = billNumber;
            if (expDate != null)
            {
                data.expDate = expDate;
            }
            //data.customerID = "Nhập thông tin mã khách hàng của Mobifone tại đây"; // 




            string niceAddtionalData = RemoveDiacritics(desc);
            data.desc = niceAddtionalData;

            ReqToSystem req = makeRequestToSystem(data, true, "");
            QrPack pk = new QrPack();

            string qrData = pk.pack(req.qrBean, "").qrData;
            var str = "http://chart.apis.google.com/chart?chs=500x500&cht=qr&chl=" + qrData + "&choe=UTF-8";


            return "https://chart.apis.google.com/chart?chs=500x500&cht=qr&chl=" + qrData + "&choe=UTF-8";

        }
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        private ReqToSystem makeRequestToSystem(RequestCreateQrcode req, Boolean isInsert, string tokenKey)
        {
            try
            {
                Boolean ismobileApp = false;
                if (!isInsert)
                {
                    ismobileApp = true;
                }
                QRBean qrBean = makeQRBean(req, isInsert, tokenKey);
                ReqToSystem reqToSystem = new ReqToSystem();
                reqToSystem.apiID = "";
                reqToSystem.urlFolder = "";
                reqToSystem.tokenKey = tokenKey;
                reqToSystem.qrBean = qrBean;
                reqToSystem.payType = req.payType;
                reqToSystem.imageName = req.imageName;
                reqToSystem.productName = req.productName;
                reqToSystem.creator = req.creator;
                reqToSystem.ismobileApp = ismobileApp;
                reqToSystem.sphere = req.sphere;
                return reqToSystem;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private QRBean makeQRBean(RequestCreateQrcode request, Boolean isNotMobile, string tokenKey)
        {
            try
            {
                string referenceID = string.Empty;
                string pointOfMethod = ServiceConfig.POINT_OF_METHOD_TINH;
                string purpose = request.desc;
                string consumerID = string.Empty;
                string consumerAddress = string.Empty;

                string consumerMobile = string.Empty;

                string consumerEmail = string.Empty;


                if (QRCode.PAY_TYPE_01.Equals(request.payType))
                {
                    if (VND.Equals(request.ccy))
                    {
                        request.ccy = ServiceConfig.CCY;
                    }
                    if (!string.IsNullOrEmpty(request.desc) && request.desc.Length > 19)
                    {
                        purpose = request.desc.Substring(0, 19);
                    }
                    referenceID = QRCode.PAY_TYPE_01 + request.txnId;
                    pointOfMethod = ServiceConfig.POINT_OF_METHOD_DONG;
                }

                QRAddtionalBean addinalBean = new QRAddtionalBean();
                addinalBean.billNumber = request.billNumber;
                addinalBean.mobile = request.mobile;
                addinalBean.storeID = request.terminalName;
                addinalBean.loyaltyNumber = EMPTY;
                addinalBean.referenceID = referenceID;
                addinalBean.customerID = consumerID;
                addinalBean.purpose = RemoveDiacritics(purpose);
                addinalBean.expDate = request.expDate;
                addinalBean.terminalID = request.terminalId;
                addinalBean.consumerMobile = consumerMobile;
                addinalBean.consumerAddress = consumerAddress;
                addinalBean.consumerEmail = consumerEmail;

                QRBean bean = new QRBean();
                bean.payLoad = ServiceConfig.PAYLOAD_FORMAT_INDICATOR;
                bean.pointOIMethod = pointOfMethod;
                bean.merchantCode = request.merchantCode;
                bean.masterMerchant = request.masterMerCode;
                bean.merchantCC = request.merchantCC;
                bean.ccy = request.ccy;
                bean.amount = request.amount;
                bean.tipAndFee = request.tipAndFee;
                bean.fixedFee = request.fixedFee;
                bean.percentFee = request.percentageFee;
                bean.countryCode = request.countryCode;
                bean.merchantName = request.merchantName;
                bean.merchantCity = request.merchantCity;
                bean.pinCode = request.pinCode;
                bean.addtionalBean = addinalBean;
                bean.term = request.termBill;
                return bean;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}