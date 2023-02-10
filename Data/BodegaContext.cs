using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bodega.Domain.Models;

namespace Bodega.Domain.Data
{
    public class BodegaContext : DbContext
    {
        public BodegaContext(DbContextOptions<BodegaContext> options)
            : base(options)
        {
        }

        public DbSet<Factura> Factura { get; set; } = default!;

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }
    }
}
