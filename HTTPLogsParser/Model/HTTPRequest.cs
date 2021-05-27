using System;
namespace HTTPLogsParser.Model
{
    public class HTTPRequest
    {
        string _log;
        public HTTPRequest(string log)
        {
            _log = log;
        }
        public string IPAddress
        {
            get
            {
                return _log.Split(" ")[0];
            }
        }

        public string Url
        {
            get
            {
                return _log.Split(" ")[6];
            }
        }

        public int StatusCode
        {
            get
            {
                return int.Parse(_log.Split(" ")[8]);
            }
        }
    }
}
