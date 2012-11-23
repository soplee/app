using System;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public class InvalidCommand : IProcessOneRequest
    {
        public bool can_process(IContainRequestDetails request)
        {
            return false;
        }

        public void run(IContainRequestDetails request)
        {
            throw new NotImplementedException();
        }

    }
}