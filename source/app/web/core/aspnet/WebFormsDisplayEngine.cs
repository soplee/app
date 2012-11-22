namespace app.web.core.aspnet
{
  public class WebFormsDisplayEngine : IDisplayInformation
  {
    IViewsRegistry _viewRegistryFactory;
    IGetTheCurrentlyExecutingRequest current_request_resolution;


    public WebFormsDisplayEngine(IViewsRegistry _viewRegistryFactory, IGetTheCurrentlyExecutingRequest current_request_resolution)
    {
      this._viewRegistryFactory = _viewRegistryFactory;
      this.current_request_resolution = current_request_resolution;
    }

    public void display<PresentationModel>(PresentationModel model)
    {
      _viewRegistryFactory.find_view_that_can_render(model).ProcessRequest(current_request_resolution());
    }
  }
}