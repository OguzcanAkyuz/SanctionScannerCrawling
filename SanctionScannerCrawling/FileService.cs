using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScannerCrawling
{
    public class FileService : IDisposable
    {

        public bool DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {

              return false;
            }
            return true;
        }

        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }
    }
}
