using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public interface ICreateRequestModel<TModel> where TModel : IRequestModel
    {
        TModel buildModel(IContainRequestDetails request);
    }

    public class MainDepartmentModelBuilder : ICreateRequestModel<ViewMainDepartmentRequest>
    {
        public ViewMainDepartmentRequest buildModel(IContainRequestDetails request)
        {
            return new ViewMainDepartmentRequest();
        }
    }

    public class SubDepartmentModelBuilder : ICreateRequestModel<ViewSubDepartmentsRequest>
    {
        public ViewSubDepartmentsRequest buildModel(IContainRequestDetails request)
        {
            return new ViewSubDepartmentsRequest() { id = 12 };
        }
    }

    public class ProductModelBuilder : ICreateRequestModel<ViewProductsInDepartmentRequest>
    {
        public ViewProductsInDepartmentRequest buildModel(IContainRequestDetails request)
        {
            return new ViewProductsInDepartmentRequest() { id = 12 };
        }
    }
}