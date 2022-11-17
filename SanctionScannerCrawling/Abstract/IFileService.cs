using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScannerCrawling.Abstract
{
    public interface IFileService
    {
        bool DeleteFile(string path);
    }
}
