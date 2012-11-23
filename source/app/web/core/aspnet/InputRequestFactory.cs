using System.Web;

namespace app.web.core.aspnet
{
  public class InputRequestFactory : ICreateControllerRequests
  {
    public IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request)
    {
      return new ControllerRequestFactory
      {
        path = a_raw_aspnet_request.Request.Path,
        id = 3,
      };
    }
  }
}