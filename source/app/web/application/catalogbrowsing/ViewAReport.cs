using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public class ViewAReport<PresentationData, RequestModel> : ISupportAUserFeature where RequestModel : IRequestModel
    {
        IDisplayInformation display_engine;
        IGetPresentationDataFromARequestModel<PresentationData> query;

        public ViewAReport(IDisplayInformation display_engine, IGetPresentationDataFromARequestModel<PresentationData> query)
        {
            this.display_engine = display_engine;
            this.query = query;
        }

        public void run<RequestModel>(RequestModel request) where RequestModel : IRequestModel
        {
            display_engine.display(query(request));
        }
    }
}