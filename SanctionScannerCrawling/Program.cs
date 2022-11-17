using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

namespace SanctionScannerCrawling
{
    public class Program
    {
     
        static void Main(string[] args)
        {

            //When the website does not accept the software, we send accept me like this.
            string confirm = "Accept: text / html, application / xhtml + xml, */*";
            //  We make ourselves look like a browser.
            string userAgent = "User-Agent:Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36 (compatible; Googlebot/2.1; +https://www.google.com/bot.html)";
           // File download path
           var directoryDownload = @"C:\htmldownload\";
            //url to download
            string url = "https://www.sahibinden.com/anasayfa-vitrin?viewType=Gallery";
            //We specify the name under which the file is saved.
            string saveName = "test.html";
            //The path of the file to be deleted.
            string filepath = @"C:\htmldownload\test.html";
            //Simple method for loop.
            int timer = 0;
            while(timer < 10){

                using (HttpService httpService = new HttpService())
                {
                   // Adding headers for the web server to accept us as a browser.
                    httpService.AddHeaders(confirm);
                    httpService.AddHeaders(userAgent);
                    //Here we print the download code. Link to download, where to download and under what name.
                    httpService.DownloadFile(new Uri(url), directoryDownload + "/" + saveName);
                }

                using (RegexWritline regexWritline = new RegexWritline())
                {
                   // The voids we call to read and print the file we downloaded to our computer.
                    regexWritline.ReadFile();
                    regexWritline.ReadName();
                }
               // Wait a bit before deleting the file.
                 int milsec = 5000; 
                 Thread.Sleep(milsec);


                using (FileService fileService = new FileService())
                {
                    
                   // File deletion code if there is a file path.
                 fileService.DeleteFile(filepath);
                }
                
                //A wait to restart every 5 minutes.
            int milseco = 500000;
            Thread.Sleep(milseco);
            }


        }
     

    }
}
