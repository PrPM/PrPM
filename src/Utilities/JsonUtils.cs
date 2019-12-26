using Newtonsoft.Json;

namespace PrPM.Utilities
{
    class JsonUtils
    {
        public static string FormatJson(string json)
        {
            dynamic parsed = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsed, Formatting.Indented);
        }
    }
}