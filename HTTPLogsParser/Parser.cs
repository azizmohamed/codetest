using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HTTPLogsParser.Contracts;
using HTTPLogsParser.Model;

namespace HTTPLogsParser
{
    public class Parser: IParser
    {
        StreamReader _streamReader;
        public Parser(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public async Task<IEnumerable<HTTPRequest>> GetRequestsAsync()
        {
            //Assumption: logs file is small as per the incuded file that's why we could use ReadToEnd method, otherwise use another method not to exhaust memory
            var strLogs = await _streamReader.ReadToEndAsync();
            //Assumed like breaker character is \n. 
            var httpLogs = strLogs.Split("\n").Where(log => !string.IsNullOrWhiteSpace(log)).Select(log => {
                return new HTTPRequest(log);
            });
            return httpLogs;

        }
    }
}
