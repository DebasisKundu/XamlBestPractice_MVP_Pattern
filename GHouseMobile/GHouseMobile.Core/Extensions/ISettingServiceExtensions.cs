using GHouseMobile.Core.Services.Setting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace GHouseMobile.Core.Extensions
{
    public static class ISettingServiceExtensions
    {
        static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static T? Get<T>(this ISettingService settingService, string key, T? @default) where T : class
        {
            var serialized = settingService.Get(key, string.Empty);
            var result = @default;

            try
            {
                result = JsonConvert.DeserializeObject<T>(serialized, GetSerializerSettings());
            }
            catch (Exception ex)
            {
                //TODO: Log
            }

            return result;
        }

        public static void Set<T>(this ISettingService settingService, string key, T? obj) where T : class
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(obj, GetSerializerSettings());
                settingService.Set(key, serialized);
            }
            catch (Exception ex)
            {
                //TODO: Log
            }
        }
    }
}
