using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public interface IContainRequestDetails
    {
        string path { get; set; }
        InputModel map<InputModel>() where InputModel : class ,IRequestModel;
    }

}