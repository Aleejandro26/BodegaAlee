using Bodega.Data;
using Bodega.Models;
using Microsoft.EntityFrameworkCore;

namespace Bodega.Domain.Services
{
    public class ProductoRepositorio : RepositorioGenerico<Producto>, IProductoRepositorio
    {
        private readonly BodegaContext _context;
        public ProductoRepositorio(BodegaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Producto>> GetAllSync()
        {
            var BodegaContext = _context.Producto.Include(p => p.Factura);
            return await BodegaContext.ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _dbSet.Include(p => p.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
