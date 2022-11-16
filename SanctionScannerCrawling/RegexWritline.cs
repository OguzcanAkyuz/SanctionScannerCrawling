using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SanctionScannerCrawling
{
    public class RegexWritline
    {
        public static void DosyaOku()
        {
            string regexPriceType = "<span>\\s+(?<fiyat>[0-9.]*).*</span></h5>";
            string testYolu = @"C:\test\test.txt";
            string dosyaYolu = @"C:\htmldowland\test.html";

            Regex regex = new Regex(regexPriceType, RegexOptions.IgnoreCase);
            using (var sr = new StreamReader(dosyaYolu))
            {

                var contents = sr.ReadToEnd();
                var t = regex.Matches(contents);

                double toplam = 0;

                foreach (Match match in t)
                {
                    Console.WriteLine("Fiyatlar: " + match.Groups[1]);

                    toplam += Convert.ToDouble(match.Groups[1].Value);

                    if (File.Exists(dosyaYolu))
                    {
                        using (var sw = new StreamWriter(testYolu, true))
                        {


                            sw.WriteLine("FİYAT: " + match.Groups[1]);

                            sw.Close();



                        }
                    }


                }
                //ortalama fiyat hesaplama 
                using (var sw = new StreamWriter(testYolu, true))
                {
                    sw.Write("Toplam Fiyat Ortalaması: " + toplam / t.Count);
                }

                Console.WriteLine("Toplam Fiyat Ortalaması: " + toplam / t.Count);


            }



        }
        public static void IsimOku()
        {
            string testYolu = @"C:\test\test.txt";
            string dosyaYolu = @"C:\htmldowland\test.html";
            string regexNameType = "<h2 class=\"item-title\">\\s+(?<title>.*)</h2>";
            Regex regexString = new Regex(regexNameType, RegexOptions.Multiline);
            using (var sr = new StreamReader(dosyaYolu))
            {
                var contents = sr.ReadToEnd();
                var nameRegex = regexString.Matches(contents);

                foreach (Match matching in nameRegex)
                {
                    Console.WriteLine("İsimler: " + matching.Groups[1]);

                    if (File.Exists(dosyaYolu))
                    {
                        using (var streamWriter = new StreamWriter(testYolu, true))
                        {


                            streamWriter.WriteLine("İsimler: " + matching.Groups[1]);

                            streamWriter.Close();

                        }
                    }
                }
            }

        }

    }
}
