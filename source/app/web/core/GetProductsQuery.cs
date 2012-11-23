using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public class GetProductsQuery : IFetchAReport<IEnumerable<Product>, ViewProductsInDepartmentRequest>
    {
        private readonly IFetchStoreInformation _storeInformation;

        public GetProductsQuery(IFetchStoreInformation storeInformation)
        {
            _storeInformation = storeInformation;
        }

        public IEnumerable<Product> fetch_using(ViewProductsInDepartmentRequest requestModel)
        {
            return _storeInformation.get_the_products_using(requestModel);
        }
    }
}