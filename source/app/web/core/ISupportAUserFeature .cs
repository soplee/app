using System;
using app.web.application.catalogbrowsing;

namespace app.web.core
{
    public interface ISupportAUserFeature
    {
        void run<TRequestModel>(TRequestModel request) where TRequestModel : IRequestModel;
    }

    public class ChainedBehaviour : IEnrichAnInvocationPipeline
    {
        IEnrichAnInvocationPipeline first;
        IEnrichAnInvocationPipeline second;

        public ChainedBehaviour(IEnrichAnInvocationPipeline first, IEnrichAnInvocationPipeline second)
        {
            this.first = first;
            this.second = second;
        }

        public void add_behaviour_to(IRepresentAMethodInvocation invocation)
        {
            first.add_behaviour_to(invocation);
            second.add_behaviour_to(invocation);
        }
    }

    public class CachedBehaviour : IEnrichAnInvocationPipeline
    {
        public void add_behaviour_to(IRepresentAMethodInvocation invocation)
        {
        }
    }

    public class SecuredBehaviour : IEnrichAnInvocationPipeline
    {
        Func<bool> constraint;

        public SecuredBehaviour(Func<bool> constraint)
        {
            this.constraint = constraint;
        }

        public void add_behaviour_to(IRepresentAMethodInvocation invocation)
        {
            if (constraint()) invocation.run();

            throw new NotImplementedException("This behaviour does not meet the currently defined constraint");
        }
    }

    public class TimedBehaviour : IEnrichAnInvocationPipeline
    {
        ITimeThings timer;
        ILogMessages logger;

        public TimedBehaviour(ITimeThings timer, ILogMessages logger)
        {
            this.timer = timer;
            this.logger = logger;
        }

        public void add_behaviour_to(IRepresentAMethodInvocation invocation)
        {
            timer.start();
            invocation.run();
            timer.stop();
            logger.info("This is how long it took");
        }
    }

    public interface IEnrichAnInvocationPipeline
    {
        void add_behaviour_to(IRepresentAMethodInvocation invocation);
    }

    public interface IRepresentAMethodInvocation
    {
        void run();
    }

    public interface ILogMessages
    {
        void info(string this_is_how_long_it_took_to_runn);
    }

    public interface ITimeThings
    {
        void start();
        void stop();
    }
}