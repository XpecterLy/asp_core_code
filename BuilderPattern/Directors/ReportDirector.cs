using BuilderPattern.Builders;
using BuilderPattern.Models;

namespace BuilderPattern.Directors
{
    public class ReportDirector
    {
        private readonly IReportBuilder _builder;

        public ReportDirector(IReportBuilder builder)
        {
            _builder = builder;
        }

        public void BuildReport()
        {
            _builder.BuildTitle();
            _builder.BuildHeader();
            _builder.BuildContent();
            _builder.BuildFooter();
        }

        public Report GetReport() => _builder.GetReport();
    }
}
