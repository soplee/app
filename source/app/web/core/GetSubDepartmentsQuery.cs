using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public class GetSubDepartmentsQuery : IFetchAReport<IEnumerable<Department>, ViewSubDepartmentsRequest>
    {
        private readonly IFetchStoreInformation _storeInformation;

        public GetSubDepartmentsQuery(IFetchStoreInformation storeInformation)
        {
            _storeInformation = storeInformation;
        }

        public IEnumerable<Department> fetch_using(ViewSubDepartmentsRequest requestModel)
        {
            return _storeInformation.get_the_departments_using(requestModel);
        }
    }
}