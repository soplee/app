using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public interface IProcessOneRequest
    {
        bool can_process(IContainRequestDetails request);
        void run(IContainRequestDetails request);
    }
}