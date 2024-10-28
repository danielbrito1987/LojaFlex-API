using LojaFlex.Domain.Models;
using LojaFlex.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Infra.Context
{
    public class MaramarDbContext : DbContext
    {
        public MaramarDbContext(DbContextOptions<MaramarDbContext> options) : base(options) { }

        public virtual DbSet<Especie> Especies { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new EspecieMap());
            modelBuilder.ApplyConfiguration(new FamiliaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
