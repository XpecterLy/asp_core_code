using System.Text.Json.Serialization;

namespace TeamTask.Domain.Config
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
        [JsonPropertyName("db_team_task")]
        public string db_team_task { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        [JsonPropertyName("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Option
    {
        public string token_security { get; set; }
    }
}
