using System;
using System.Collections.Generic;
using HTTPLogsParser.Model;

namespace HTTPLogsParser.Contracts
{
    public interface IQueryBuilder
    {
        int IPCount(IEnumerable<HTTPRequest> requests);
        IEnumerable<string> MostVisitedUrls(IEnumerable<HTTPRequest> requests, int count);
        IEnumerable<string> MostActiveIPAdress(IEnumerable<HTTPRequest> requests, int count);
    }
}
