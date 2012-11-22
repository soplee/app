namespace app.utility.service_locator
{
    public interface IFindDependencies
    {
        TDependency an<TDependency>() where TDependency : class;
        void register<TDependeny>(Container.ConstructDependency<TDependeny> factory) where TDependeny : class;
    }
}