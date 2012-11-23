using System;
using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IContainRequestDetails create_a_controller_request_from(HttpContext a_raw_aspnet_request)
    {
      return new StubRequest();
    }

    class StubRequest : IContainRequestDetails
    {
        public string path { get; set; }
    }
  }
}