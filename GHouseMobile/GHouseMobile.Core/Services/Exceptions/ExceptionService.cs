using GHouseMobile.Core.Enums;
using Rollbar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Exceptions
{
    public class ExceptionService : IExceptionService
    {
        public void Configure()
        {
            var config = new RollbarConfig(GlobalSettings.RollbarAccessToken)
            {
                Environment = GlobalSettings.RollbarEnvironment
                //TODO: RND
                //ScrubFields = new string[] { } 
            };

            RollbarLocator.RollbarInstance.Configure(config).InternalEvent += OnRollbarInternalEvent;
        }

        public void RegisterGlobalExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += UnHandledException;
            TaskScheduler.UnobservedTaskException += UnobservedException;
        }

        public void Log(ExceptionLevel exceptionLevel, object obj, IDictionary<string, object>? custom = null)
        {
            switch (exceptionLevel)
            {
                case ExceptionLevel.Info:
                    RollbarLocator.RollbarInstance.Info(obj, custom);
                    break;
                case ExceptionLevel.Debug:
                    RollbarLocator.RollbarInstance.Debug(obj, custom);
                    break;
                case ExceptionLevel.Warning:
                    RollbarLocator.RollbarInstance.Warning(obj, custom);
                    break;
                case ExceptionLevel.Error:
                    RollbarLocator.RollbarInstance.AsBlockingLogger(TimeSpan.FromSeconds(GlobalSettings.RollbarTimeoutSeconds)).Error(obj, custom);
                    break;
                case ExceptionLevel.Critical:
                    RollbarLocator.RollbarInstance.AsBlockingLogger(TimeSpan.FromSeconds(GlobalSettings.RollbarTimeoutSeconds)).Critical(obj, custom);
                    break;
            }
        }

        private void UnHandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = new ApplicationException("UnhandledException", e.ExceptionObject as Exception);
            Log(ExceptionLevel.Critical, ex);
        }

        private void UnobservedException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var ex = new ApplicationException("UnobservedException", e.Exception);
            Log(ExceptionLevel.Critical, ex);
        }

        private void OnRollbarInternalEvent(object sender, RollbarEventArgs e)
        {
            if (e is RollbarApiErrorEventArgs apiErrorEventArgs)
            {
                //TODO: Log Rollbar API communication error event
                return;
            }

            if (e is CommunicationEventArgs communicationEventArgs)
            {
                return;
            }

            if (e is CommunicationErrorEventArgs communicationErrorEventArgs)
            {
                //TODO: Log Basic communication error while attempting to reach Rollbar API service
                return;
            }

            if (e is InternalErrorEventArgs internalErrorEventArgs)
            {
                //TODO: Log Basic internal error while using the Rollbar notifier
                return;
            }
        }
    }
}
