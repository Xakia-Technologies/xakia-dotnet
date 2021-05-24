using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace Xakia.API.Client.Helpers
{
    public static class JsonExtensions
    {
        public static T FromJson<T>(this string json)
        {
            var settings = new JsonSerializerSettings();
            settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            var entity = JsonConvert.DeserializeObject<T>(json, settings);
            return entity;
        }
    }
}
