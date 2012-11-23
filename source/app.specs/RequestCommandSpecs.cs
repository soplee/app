using Machine.Specifications;
using app.web;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(RequestCommand<>))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand<FakeRequestModel>>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();

        depends.on<IMatchARequest>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
       result = sut.can_process(request);

      It should_make_its_decision_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static IContainRequestDetails request;
      static bool result;
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        requestModel = fake.an<FakeRequestModel>();
        feature = depends.on<ISupportAUserFeature<FakeRequestModel>>();

        model_builder = depends.on<ICreateRequestModel<FakeRequestModel>>();
        model_builder.setup(x => x.buildModel(request)).Return(requestModel);
      };

      Because b = () =>
        sut.run(request);

      It should_run_the_application_feature = () =>
        feature.received(x => x.run(requestModel));

      static IContainRequestDetails request;
      static ISupportAUserFeature<FakeRequestModel> feature;
      static FakeRequestModel requestModel;
      static ICreateRequestModel<FakeRequestModel> model_builder;
    }

    public class FakeRequestModel : IRequestModel { }
  }
}