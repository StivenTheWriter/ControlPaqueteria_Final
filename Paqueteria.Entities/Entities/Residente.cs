using Paqueteria.Domain.Core;

namespace Paqueteria.Domain.Entities
{
    public class Residente : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Apartamento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}