using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScannerCrawling
{
    public class FileService : IDisposable
    {
        /// <summary>
        ///  If the code does not work, we catch it with a try catch and start the deletion code here.
        /// I split the code into services when we need to change it in the future.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        /// <summary>
        ///   While the software is running,We run the delete code after this service is running to reduce the load on the RAM.
        /// </summary>
        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }
    }
}
