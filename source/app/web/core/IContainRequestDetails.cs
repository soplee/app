using app.web.application.catalogbrowsing;

namespace app.web.core
{
  public interface IContainRequestDetails
  {
      string path { get; set; }
  }


    public class RequestDetail :IContainRequestDetails
    {
        public string path { get; set; }
    }

}
