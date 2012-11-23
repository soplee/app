using System;
using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(InputRequestFactory))]
  public class InputRequestFactorySpecs 
  {
    public abstract class concern : Observes<ICreateControllerRequests,
                                      InputRequestFactory>
    {
    }

    public class when_creating_a_request : concern
    {
      Establish c = () =>
      {
        id = 17;
        path = "department";
      };

      public class and_it_is_for_a_sub_department
      {
        Establish c = () =>
        {
          request = new HttpRequest(id + ".iqmetrix", path, "");
          context = new HttpContext(request, null);
        };

        Because of = () =>
          sut.create_a_controller_request_from(context);

        It should_return_a_all_request_data = () =>
        {
          result.path.ShouldEqual(path);
          result.id.ShouldEqual(id);
        };

        static ControllerRequestFactory result;
        static HttpContext context;
        static HttpRequest request;
      }

      static string path;
      static int id;
    }
  }
}