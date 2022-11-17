using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScannerCrawling.Abstract
{
    public interface IHttpService
    {
        bool AddHeaders(string headers);
        bool DownloadFile(Uri uri, string dir);
        void ProgressChanged(object sender, DownloadProgressChangedEventArgs e);
        void Completed(object sender, AsyncCompletedEventArgs e);

    }
}
