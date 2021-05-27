using System;
using System.Threading.Tasks;
using HTTPLogsParser.Model;

namespace programming_task
{
    public interface IMainEntry
    {
        Task<RequestsAnalysis> CollectDataAsync();
    }
}
