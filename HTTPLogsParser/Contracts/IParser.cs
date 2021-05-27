using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPLogsParser.Model;

namespace HTTPLogsParser.Contracts
{
    public interface IParser
    {
        Task<IEnumerable<HTTPRequest>> GetRequestsAsync();
    }
}
