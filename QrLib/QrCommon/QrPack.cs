using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace QrLib
{
    public class QrPack
    {

        /**
         *
         * @return
         */
        private string padLeft(int lenght)
        {
            //if (lenght > 99)
            //{
            //    throw new Exception("Lenght field can not be greater than 99");
            //}
            return lenght.ToString().PadLeft(2, '0');
        }

        private static string EXPIRE_DATE_EMPTY = "0000000000";

        private string packMerchant(QRBean bean)
        {
            string content = "";
            if (!string.IsNullOrEmpty(bean.masterMerchant))
            {
                content += QRTag.MC_ACCOUNT_GUID;
                content += padLeft(bean.masterMerchant.Length);
                content += bean.masterMerchant;
            }
            if (!string.IsNullOrEmpty(bean.merchantCode))
            {
                content += QRTag.MC_ACCOUNT_MC_ID;
                content += padLeft(bean.merchantCode.Length);
                content += bean.merchantCode;
            }
            return content;
        }
        /**
     *
     * @param bean
     * @param privateKey
     * @return
     * @throws vn.vnpay.qr.exception.InvalidLenghtException
     */
        public QRPackBean pack(QRBean bean, string privateKey)
        {
            string content = "";
            if (!string.IsNullOrEmpty(bean.payLoad))
            {
                content += QRTag.PAY_LOAD;
                content += padLeft(bean.payLoad.Length);
                content += bean.payLoad;
            }
            if (!string.IsNullOrEmpty(bean.pointOIMethod))
            {
                content += QRTag.POINT_OI_METHOD;
                content += padLeft(bean.pointOIMethod.Length);
                content += bean.pointOIMethod;
            }
            string merchantAccount = packMerchant(bean);
            if (!string.IsNullOrEmpty(merchantAccount))
            {
                content += QRTag.MC_ACCOUNT;
                content += padLeft(merchantAccount.Length);
                content += merchantAccount;
            }
            if (!string.IsNullOrEmpty(bean.merchantCC))
            {
                content += QRTag.MC_CATEGORY_CODE;
                content += padLeft(bean.merchantCC.Length);
                content += bean.merchantCC;
            }
            if (!string.IsNullOrEmpty(bean.ccy))
            {
                content += QRTag.CCY;
                content += padLeft(bean.ccy.Length);
                content += bean.ccy;
            }
            if (!string.IsNullOrEmpty(bean.amount))
            {
                content += QRTag.AMOUNT;
                content += padLeft(bean.amount.Length);
                content += bean.amount;
            }
            if (!string.IsNullOrEmpty(bean.tipAndFee))
            {
                content += QRTag.TIP_AND_FEE;
                content += padLeft(bean.tipAndFee.Length);
                content += bean.tipAndFee;
            }
            if (!string.IsNullOrEmpty(bean.fixedFee))
            {
                content += QRTag.FIXED_FEE;
                content += padLeft(bean.fixedFee.Length);
                content += bean.fixedFee;
            }
            if (!string.IsNullOrEmpty(bean.percentFee))
            {
                content += QRTag.PERCENT_FEE;
                content += padLeft(bean.percentFee.Length);
                content += bean.percentFee;
            }
            if (!string.IsNullOrEmpty(bean.countryCode))
            {
                content += QRTag.COUNTRY_CODE;
                content += padLeft(bean.countryCode.Length);
                content += bean.countryCode;
            }
            if (!string.IsNullOrEmpty(bean.merchantName))
            {
                content += QRTag.MC_NAME;
                content += padLeft(bean.merchantName.Length);
                content += bean.merchantName;
            }
            if (!string.IsNullOrEmpty(bean.merchantCity))
            {
                content += QRTag.MC_CITY;
                content += padLeft(bean.merchantCity.Length);
                content += bean.merchantCity;
            }
            if (!string.IsNullOrEmpty(bean.pinCode))
            {
                content += QRTag.MC_PIN_CODE;
                content += padLeft(bean.pinCode.Length);
                content += bean.pinCode;
            }
            string addtionalData = packAddtional(bean.addtionalBean, privateKey);
            bean.addtionalData = addtionalData;
            if (!string.IsNullOrEmpty(addtionalData))
            {
                content += QRTag.ADDTIONAL_DATA;
                content += padLeft(addtionalData.Length);
                content += addtionalData;
            }

            if (!string.IsNullOrEmpty(bean.term))
            {
                content += QRTag.TERM;
                content += padLeft(bean.term.Length);
                content += bean.term;
            }

            string dataToCRC = content + QRTag.CRC16 + QRTag.CRC_LENGHT;
            string crc16 = CRC16.CalcCRC16(dataToCRC);
            bean.crc16 = crc16;
            QRPackBean pack = new QRPackBean();
            pack.qrBean = bean;
            pack.qrData = dataToCRC + crc16;
            return pack;
        }

        /**
         *
         * @param bean
         * @param privateKey
         * @return
         * @throws vn.vnpay.qr.exception.InvalidLenghtException
         */
        public string packAddtional(QRAddtionalBean bean, string privateKey)
        {
            string content = "";
            if (!string.IsNullOrEmpty(bean.billNumber))
            {
                content += QRTag.BILL_NUMBER;
                content += padLeft(bean.billNumber.Length);
                content += bean.billNumber;
            }
            if (!string.IsNullOrEmpty(bean.storeID))
            {
                content += QRTag.STORE_ID;
                content += padLeft(bean.storeID.Length);
                content += bean.storeID;
            }

            if (!string.IsNullOrEmpty(bean.referenceID))
            {
                string referenceID;
                string clearReferenceID = bean.referenceID.Substring(2);
                string prefix = bean.referenceID.Substring(0, 2);
                if (!string.IsNullOrEmpty(bean.expDate))
                {
                    referenceID = prefix + bean.expDate + clearReferenceID;
                }
                else
                {
                    referenceID = prefix + EXPIRE_DATE_EMPTY + clearReferenceID;
                }
                content += QRTag.REFERENCE_NUMBER;
                content += padLeft(referenceID.Length);
                content += referenceID;
            }
            if (!string.IsNullOrEmpty(bean.customerID))
            {
                content += QRTag.CUSTOMER_ID;
                content += padLeft(bean.customerID.Length);
                content += bean.customerID;
            }

            if (!string.IsNullOrEmpty(bean.terminalID))
            {
                content += QRTag.TERMINAL_ID;
                content += padLeft(bean.terminalID.Length);
                content += bean.terminalID;
            }

            if (!string.IsNullOrEmpty(bean.purpose))
            {
                content += QRTag.PERPOSE;
                content += padLeft(bean.purpose.Length);
                content += RemoveDiacritics(bean.purpose);
            }

            string consumerData = "";
            if (!string.IsNullOrEmpty(bean.consumerAddress))
            {
                consumerData = bean.consumerAddress;
            }
            if (!string.IsNullOrEmpty(bean.consumerMobile))
            {
                consumerData = consumerData + bean.consumerMobile;
            }
            if (!string.IsNullOrEmpty(bean.consumerEmail))
            {
                consumerData = consumerData + bean.consumerEmail;
            }
            if (!string.IsNullOrEmpty(consumerData))
            {
                content += QRTag.CONSUMER_DATA;
                content += padLeft(consumerData.Length);
                content += consumerData;
            }
            return content;
        }


        public string RemoveDiacritics(string text)
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

    }
}