using System;

namespace app.web.core
{
    public class InvalidCommand : IProcessOneRequest
    {
        public void run(IContainRequestDetails request)
        {
            throw new InvalidOperationException();
        }

        public bool can_process(IContainRequestDetails request)
        {
            return false;
        }
    }
}