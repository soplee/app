using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
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