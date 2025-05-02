using Newtonsoft.Json;

namespace ShopApi.Config
{
    public class MyAppSettings
    {
        public Logging Logging { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Option option { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class ConnectionStrings
    {
        public string shop_db { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        [JsonProperty("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Option
    {
    }
}
