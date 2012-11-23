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

    public class GetSubDepartmentsQuery : IFetchAReport<IEnumerable<SubDepartmet>>
    {
        private readonly IFetchStoreInformation _storeInformation;

        public GetSubDepartmentsQuery(IFetchStoreInformation storeInformation)
        {
            _storeInformation = storeInformation;
        }

        public IEnumerable<SubDepartmet> fetch_using(IContainRequestDetails request)
        {
            return _storeInformation.get_the_departments_using((ViewSubDepartmentsRequest)request);
        }
    }


    public class GetProductsQuery : IFetchAReport<IEnumerable<Product>>
    {
        private readonly IFetchStoreInformation _storeInformation;

        public GetProductsQuery(IFetchStoreInformation storeInformation)
        {
            _storeInformation = storeInformation;
        }

        public IEnumerable<Product> fetch_using(IContainRequestDetails request)
        {
            return _storeInformation.get_the_products_using((ViewProductsInDepartmentRequest)request);
        }
    }
}