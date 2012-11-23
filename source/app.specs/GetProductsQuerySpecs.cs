using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(GetProductsQuery))]
  public class GetProductsInDepartmentQuerySpecs
  {
    public abstract class concern : Observes<IFetchAReport<IEnumerable<Product>>, GetProductsQuery>
    {
    }

    public class when_fetching_products : concern
    {
      Establish c = () =>
      {
        request = fake.an<ViewProductsInDepartmentRequest>();

        details = fake.an<IContainRequestDetails>();
        details.setup(x => x.map<ViewProductsInDepartmentRequest>()).Return(request);

        query = depends.on<IFetchStoreInformation>();
      };

      Because of = () =>
        result = sut.fetch_using(details);

      It should_query_store_info_for_products_with_request = () =>
        query.received(x => x.get_the_products_using(request));

      static IContainRequestDetails details;
      static IEnumerable<Product> result;
      static IFetchStoreInformation query;
      static ViewProductsInDepartmentRequest request;
    }
  }
}