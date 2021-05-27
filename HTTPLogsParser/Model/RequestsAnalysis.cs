using System;
using System.Collections.Generic;

namespace HTTPLogsParser.Model
{
    public class RequestsAnalysis
    {
        public int IPCount { get; set; }
        public IEnumerable<string> MostActiveIPAdress { get; set; }
        public IEnumerable<string> MostVisitedUrls { get; set; }
    }
}
