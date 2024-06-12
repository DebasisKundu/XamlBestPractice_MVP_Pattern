using GHouseMobile.Core.Enums;
using System.Collections.Generic;

namespace GHouseMobile.Core.Services.Exceptions
{
    public interface IExceptionService
    {
        void Configure();
        void RegisterGlobalExceptionHandler();
        void Log(ExceptionLevel exceptionLevel, object obj, IDictionary<string, object>? custom = null);
    }
}
