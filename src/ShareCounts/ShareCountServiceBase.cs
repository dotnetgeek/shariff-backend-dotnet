using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Shariff.Backend.ShareCounts
{
    public abstract class ShareCountServiceBase
    {

        private readonly ILogger _logger;

        protected ShareCountServiceBase(
            string name,
            ILogger logger)
        {
            Name = name;
            _logger = logger;
        }

        public string Name
        {
            get;
            private set;
        }

        protected abstract Task<string> CallService(string url);

        public async Task<string> Get(
            string url)
        {
            try
            {
                return await CallService(url);
            }
            catch(Exception exception)
            {
                _logger.LogError(10004, exception, exception.Message);
                return string.Empty;
            }
        }

    }
}
