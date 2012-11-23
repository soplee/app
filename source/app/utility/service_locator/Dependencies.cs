using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.web.application;
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

                      container.register<IEnumerable<IProcessOneRequest>>(c => new IProcessOneRequest[]
                      { 
                          new RequestCommand<ViewMainDepartmentRequest>(request => 
                              request.path.Contains("maindepartment"),c.an<ViewAReport<IEnumerable<Department>,ViewMainDepartmentRequest>>(), new MainDepartmentModelBuilder()),
                         
                              new RequestCommand<ViewSubDepartmentsRequest>(
                              request => request.path.Contains("subdepartment") , c.an<ViewAReport<IEnumerable<Department>, ViewSubDepartmentsRequest>>(), new SubDepartmentModelBuilder()),
                          
                              new RequestCommand<ViewProductsInDepartmentRequest>(request => request.path.Contains("products"), c.an<ViewAReport<IEnumerable<Product>, ViewProductsInDepartmentRequest>>(), new ProductModelBuilder()),
                      });

                      container.register<IDisplayInformation>(c => new WebFormsDisplayEngine(c.an<ICreateViews>(), c.an<IGetTheCurrentlyExecutingRequest>()));

                      container.register(c =>
                            new ViewAReport<IEnumerable<Department>, ViewMainDepartmentRequest>(c.an<IDisplayInformation>(), input => c.an<GetMainDepartmentsQuery>().fetch_using(input)));

                      container.register(c =>
                            new ViewAReport<IEnumerable<Department>, ViewSubDepartmentsRequest>(c.an<IDisplayInformation>(), input => c.an<GetSubDepartmentsQuery>().fetch_using(input)));

                      container.register(c =>
                            new ViewAReport<IEnumerable<Product>, ViewProductsInDepartmentRequest>(c.an<IDisplayInformation>(), input => c.an<GetProductsQuery>().fetch_using(input)));



                      container.register<IGetTheCurrentlyExecutingRequest>(c => () => HttpContext.Current);
                      container.register<ICreateViews>(c => new ViewFactory(BuildManager.CreateInstanceFromVirtualPath, container.an<IGetThePathToAViewThatCanDisplay>()));


                      container.register<IGetThePathToAViewThatCanDisplay>(c => new StubPathRegistry());

                      container.register<ICreateControllerRequests>(c => new CreateControllerRequest());


                      container.register(c => new GetMainDepartmentsQuery(c.an<IFetchStoreInformation>()));
                      container.register(c => new GetSubDepartmentsQuery(c.an<IFetchStoreInformation>()));
                      container.register(c => new GetProductsQuery(c.an<IFetchStoreInformation>()));

                      container.register<IFetchStoreInformation>(c => new StubCatalog());

                      return container;
                  };


        public static IFindDependencies fetch
        {
            get { return resolution(); }
        }
    }
}
