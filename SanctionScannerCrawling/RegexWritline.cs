using Microsoft.VisualBasic;
using System;
using System.Collections;
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
            //I split the code into services when we need to change it in the future.

            //Regex expression code to get price information from "HTML" file.
            string regexPriceType = "<span>\\s+(?<fiyat>[0-9.]*).*</span></h5>";
            //Where to save the values ​​found with "regex".
            string demoPath = @"C:\demo\demo.txt";
            //The path of the file to be deleted.
            string filepath = @"C:\htmldownload\test.html";
            // We define a variable with the "regex" library.
            //RegexType=Code used to get price value from HTML Content.
            //RegexOptions=Regex The regex determines what type to look for.
            Regex regex = new Regex(regexPriceType, RegexOptions.IgnoreCase);
            // We read the file on our computer with "StreamReader".
            using (var sr = new StreamReader(filepath))
            {
                //We use "ReadToEnd" to read all characters up to the end of the stream.
                var contents = sr.ReadToEnd();
                //Here we match the file read as "HTML" and it allows us to find the characters we want.
                var priceRegex = regex.Matches(contents);

                double toplam = 0;

                // The part where we match, print "HTML" and save.
                foreach (Match match in priceRegex)
                {
                    //It creates a grouping because it takes data of the same value.
                    Console.WriteLine("PRICES : " + match.Groups[1]);
                    //Type => Double
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

                //Total Price Average 
                // We read the file on our computer with "StreamReader".
                using (var sw = new StreamWriter(demoPath, true))
                {
                    sw.Write("Total Price Average: " + toplam / priceRegex.Count);
                }

                Console.WriteLine("Total Price Average: " + toplam / priceRegex.Count);


            }



        }
        public void ReadName()
        {
            //Where to save the values ​​found with "regex".
            string demoPath = @"C:\demo\demo.txt";
            //The path of the file to be deleted.
            string filepath = @"C:\htmldownload\test.html";
            //Regex expression code to get name information from "HTML" file.
            string regexNameType = "<h2 class=\"item-title\">\\s+(?<title>.*)</h2>";
            //RegexType=Code used to get price value from HTML Content.
            //RegexOptions.Multiline=Multiline factor used to search all lines because there are spaces and bottom line.
            Regex regexString = new Regex(regexNameType, RegexOptions.Multiline);
            // We read the file on our computer with "StreamReader".
            using (var sr = new StreamReader(filepath))
            {
                var contents = sr.ReadToEnd();
                var nameRegex = regexString.Matches(contents);

                foreach (Match matching in nameRegex)
                {
                  //  It creates a grouping because it takes data of the same value.
                    Console.WriteLine("NAMES: " + matching.Groups[1]);

                    if (File.Exists(filepath))
                    {
                        using (var streamWriter = new StreamWriter(demoPath, true))
                        {

                           // It creates a grouping because it takes data of the same value.
                            streamWriter.WriteLine("NAMES : " + matching.Groups[1]);

                            streamWriter.Close();

                        }
                    }
                }
            }

        }
        // While the software is running,We run the delete code after this service is running to reduce the load on the RAM.
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
