using System;
using System.Collections.Generic;

namespace app.utility.service_locator
{
    public class Container : IFindDependencies
    {
        public delegate TDependeny ConstructDependency<TDependeny>(IFindDependencies container) where TDependeny : class;

        readonly Dictionary<Type, Delegate> _factories;

        public Container()
        {
            _factories = new Dictionary<Type, Delegate>();
        }

        public void register<TDependeny>(ConstructDependency<TDependeny> factory) where TDependeny : class
        {
            _factories.Add(typeof(TDependeny), factory);
        }


        public TDependency an<TDependency>() where TDependency : class
        {
            Delegate factory;
            if (_factories.TryGetValue(typeof(TDependency), out factory))
            {
                return ((ConstructDependency<TDependency>)factory).Invoke(this);
            }

            throw new InvalidOperationException("Can't resolve type " + typeof(TDependency));
        }
    }
}