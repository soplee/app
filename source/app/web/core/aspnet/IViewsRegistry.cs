using System.Web;

namespace app.web.core.aspnet
{
  public interface IViewsRegistry
  {
    IView find_view_that_can_render<PresentationModel>(PresentationModel data);
  }

    public class ViewsRegistry: IViewsRegistry
    {
        public IView find_view_that_can_render<PresentationModel>(PresentationModel data)
        {
            throw new System.NotImplementedException();
        }
    }
}