
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Enums;
using GHouseMobile.Core.Services.Exceptions;
using System;

namespace GHouseMobile.Droid
{
    [Activity(Label = "GHouseMobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RegisterPlatformDependencies();

            ContainerManager.Current.Build();

            var exceptionService = ContainerManager.Current.Resolve<IExceptionService>();

            exceptionService.Configure();

            exceptionService.RegisterGlobalExceptionHandler();

            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) =>
            {
                var ex = new ApplicationException("AndroidEnvironment_UnhandledException", args.Exception);
                exceptionService.Log(ExceptionLevel.Critical, ex);
            };

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        static void RegisterPlatformDependencies()
        {
            //TODO: IMP - Register android platform dependent services here only
        }
    }
}