using System;
using System.Threading.Tasks;
using HTTPLogsParser.Contracts;
using HTTPLogsParser.Model;

namespace programming_task
{
    public class MainEntry: IMainEntry
    {
        IQueryBuilder _queryBuilder;
        IParser _parser;
        public MainEntry(IQueryBuilder queryBuilder, IParser parser)
        {
            _queryBuilder = queryBuilder;
            _parser = parser;
        }

        public async Task<RequestsAnalysis> CollectDataAsync() {
            var requests = await _parser.GetRequestsAsync();

            var IPCount = _queryBuilder.IPCount(requests);

            var mostVisitedUrls = _queryBuilder.MostVisitedUrls(requests, 3);

            var mostActiveIPAdress = _queryBuilder.MostActiveIPAdress(requests, 3);

            return new RequestsAnalysis {
                IPCount = _queryBuilder.IPCount(requests),
                MostVisitedUrls = _queryBuilder.MostVisitedUrls(requests, 3),
                MostActiveIPAdress = _queryBuilder.MostActiveIPAdress(requests, 3)
            };
        }


    }
}
