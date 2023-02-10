namespace Bodega.Domain.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public float PrecioVenta { get; set; }
        public float PrecioCosto { get; set; }
        public bool Estado { get; set; }
        public string Categoria { get; set; }

        //RelationShip
        public int IdFactura { get; set; }
        public Factura Factura { get; set; }
    }
}
