using Bodega.Domain.Services;

namespace Bodega.Domain.Configuration
{
    public interface IUnidadTrabajo
    {
        IProductoRepositorio ProductoRepositorio { get; }
        IFacturaRepositorio FacturaRepositorio { get; }
        void Commit();
        void Dispose();
    }
}
