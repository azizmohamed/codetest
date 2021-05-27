using System;
using System.Collections.Generic;
using HTTPLogsParser.Model;
using Xunit;
using System.Linq;

namespace HTTPLogsParser.Tests.UnitTests
{
    public class QueryBuilderTests
    {
        [Fact]
        public void IPCount_ListOf8Requests_Return8()
        {
            var queryBuilder = new QueryBuilder();
            var requests = RequestsList();
            var iPCount = queryBuilder.IPCount(requests);

            Assert.Equal(4, iPCount);
        }

        [Fact]
        public void IPCount_MostVisitedUrls_ReturnDocsFirstOne()
        {
            var queryBuilder = new QueryBuilder();
            var requests = RequestsList();
            var mostVisitedUrls = queryBuilder.MostVisitedUrls(requests, 2);

            Assert.Equal("/docs/", mostVisitedUrls.First());
        }

        [Fact]
        public void IPCount_MostActiveIPAdress_Return1FirstOne()
        {
            var queryBuilder = new QueryBuilder();
            var requests = RequestsList();
            var mostActiveIPAdress = queryBuilder.MostActiveIPAdress(requests, 2);

            Assert.Equal("10.0.0.1", mostActiveIPAdress.First());
        }



        List<HTTPRequest> RequestsList() {
            return new List<HTTPRequest> {
                new HTTPRequest("10.0.0.1 - - [10/Jul/2018:22:21:28 +0200] \"GET /home/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.2 - - [10/Jul/2018:22:21:28 +0200] \"GET /account/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.3 - - [10/Jul/2018:22:21:28 +0200] \"GET /user/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.1 - - [10/Jul/2018:22:21:28 +0200] \"GET /docs/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.2 - - [10/Jul/2018:22:21:28 +0200] \"GET /logo.ping HTTP/1.1\" 401 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.3 - - [10/Jul/2018:22:21:28 +0200] \"GET /home/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.4 - - [10/Jul/2018:22:21:28 +0200] \"GET /docs/ HTTP/1.1\" 500 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7"),
                new HTTPRequest("10.0.0.1 - - [10/Jul/2018:22:21:28 +0200] \"GET /docs/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; U; Linux x86_64; fr-FR) AppleWebKit/534.7 (KHTML, like Gecko) Epiphany/2.30.6 Safari/534.7")

            };
        }
    }
}
