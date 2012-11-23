using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(GetMainDepartmentsQuery))]
  public class GetSubDepartmentsQuerySpecs
  {
    public abstract class concern : Observes<IFetchAReport<IEnumerable<Department>>, GetSubDepartmentsQuery>
    {
    }

    public class when_fetching_sub_departments : concern
    {
      Establish c = () =>
      {
        request = fake.an<ViewSubDepartmentsRequest>();

        details = fake.an<IContainRequestDetails>();

        query = depends.on<IFetchStoreInformation>();
      };

      Because of = () =>
        result = sut.fetch_using(details);

      It should_query_store_info_for_sub_departments_with_request = () =>
        query.received(x => x.get_the_departments_using(request));

      static IContainRequestDetails details;
      static IEnumerable<Department> result;
      static IFetchStoreInformation query;
      static ViewSubDepartmentsRequest request;
    }
  }
}