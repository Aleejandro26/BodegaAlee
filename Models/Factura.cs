namespace Bodega.Domain.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string CodCliente { get; set; }
        public string Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public string FormaPago { get; set; }
        public bool EstadoFactura { get; set; }

        //RelationShip
        public ICollection<Producto> Productos { get; set; }
    }
}
