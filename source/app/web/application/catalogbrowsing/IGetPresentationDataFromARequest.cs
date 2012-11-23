using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public delegate PresentationData IGetPresentationDataFromARequestModel<PresentationData, RequestModel>(RequestModel input) where RequestModel : IRequestModel;

    public interface IFetchAReport<PresentationData, RequestModel> where RequestModel : IRequestModel
    {
        PresentationData fetch_using(RequestModel requestModel);
    }
}