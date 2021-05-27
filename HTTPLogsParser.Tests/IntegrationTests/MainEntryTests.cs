using System;
using programming_task;
using Xunit;

namespace HTTPLogsParser.Tests.IntegrationTests
{
    public class MainEntryTests
    {
        [Fact]
        public void CollectDataAsync_ReadFile_MostActiveIPAdressNotEmpty()
        {
            var parser = new Parser(new System.IO.StreamReader("programming-task-example-data.log"));
            var queryBuilder = new QueryBuilder();
            var mainEntry = new MainEntry(queryBuilder, parser);

            var collectedData = mainEntry.CollectDataAsync().Result;

            Assert.NotEmpty(collectedData.MostActiveIPAdress);
        }

        [Fact]
        public void CollectDataAsync_ReadFile_MostVisitedUrlsNotEmpty()
        {
            var parser = new Parser(new System.IO.StreamReader("programming-task-example-data.log"));
            var queryBuilder = new QueryBuilder();
            var mainEntry = new MainEntry(queryBuilder, parser);

            var collectedData = mainEntry.CollectDataAsync().Result;

            Assert.NotEmpty(collectedData.MostVisitedUrls);
        }

        [Fact]
        public void CollectDataAsync_ReadFile_IPCount11()
        {
            var parser = new Parser(new System.IO.StreamReader("programming-task-example-data.log"));
            var queryBuilder = new QueryBuilder();
            var mainEntry = new MainEntry(queryBuilder, parser);

            var collectedData = mainEntry.CollectDataAsync().Result;

            Assert.Equal(11, collectedData.IPCount);
        }
    }
}
