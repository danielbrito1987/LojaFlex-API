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
    public class FamiliaMap : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> entity)
        {
            entity.HasKey(e => e.IdFamilia);

            entity.ToTable("FAMILIA");

            entity.Property(e => e.IdFamilia)
                .IsRequired()
                .HasColumnName("ID_FAMILIA");

            entity.Property(e => e.DscFamilia)
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("DSC_FAMILIA");
        }
    }
}
