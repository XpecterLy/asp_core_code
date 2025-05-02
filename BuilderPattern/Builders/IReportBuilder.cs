using BuilderPattern.Models;

namespace BuilderPattern.Builders
{
    public interface IReportBuilder
    {
        void BuildTitle();
        void BuildHeader();
        void BuildContent();
        void BuildFooter();
        Report GetReport();
    }
}
