using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public class GetMainDepartmentsQuery : IFetchAReport<IEnumerable<Department>, ViewMainDepartmentRequest>
    {
        private readonly IFetchStoreInformation _storeInformation;

        public GetMainDepartmentsQuery(IFetchStoreInformation storeInformation)
        {
            _storeInformation = storeInformation;
        }

        public IEnumerable<Department> fetch_using(ViewMainDepartmentRequest requestModel)
        {
            return _storeInformation.get_the_main_departments();
        }
    }
}
