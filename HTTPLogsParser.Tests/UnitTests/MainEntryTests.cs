using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTTPLogsParser.Contracts;
using HTTPLogsParser.Model;
using Moq;
using programming_task;
using Xunit;

namespace HTTPLogsParser.Tests.UnitTests
{
    public class MainEntryTests
    {
        [Fact]
        public void CollectDataAsync_CallMethod_ParserNdBuilderCalled() {
            var parserMock = new Mock<IParser>();
            parserMock.Setup(p => p.GetRequestsAsync()).Returns(Task.FromResult(new List<HTTPRequest>().AsEnumerable())) ;
            var queryBuilderMock = new Mock<IQueryBuilder>();
            queryBuilderMock.Setup(q => q.MostActiveIPAdress(new List<HTTPRequest>(), 3)).Returns(new List<string>());
            queryBuilderMock.Setup(q => q.MostVisitedUrls(new List<HTTPRequest>(), 3)).Returns(new List<string>());

            var mainEntry = new MainEntry(queryBuilderMock.Object, parserMock.Object);
            var dataAnalysis = mainEntry.CollectDataAsync().Result;

            parserMock.Verify(p => p.GetRequestsAsync());
            queryBuilderMock.Verify(q => q.MostActiveIPAdress(new List<HTTPRequest>(), 3));
            queryBuilderMock.Verify(q => q.MostVisitedUrls(new List<HTTPRequest>(), 3));
        }
    }
}
