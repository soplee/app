using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
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
}