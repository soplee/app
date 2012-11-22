using System.Collections.Generic;
using System.Linq;
using System.Web;
using Machine.Specifications;
using app.web;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewsRegistry))]
  public class ViewRegistrySpecs
  {
    public abstract class concern : Observes<IViewsRegistry,
                                      ViewsRegistry>
    {
    }

    public class when_finding_a_view_that_can_be_rendered : concern
    {
      Establish c = () =>
      {                        
        data = fake.an<AnItemToDisplay>();
        all_the_possible_views = Enumerable.Range(1, 100).Select(x => fake.an<IView>()).ToList();
        depends.on<IEnumerable<IView>>(all_the_possible_views);
      };

      Because b = () =>
        result = sut.find_view_that_can_render(data);

      public class and_it_has_the_command
      {
        Establish c = () =>
        {
            the_view_that_can_be_rendered = fake.an<IView>();
            all_the_possible_views.Add(the_view_that_can_be_rendered);

            the_view_that_can_be_rendered.setup(x => x.can_render(data)).Return(true);
        };

        It should_return_the_view_to_the_caller = () =>
          result.ShouldEqual(the_view_that_can_be_rendered);


      }


      static AnItemToDisplay data;
      static IContainRequestDetails request;
      static List<IView> all_the_possible_views;
       static IView the_view_that_can_be_rendered;
      static IView result;

    }
    public class AnItemToDisplay
    {
    }
  }
}