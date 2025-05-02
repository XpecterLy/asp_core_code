namespace BuilderPattern.Models
{
    public class Report
    {
        public string Title { get; set; } = "";
        public string Header { get; set; } = "";
        public string Content { get; set; } = "";
        public string Footer { get; set; } = "";

        public string Generate()
        {
            return $"{Title}\n{Header}\n{Content}\n{Footer}";
        }
    }
}
