namespace app.web.core
{
  public interface IContainRequestDetails
  {
      string path { get; set; }
      InputModel map<InputModel>();
  }

}