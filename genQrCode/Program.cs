// See https://aka.ms/new-console-template for more information
using genQrCode;
using QrLib;
using System.Text.Json;
var _time = new DateTime();
_time.AddMinutes(60);
var strDate = _time.ToString("yyyyMMddHHmmss");

var arr = new List<DauVao>();
arr.AddRange(new DauVao[] {
    new DauVao { giatri = "597529" ,
                mahoadon = "126" }
});
var arrDaura = new List<DauRa>();
arr.ForEach(x =>
{
    var str_1 = new GenQr().genQrBy(x.mahoadon, x.giatri , null , null);
    var s = new DauRa { mahoadon = x.mahoadon, giatri = x.giatri, qrCode = str_1 };
    arrDaura.Add(s);
   
});
var s = JsonSerializer.Serialize<List<DauRa>>(arrDaura);
var results = System.Text.RegularExpressions.Regex.Unescape(s);
Console.WriteLine(results);