using System;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace CovidAssignment.Controllers
{
    public class IocControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer _container;

        public IocControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext rqCtx, Type controllerType)
        {
            if (controllerType != null)
            {
                return _container.Resolve(controllerType) as IController;
            }
            return base.GetControllerInstance(rqCtx, controllerType);
        }
    }
}