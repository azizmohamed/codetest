using System;
using System.Collections.Generic;
using System.Linq;
using HTTPLogsParser.Contracts;
using HTTPLogsParser.Model;

namespace HTTPLogsParser
{
    public class QueryBuilder : IQueryBuilder
    {
        public int IPCount(IEnumerable<HTTPRequest> requests)
        {
            return requests.GroupBy(request => request.IPAddress).Count();
        }

        public IEnumerable<string> MostActiveIPAdress(IEnumerable<HTTPRequest> requests, int count)
        {
            return requests.Where(request => request.StatusCode == 200)
                        .GroupBy(request => request.IPAddress)
                        .OrderByDescending(g => g.Count())
                        .Take(count)
                        .Select(g => g.Key)
                        .ToList();
        }

        public IEnumerable<string> MostVisitedUrls(IEnumerable<HTTPRequest> requests, int count)
        {
            return requests.GroupBy(request => request.Url)
                        .OrderByDescending(g => g.Count())
                        .Take(count)
                        .Select(g => g.Key)
                        .ToList();
        }
    }
}
