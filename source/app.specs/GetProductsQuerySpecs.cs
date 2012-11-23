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
    public abstract class concern : Observes<IFetchAReport<IEnumerable<Product>, ViewProductsInDepartmentRequest>, GetProductsQuery>
    {
    }

    public class when_fetching_products : concern
    {
      Establish c = () =>
      {
        request = fake.an<ViewProductsInDepartmentRequest>();

        query = depends.on<IFetchStoreInformation>();
      };

      Because of = () =>
        sut.fetch_using(request);

      It should_query_store_info_for_products_with_request = () =>
        query.received(x => x.get_the_products_using(request));

      static IFetchStoreInformation query;
      static ViewProductsInDepartmentRequest request;
    }
  }
}