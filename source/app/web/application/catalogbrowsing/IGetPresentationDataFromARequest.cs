using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public delegate PresentationData IGetPresentationDataFromARequestModel<PresentationData>(IRequestModel input);

    public interface IFetchAReport<PresentationData, RequestModel> where RequestModel : IRequestModel
    {
        PresentationData fetch_using(RequestModel requestModel);
    }
}