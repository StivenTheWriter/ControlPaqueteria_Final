using Paqueteria.Domain.Core;

namespace Paqueteria.Domain.Entities
{
    public class Paquete : BaseEntity
    {
        public string TrackingCode { get; set; } = string.Empty;
        public string Courier { get; set; } = string.Empty;
        public int ResidenteId { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public byte[]? FirmaEntrega { get; set; }

        // propiedad de navegación para Entity Frameworl
        public virtual Residente? Residente { get; set; }
    }
}