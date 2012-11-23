namespace app.web.core.aspnet
{
  public class ControllerRequestFactory : IContainRequestDetails
  {
    public string path { get; set; }

    public InputModel map<InputModel>()
    {
      return default(InputModel);
    }
  }
}