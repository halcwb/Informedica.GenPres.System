using System;
using Autofac;
using Autofac.Integration.Mvc;

namespace Informedica.GenPres.Application
{
    public class StubLifetimeScopeProvider : ILifetimeScopeProvider
    {
        ILifetimeScope _lifetimeScope;
        readonly ILifetimeScope _container;

        internal static readonly object HttpRequestTag = "AutofacWebRequest";

        public StubLifetimeScopeProvider(ILifetimeScope container)
        {
            _container = container;
        }

        public ILifetimeScope ApplicationContainer
        {
            get { return _container; }
        }

        public ILifetimeScope GetLifetimeScope(Action<ContainerBuilder> configurationAction)
        {
            return _lifetimeScope ?? (_lifetimeScope = BuildLifetimeScope(configurationAction));
        }

        public void EndLifetimeScope()
        {
            if (_lifetimeScope != null)
                _lifetimeScope.Dispose();
        }

        ILifetimeScope BuildLifetimeScope(Action<ContainerBuilder> configurationAction)
        {
            return (configurationAction == null)
                       ? _container.BeginLifetimeScope(HttpRequestTag)
                       : _container.BeginLifetimeScope(HttpRequestTag, configurationAction);
        }
    }
}
