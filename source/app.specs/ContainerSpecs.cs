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


        public class when_container_has_registrations : concern
        {
            private Because b = () =>
                                    {
                                        sut.register<IThing>(c => new fakeDependeny(c.an<fakeChildDependeny>()));
                                        sut.register(c => new fakeChildDependeny());
                                        dependency = sut.an<IThing>();
                                    };

            private It should_return_new_dependency = () => dependency.ShouldNotBeNull();
            private It should_be_of_proper_type = () => dependency.ShouldBeOfType<IThing>();

            static IThing dependency;
        }

        public class fakeDependeny : IThing
        {
            public fakeDependeny(fakeChildDependeny fakeChild)
            {
                
            }
        }

        public class fakeChildDependeny : IThing
        {

        }
    }

    public interface IThing
    {
    }
}
