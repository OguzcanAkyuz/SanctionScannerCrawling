using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SanctionScannerCrawling.Abstract
{
    public interface IRegexService
    {
        MatchCollection ReadPrices();
        MatchCollection ReadName();
    }
}
