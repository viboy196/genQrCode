// See https://aka.ms/new-console-template for more information
using genQrCode;
using QrLib;
using System.Text.Json;
var _time = new DateTime();
_time.AddMinutes(60);
var strDate = _time.ToString("yyyyMMddHHmmss");

var arr = new List<DauVao>();
arr.AddRange(new DauVao[] {
    new DauVao { giatri = "505937" ,
                mahoadon = "139" },

    new DauVao { giatri = "1531765" ,
                mahoadon = "140" },

    new DauVao { giatri = "799031" ,
                mahoadon = "141" },

    new DauVao { giatri = "799031" ,
                mahoadon = "142" }


});
var arrDaura = new List<DauRa>();
arr.ForEach(x =>
{
    var str_1 = new GenQr().genQrBy(x.mahoadon, x.giatri, null, null);
    var s = new DauRa { mahoadon = x.mahoadon, giatri = x.giatri, qrCode = new GenQr().formatString(str_1) };
    arrDaura.Add(s);

});
var s = JsonSerializer.Serialize<List<DauRa>>(arrDaura);
var results = System.Text.RegularExpressions.Regex.Unescape(s);
Console.WriteLine(results);