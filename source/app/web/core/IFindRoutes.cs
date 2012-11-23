using System.Web;

namespace app.web.core
{
    public interface IFindRoutes
    {
        IContainRequestDetails get_request_detail_for_request(HttpContext httpContext);
    }
}