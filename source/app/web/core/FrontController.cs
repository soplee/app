namespace app.web.core
{
    public class FrontController : IProcessRequests
    {
        IFindCommands command_registry;

        public FrontController(IFindCommands commandRegistry)
        {
            command_registry = commandRegistry;
        }

        public void process(IContainRequestDetails request)
        {
            var command = command_registry.get_the_command_that_can_process(request);
            command.run(request);
        }
    }
}