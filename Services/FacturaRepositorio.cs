using Bodega.Data;
using Bodega.Models;

namespace Bodega.Domain.Services
{
    public class FacturaRepositorio : RepositorioGenerico<Factura>, IFacturaRepositorio
    {
        public FacturaRepositorio(BodegaContext context) : base(context)
        {

        }
    }
}
