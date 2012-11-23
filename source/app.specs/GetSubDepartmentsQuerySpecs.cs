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
    public abstract class concern : Observes<IFetchAReport<IEnumerable<Department>, ViewSubDepartmentsRequest>>
    {
    }

    public class when_fetching_sub_departments : concern
    {
      Establish c = () =>
      {
        request = fake.an<ViewSubDepartmentsRequest>();

        query = depends.on<IFetchStoreInformation>();
      };

      Because of = () =>
        sut.fetch_using(request);

      It should_query_store_info_for_sub_departments_with_request = () =>
        query.received(x => x.get_the_departments_using(request));

      static IFetchStoreInformation query;
      static ViewSubDepartmentsRequest request;
    }
  }
}