using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public interface ICreateRequestModel<TModel> where TModel : IRequestModel
    {
        TModel buildModel(IContainRequestDetails request);
    }
}