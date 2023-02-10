using Bodega.Domain.Data;
using Bodega.Domain.Services;
using Bodega.Services;

namespace Bodega.Domain.Configuration
{
    public class UnidadTrabajo : IUnidadTrabajo, IDisposable
    {
        private readonly BodegaContext _context;

        public IProductoRepositorio ProductoRepositorio { get; private set; }

        public IFacturaRepositorio FacturaRepositorio { get; private set; }

        public UnidadTrabajo(BodegaContext context)
        {
            _context = context;
            ProductoRepositorio = new ProductoRepositorio(_context);
            FacturaRepositorio = new FacturaRepositorio(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
