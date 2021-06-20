using Newtonsoft.Json;

namespace p2ska.Extensions
{
    public static class NewtonsoftJsonExtensions
    {
        public static JsonSerializerSettings DefaultSetting = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            MaxDepth = 16,
        };

        public static string ToJson(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(obj, DefaultSetting);
        }
    }
}