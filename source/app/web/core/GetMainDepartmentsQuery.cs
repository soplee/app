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

        public IEnumerable<Department> fetch_using(IContainRequestDetails details)
        {
            return _storeInformation.get_the_main_departments();
        }
    }
}