﻿
using Foundation;
using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Services.Exceptions;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace GHouseMobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            RegisterPlatformDependencies();

            ContainerManager.Current.Build();

            var exceptionService = ContainerManager.Current.Resolve<IExceptionService>();

            exceptionService.Configure();

            exceptionService.RegisterGlobalExceptionHandler();

            global::Xamarin.Forms.Forms.Init();
            AnimationViewRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        static void RegisterPlatformDependencies()
        {
            //TODO: IMP - Register ios platform dependent services here only
        }
    }
}
