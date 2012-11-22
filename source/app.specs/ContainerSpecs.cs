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
    }
  }
}
