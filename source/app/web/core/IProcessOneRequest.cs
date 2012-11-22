namespace app.web.core
{
  public interface IProcessOneRequest : ISupportAUserFeature
  {
    bool can_process(IContainRequestDetails request);
  }

  public interface IView 
  {
      bool can_render<PresentationModel>(PresentationModel data);
  }
}