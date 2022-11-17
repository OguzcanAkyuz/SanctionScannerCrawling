using System;
using System.ComponentModel;
using System.Net;

namespace SanctionScannerCrawling
{
    public class HttpService : IDisposable
    {
        private WebClient _webClient;
        public HttpService()
        {
            _webClient = new WebClient();
            _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
        }
       
        /// <summary>
        ///  
        ///  If the code does not work, we catch it with a try catch and start the deletion code here.
        ///  I split the code into services when we need to change it in the future.
        /// </summary>
        /// <param name=" header" ></param>
        /// <returns></returns>
        public bool AddHeaders(string header)
        {
            try
            {
                _webClient.Headers.Add(header);
            }
            catch (Exception)
            {

                return false;
            }


            return true;
        }

        /// <summary>
        ///  //If the code does not work, we catch it with a try catch and start the deletion code here.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="dir"></param>
        /// <returns></returns>         
        public bool DownloadFile(Uri uri, string dir)
        {
            try
            {
                _webClient.DownloadFile(uri, dir);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }
        private static void Completed(object sender, AsyncCompletedEventArgs e)
        {
        }
        /// <summary>
        ///   // While the software is running,We run the delete code after this service is running to reduce the load on the RAM.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
