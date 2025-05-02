using BuilderPattern.Models;

namespace BuilderPattern.Builders
{
    public class AdminReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void BuildTitle() => _report.Title = "Reporte del Administrador";
        public void BuildHeader() => _report.Header = "Encabezado: Información confidencial";
        public void BuildContent() => _report.Content = "Contenido: estadísticas completas y logs.";
        public void BuildFooter() => _report.Footer = "Pie: acceso restringido";

        public Report GetReport() => _report;
    }
}
