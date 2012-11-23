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
  public class GetMainDepartmentsQuerySpecs
  {
    public abstract class concern : Observes<IFetchAReport<IEnumerable<Department>, ViewMainDepartmentRequest>>
    {
    }

    public class when_fetching_main_departments : concern
    {
      Establish c = () =>
      {
        request = fake.an<ViewMainDepartmentRequest>();
        query = depends.on<IFetchStoreInformation>();
      };

      Because of = () =>
        result = sut.fetch_using(request);

      It should_query_store_info_for_main_departments = () =>
        query.received(x => x.get_the_main_departments());

      static ViewMainDepartmentRequest request;
      static IEnumerable<Department> result;
      static IFetchStoreInformation query;
    }
  }
}