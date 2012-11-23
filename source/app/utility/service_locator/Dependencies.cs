using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;

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

                      container.register<IEnumerable<IProcessOneRequest>>(c => new[]
                      { 
                          new RequestCommand(request => request.path.Contains("maindepartment"),c.an<ViewAReport<ViewMainDepartmentRequest>>()),
                          new RequestCommand(request => request.path.Contains("subdepartment") , c.an<ViewAReport<ViewSubDepartmentsRequest>>()),
                          new RequestCommand(request => request.path.Contains("products"), c.an<ViewAReport<ViewProductsInDepartmentRequest>>()),
                      });

                      container.register<IDisplayInformation>(c => new WebFormsDisplayEngine(c.an<ICreateViews>(), c.an<IGetTheCurrentlyExecutingRequest>()));

/*                      container.register(c => new ViewAReport<ViewMainDepartmentRequest>(c.an<IDisplayInformation>(),
                                                                                    input =>
                                                                                        
                                                                                          new StubCatalog().get_the_main_departments
                                                                                        ));*/

                      //container.register<ViewAReport<ViewMainDepartmentRequest>>(c=> ));



                      container.register<IGetTheCurrentlyExecutingRequest>(c => () => HttpContext.Current);
                      container.register<ICreateViews>(c => new ViewFactory(BuildManager.CreateInstanceFromVirtualPath, container.an<StubPathRegistry>()));

                      return container;
                  };


        public static IFindDependencies fetch
        {
            get { return resolution(); }
        }
    }
}