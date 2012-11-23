using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public class RequestCommand<TRequestModel> : IProcessOneRequest where TRequestModel : IRequestModel
    {
        private IMatchARequest request_specification;
        private ISupportAUserFeature feature;
        private readonly ICreateRequestModel<TRequestModel> _modelBuilder;

        public RequestCommand(IMatchARequest request_specification, ISupportAUserFeature feature, ICreateRequestModel<TRequestModel> modelBuilder)
        {
            this.request_specification = request_specification;
            this.feature = feature;
            _modelBuilder = modelBuilder;
        }


        public bool can_process(IContainRequestDetails request)
        {
            return request_specification(request);
        }

        public void run(IContainRequestDetails requestDetails)
        {
            feature.run(_modelBuilder.buildModel(requestDetails));
        }
    }
}