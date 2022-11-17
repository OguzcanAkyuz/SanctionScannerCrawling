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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
