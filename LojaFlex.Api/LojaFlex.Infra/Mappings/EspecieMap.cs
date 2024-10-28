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
    public class EspecieMap : IEntityTypeConfiguration<Especie>
    {
        public void Configure(EntityTypeBuilder<Especie> entity)
        {
            entity.HasKey(e => e.IdEspecie);

            entity.ToTable("ESPECIE");

            entity.Property(e => e.IdEspecie)
                .IsRequired()
                .HasColumnName("ID_ESPECIE");

            entity.Property(e => e.DscEspecie)
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("DSC_ESPECIE");
        }
    }
}
