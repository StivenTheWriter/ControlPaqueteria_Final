namespace Paqueteria.Domain.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool EstaActivo { get; set; } = true;
    }
}