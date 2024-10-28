using LojaFlex.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFlex.Infra.Mappings
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> entity)
        {
            entity.HasKey(e => e.IdPais);

            entity.ToTable("PAIS");

            entity.Property(e => e.IdPais)
                .IsRequired()
                .HasColumnName("ID_PAIS");

            entity.Property(e => e.DscPais)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("DSC_PAIS");

            entity.Property(e => e.Sigla)
                .HasMaxLength(5)
                .IsRequired()
                .HasColumnName("SIGLA");
        }
    }
}
