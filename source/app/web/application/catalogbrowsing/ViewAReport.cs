using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public class ViewAReport<PresentationData, RequestModel> : ISupportAUserFeature<RequestModel> where RequestModel : IRequestModel
    {
        IDisplayInformation display_engine;
        IGetPresentationDataFromARequestModel<PresentationData, RequestModel> query;

        public ViewAReport(IDisplayInformation display_engine, IGetPresentationDataFromARequestModel<PresentationData, RequestModel> query)
        {
            this.display_engine = display_engine;
            this.query = query;
        }

        public void run(RequestModel request)
        {
            display_engine.display(query(request));
        }
    }
}