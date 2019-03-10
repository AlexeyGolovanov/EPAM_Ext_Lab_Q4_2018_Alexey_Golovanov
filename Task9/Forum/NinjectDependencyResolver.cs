namespace Forum
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Task9.Interfaces;
    using Task9.Repos;
    using Task9.Services;
    using Ninject;
    internal class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
            this.AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.kernel.Bind<IUserService>().To<UserService>();
            this.kernel.Bind<IUserRepository>().To<UserRepository>();
        }

    }
}
