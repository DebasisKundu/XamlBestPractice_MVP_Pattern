using System;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Utils
{
    public static class TaskUtils
    {
        public static async void FireAndForgetSafeAsync(this Task task,
            Action<Exception>? onException = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);
            }
        }
    }
}
