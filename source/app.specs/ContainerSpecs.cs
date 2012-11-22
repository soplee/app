 using Machine.Specifications;
 using app.utility.service_locator;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(Container))]  
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IFindDependencies,
                                      Container>
    {
        
    }


    public class when_observation_name : concern
    {
        private Because b = () =>
        result = sut.an<FakeDependency>();

        private It should_return_a_fake_dependency = () => result.ShouldBeOfType<FakeDependency>();

        private It should_not_be_null = () => result.ShouldNotBeNull();

        private static FakeDependency result;
    }
    public class FakeDependency
    {

    }


  }
}
