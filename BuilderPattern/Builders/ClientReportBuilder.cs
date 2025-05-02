using BuilderPattern.Models;

namespace BuilderPattern.Builders
{
    public class ClientReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void BuildTitle() => _report.Title = "Reporte del Cliente";
        public void BuildHeader() => _report.Header = "Encabezado: Información de clinete";
        public void BuildContent() => _report.Content = "Contenido: informacion de productos.";
        public void BuildFooter() => _report.Footer = "Pie: servicio de ventas";

        public Report GetReport() => _report;
    }
}
