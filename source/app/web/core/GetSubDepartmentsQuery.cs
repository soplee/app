using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
  public class GetSubDepartmentsQuery : IFetchAReport<IEnumerable<SubDepartment>>
  {
    private readonly IFetchStoreInformation _storeInformation;

    public GetSubDepartmentsQuery(IFetchStoreInformation storeInformation)
    {
      _storeInformation = storeInformation;
    }

    public IEnumerable<SubDepartment> fetch_using(IContainRequestDetails details)
    {
      var request = details.map<ViewSubDepartmentsRequest>();
      return _storeInformation.get_the_departments_using(request);
    }
  }
}