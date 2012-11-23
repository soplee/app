using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;

namespace app.web.core
{
    public class GetMainDepartmentsQuery : IFetchAReport<IEnumerable<Department>>
    {
        private readonly IFetchStoreInformation _storeInformation;

        public GetMainDepartmentsQuery(IFetchStoreInformation storeInformation)
        {
            _storeInformation = storeInformation;
        }

        public IEnumerable<Department> fetch_using(IContainRequestDetails request)
        {
            return _storeInformation.get_the_main_departments();
        }
    }

    public class GetSubDepartmentsQuery : IFetchAReport<IEnumerable<Department>>
    {
        private readonly IFetchStoreInformation _storeInformation;
        private readonly ICreateRequestModel<ViewSubDepartmentsRequest> _createRequestModel;

        public GetSubDepartmentsQuery(IFetchStoreInformation storeInformation, ICreateRequestModel<ViewSubDepartmentsRequest> createRequestModel)
        {
            _storeInformation = storeInformation;
            _createRequestModel = createRequestModel;
        }

        public IEnumerable<Department> fetch_using(IContainRequestDetails request)
        {
            return _storeInformation.get_the_departments_using(_createRequestModel.buildModel(request));
        }
    }


    public class GetProductsQuery : IFetchAReport<IEnumerable<Product>>
    {
        private readonly IFetchStoreInformation _storeInformation;
        private readonly ICreateRequestModel<ViewProductsInDepartmentRequest> _createRequestModel;

        public GetProductsQuery(IFetchStoreInformation storeInformation, ICreateRequestModel<ViewProductsInDepartmentRequest> createRequestModel)
        {
            _storeInformation = storeInformation;
            _createRequestModel = createRequestModel;
        }

        public IEnumerable<Product> fetch_using(IContainRequestDetails request)
        {
            return _storeInformation.get_the_products_using(_createRequestModel.buildModel(request));
        }
    }
}