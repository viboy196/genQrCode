using System;


namespace QrLib
{
  public class RequestCreateQrcode
  {
    public string appId { get; set; }
    public string merchantName { get; set; }//Don vi phat hanh
    public string serviceCode { get; set; }//Ma dich vu
    public string countryCode { get; set; }
    public string masterMerCode { get; set; }
    public string merchantType { get; set; }
    public string merchantCode { get; set; }// Ma merchant
    public string terminalId { get; set; }// Diem thu
    public string payType { get; set; } // Kieu thanh toán
    public string productName { get; set; }
    public string imageName { get; set; } // Ten cua hinh anh dinh kem voi Qrcode do
    public string productId { get; set; } //Ma San pham
    public string txnId { get; set; } //Ma don hang, Ma GD
    public string amount { get; set; } //So tien * 100
    public string tipAndFee { get; set; }
    public string ccy { get; set; } //Ma tien te
    public string expDate { get; set; }//Ngay het han
    public string desc { get; set; } // mo ta 
    public string checksum { get; set; } // checkSum
    public string merchantCity { get; set; } // bat buoc toi da 15 ky tu
    public string merchantCC { get; set; } // Merchant category code
    public string fixedFee { get; set; } // phi co dinh
    public string percentageFee { get; set; } // Gia tri phi phan tram
    public string pinCode { get; set; } // ma pin code cua khong bat buoc toi da 10 ky tu
    public string mobile { get; set; } // So dt su dung nap tien hoac thanh toan hoa don
    public string billNumber { get; set; } // So hoa don
    public string terminalName { get; set; }
    public string creator { get; set; }
    public string versionQR { get; set; }
    public string dataQR { get; set; }
    public string sphere { get; set; }
    public string termBill { get; set; } // Ky cuoc
    public string consumerID { get; set; } // Ma khach hang
    public string purpose { get; set; } // Ten dich vu

  }
}