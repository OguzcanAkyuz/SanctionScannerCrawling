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
            
           
            string confirm = "Accept: text / html, application / xhtml + xml, */*";
            string userAgent =  "User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            string userAgent2 = "User-Agent: Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) ";
            string userAgent3 = "User-Agent:Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36 (compatible; Googlebot/2.1; +https://www.google.com/bot.html)";
            string userAgent4 = "User-Agent:Mozilla/5.0 (Windows NT 6.4; WOW64; Trident/7.0; .NET4.0E; .NET4.0C; rv:11.0) like Gecko";
            var indirilecekDizin = @"C:\htmldowland";
            string URL = "https://www.sahibinden.com/anasayfa-vitrin?viewType=Gallery";
            string dosyaAdi = "test.html";
            string dosyaYolu = @"C:\htmldowland\test.html";
            int timer = 0;
            while(timer < 10){ 
            WebClient webClient = new WebClient();
            webClient.Headers.Add(confirm);
            webClient.Headers.Add(userAgent3);
           
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFile(new Uri(URL), indirilecekDizin + "/" + dosyaAdi);
                
            FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
             fs.Close();
             RegexWritline.DosyaOku();

             RegexWritline.IsimOku();
                
             int milsec = 10000;
            Thread.Sleep(milsec);

               
             if (System.IO.File.Exists(dosyaYolu))
            {
             System.IO.File.Delete(dosyaYolu);
            }

            int milseco = 500000;
            Thread.Sleep(milseco);
            }


        }
        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }
        private static void Completed(object sender, AsyncCompletedEventArgs e)
        {
        }

    }
}
