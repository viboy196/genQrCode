// See https://aka.ms/new-console-template for more information
using genQrCode;
using QrLib;
using System.Text.Json;
var _time = new DateTime();
_time.AddMinutes(60);
var strDate = _time.ToString("yyyyMMddHHmmss");

var arr = new List<DauVao>();
arr.AddRange(new DauVao[] { 
    new DauVao { giatri = "139818" , 
                mahoadon = "94" , 
                mota = ""}
,new DauVao { giatri = "139818" ,
                mahoadon = "95" ,
                mota = ""}
,
    new DauVao { giatri = "169725" ,
                mahoadon = "96" ,
                mota = ""}
,
    new DauVao { giatri = "125457" ,
                mahoadon = "97" ,
                mota = ""}
,
    new DauVao { giatri = "109238" ,
                mahoadon = "98" ,
                mota = ""}
,
    new DauVao { giatri = "54951" ,
                mahoadon = "99" ,
                mota = ""}
,
    new DauVao { giatri = "117348" ,
                mahoadon = "100" ,
                mota = ""}
,
    new DauVao { giatri = "219572" ,
                mahoadon = "101" ,
                mota = ""}
,
    new DauVao { giatri = "54951" ,
                mahoadon = "102" ,
                mota = ""}
,
    new DauVao { giatri = "179694" ,
                mahoadon = "103" ,
                mota = ""}
,
});
var arrDaura = new List<DauRa>();
arr.ForEach(x =>
{
    var str_1 = new GenQr().genQrBy(x.mota, x.mahoadon, x.giatri);
    var s = new DauRa { mahoadon = x.mahoadon, giatri = x.giatri, qrCode = str_1 };
    arrDaura.Add(s);
   
});
var s = JsonSerializer.Serialize<List<DauRa>>(arrDaura);
var results = System.Text.RegularExpressions.Regex.Unescape(s);
Console.WriteLine(results);