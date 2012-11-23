using System;
using System.Collections.Generic;
using app.web.core;

namespace app.utility.service_locator
{
    public class Dependencies
    {
        public static IResolveTheContainerConfiguredAtStartup resolution = () =>
                  {
                      var container = new Container();

                      container.register<IProcessRequests>(c =>
                          new FrontController(c.an<IFindCommands>()));

                      container.register<IFindCommands>(c =>
                          new CommandRegistry(c.an<IEnumerable<IProcessOneRequest>>(), c.an<ICreateTheCommandWhenOneCantBeFound>()));

                      container.register<ICreateTheCommandWhenOneCantBeFound>(c => () => new InvalidCommand());

                      container.register<IEnumerable<IProcessOneRequest>>(c => new[]{ 
                          new RequestCommand(c.an<IMatchARequest>(),c.an<ISupportAUserFeature>())});

                      return container;
                  };


        public static IFindDependencies fetch
        {
            get { return resolution(); }
        }
    }
}