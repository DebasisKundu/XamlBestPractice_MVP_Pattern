using Autofac;
using GHouseMobile.Core.Services.Authentication;
using GHouseMobile.Core.Services.Connections;
using GHouseMobile.Core.Services.Exceptions;
using GHouseMobile.Core.Services.Navigation;
using GHouseMobile.Core.Services.Registration;
using GHouseMobile.Core.Services.Request;
using GHouseMobile.Core.Services.Setting;
using GHouseMobile.Core.Services.User;
using GHouseMobile.Core.ViewModel;
using System;

namespace GHouseMobile.Core.Abstraction
{
    public class ContainerManager
    {
        private IContainer? _container;
        private readonly ContainerBuilder _containerBuilder;

        public static ContainerManager Current { get; } = new ContainerManager();

        public ContainerManager()
        {
            _containerBuilder = new ContainerBuilder();

            _containerBuilder.RegisterType<UserService>().As<IUserService>();
            _containerBuilder.RegisterType<RegistrationService>().As<IRegistrationService>();
            _containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            _containerBuilder.RegisterType<ConnectivityService>().As<IConnectivityService>();
            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            _containerBuilder.RegisterType<RequestService>().As<IRequestService>();
            _containerBuilder.RegisterType<SettingService>().As<ISettingService>().SingleInstance();
            _containerBuilder.RegisterType<ExceptionService>().As<IExceptionService>().SingleInstance();

            _containerBuilder.RegisterType<HomeViewModel>();
            _containerBuilder.RegisterType<MainViewModel>();
            _containerBuilder.RegisterType<LoginViewModel>();
            _containerBuilder.RegisterType<RegisterViewModel>();
        }

        public T Resolve<T>() where T : notnull => _container!.Resolve<T>();

        public object Resolve(Type type) => _container!.Resolve(type);

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface where TInterface : notnull => _containerBuilder.RegisterType<TImplementation>().As<TInterface>();

        public void Register<T>() where T : class => _containerBuilder.RegisterType<T>();

        public void Build() => _container = _containerBuilder.Build();
    }
}
