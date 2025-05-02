using BuilderPattern.Builders;
using BuilderPattern.Directors;
using Microsoft.AspNetCore.Mvc;

namespace BuilderPattern.Controllers
{
    public class ReportController : ControllerBase
    {
        [HttpGet("{type}")]
        public ActionResult GetReport(string type)
        {
            IReportBuilder builder = type switch
            {
                "admin" => new AdminReportBuilder(),
                "client" => new ClientReportBuilder(),
                _ => throw new ArgumentException("Tipo no soportado"),
            };

            var director = new ReportDirector(builder);
            director.BuildReport();
            var report = director.GetReport();

            return Ok(report.Generate());
        }
    }
}
