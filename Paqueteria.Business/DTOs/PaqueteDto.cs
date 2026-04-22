namespace Paqueteria.Business.DTOs
{
    public class PaqueteDto
    {
        public int Id { get; set; }
        public string TrackingCode { get; set; } = string.Empty;
        public string Courier { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string NombreResidente { get; set; } = string.Empty; // Para mostrarlo fácil en el Front
    }
}