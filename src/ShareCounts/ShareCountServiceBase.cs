using System;
using System.Threading.Tasks;

namespace Shariff.Backend.ShareCounts
{
    public abstract class ShareCountServiceBase
    {
        protected ShareCountServiceBase(
            string name)
        {
            Name = name;
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
                Console.WriteLine(exception);
                return string.Empty;
            }
        }

    }
}
