using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace SanctionScannerCrawling
{
    public class Program
    {
     
        static void Main(string[] args)
        {
            //YORUM EKLE 
           
            string confirm = "Accept: text / html, application / xhtml + xml, */*";
            string userAgent = "User-Agent:Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36 (compatible; Googlebot/2.1; +https://www.google.com/bot.html)";

      

            var directoryDownload = @"C:\htmldownload\";
            string url = "https://www.sahibinden.com/anasayfa-vitrin?viewType=Gallery";
            string saveName = "test.html";

            string filepath = @"C:\htmldownload\test.html";

            int timer = 0;
            while(timer < 10){


                using (HttpService httpService = new HttpService())
                {
                    httpService.AddHeaders(confirm);
                    httpService.AddHeaders(userAgent);
                    httpService.DownloadFile(new Uri(url), directoryDownload + "/" + saveName);
                }

                using (RegexWritline regexWritline = new RegexWritline())
                {
                    regexWritline.ReadFile();
                    regexWritline.ReadName();
                }  
                 int milsec = 5000; 
                 Thread.Sleep(milsec);

                using (FileService fileService = new FileService())
                {
                    fileService.DeleteFile(filepath);
                }

            int milseco = 500000;
            Thread.Sleep(milseco);
            }


        }
     

    }
}
