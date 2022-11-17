using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SanctionScannerCrawling
{
    public class RegexWritline : IDisposable 
    {
        public void ReadFile()
        {
            string regexPriceType = "<span>\\s+(?<fiyat>[0-9.]*).*</span></h5>";
            string demoPath = @"C:\demo\demo.txt";
            string filepath = @"C:\htmldownload\test.html";

            Regex regex = new Regex(regexPriceType, RegexOptions.IgnoreCase);
            using (var sr = new StreamReader(filepath))
            {

                var contents = sr.ReadToEnd();
                var t = regex.Matches(contents);

                double toplam = 0;

                foreach (Match match in t)
                {
                    Console.WriteLine("Fiyatlar: " + match.Groups[1]);

                    toplam += Convert.ToDouble(match.Groups[1].Value);

                    if (File.Exists(filepath))
                    {
                        using (var sw = new StreamWriter(demoPath, true))
                        {


                            sw.WriteLine("PRICES : " + match.Groups[1]);

                            sw.Close();



                        }
                    }


                }
                //ortalama fiyat hesaplama 
                using (var sw = new StreamWriter(demoPath, true))
                {
                    sw.Write("Total Price Average: " + toplam / t.Count);
                }

                Console.WriteLine("Total Price Average: " + toplam / t.Count);


            }



        }
        public void ReadName()
        {
            string demoPath = @"C:\demo\demo.txt";
            string filepath = @"C:\htmldownload\test.html";
            string regexNameType = "<h2 class=\"item-title\">\\s+(?<title>.*)</h2>";

            Regex regexString = new Regex(regexNameType, RegexOptions.Multiline);
            using (var sr = new StreamReader(filepath))
            {
                var contents = sr.ReadToEnd();
                var nameRegex = regexString.Matches(contents);

                foreach (Match matching in nameRegex)
                {
                    Console.WriteLine("NAMES: " + matching.Groups[1]);

                    if (File.Exists(filepath))
                    {
                        using (var streamWriter = new StreamWriter(demoPath, true))
                        {


                            streamWriter.WriteLine("NAMES : " + matching.Groups[1]);

                            streamWriter.Close();

                        }
                    }
                }
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
