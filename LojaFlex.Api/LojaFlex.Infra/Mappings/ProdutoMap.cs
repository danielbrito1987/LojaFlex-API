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
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entity)
        {
            entity.HasKey(e => e.IdProduto);

            entity.ToTable("PRODUTO");

            entity.HasIndex(e => e.IdEspecie, "ID_ESPECIE");

            entity.HasIndex(e => e.IdFamilia, "ID_FAMILIA");

            entity.HasIndex(e => e.IdPais, "ID_PAIS");

            entity.Property(e => e.IdProduto)
                .HasColumnName("ID_PRODUTO")
                .IsRequired();

            entity.Property(e => e.DscColeta)
                .HasMaxLength(255)
                .HasColumnName("DSC_COLETA");

            entity.Property(e => e.DscColetor)
                .HasMaxLength(100)
                .HasColumnName("DSC_COLETOR");

            entity.Property(e => e.DscLugar)
                .HasMaxLength(100)
                .HasColumnName("DSC_LUGAR");

            entity.Property(e => e.DscNote)
                .HasMaxLength(255)
                .HasColumnName("DSC_NOTE");

            entity.Property(e => e.DscProduto)
                .HasMaxLength(255)
                .HasColumnName("DSC_PRODUTO");

            entity.Property(e => e.IdEspecie)
                .HasColumnType("int(11)")
                .HasColumnName("ID_ESPECIE")
                .IsRequired();

            entity.Property(e => e.IdFamilia)
                .HasColumnType("int(11)")
                .HasColumnName("ID_FAMILIA")
                .IsRequired();

            entity.Property(e => e.IdPais)
                .HasColumnType("int(11)")
                .HasColumnName("ID_PAIS")
                .IsRequired();

            entity.Property(e => e.NomeProduto)
                .HasMaxLength(50)
                .HasColumnName("NOME_PRODUTO")
                .IsRequired();

            entity.Property(e => e.QtdEstoque)
                .HasColumnType("int(11)")
                .HasColumnName("QTD_ESTOQUE");

            entity.Property(e => e.Qualidade)
                .HasMaxLength(50)
                .HasColumnName("QUALIDADE");

            entity.Property(e => e.Sku)
                .HasColumnType("int(11)")
                .HasColumnName("SKU")
                .IsRequired();

            entity.Property(e => e.StatusEstoque)
                .HasColumnType("int(11)")
                .HasColumnName("STATUS_ESTOQUE");

            entity.Property(e => e.Tamanho)
                .HasMaxLength(50)
                .HasColumnName("TAMANHO");

            entity.Property(e => e.Valor)
                .HasPrecision(10, 2)
                .HasColumnName("VALOR")
                .IsRequired();

            entity.Property(e => e.VideoLink1)
                .HasMaxLength(100)
                .HasColumnName("VIDEO_LINK_1");

            entity.Property(e => e.VideoLink2)
                .HasMaxLength(100)
                .HasColumnName("VIDEO_LINK_2");

            entity.Property(e => e.VideoLink3)
                .HasMaxLength(100)
                .HasColumnName("VIDEO_LINK_3");

            entity.Property(e => e.VideoLink4)
                .HasMaxLength(100)
                .HasColumnName("VIDEO_LINK_4");

            entity.Property(e => e.VideoLink5)
                .HasMaxLength(100)
                .HasColumnName("VIDEO_LINK_5");

            entity.Property(e => e.VideoLink6)
                .HasMaxLength(100)
                .HasColumnName("VIDEO_LINK_6");

            entity.Property(e => e.WoWp)
                .HasMaxLength(10)
                .HasColumnName("WO_WP");

            entity.HasOne(d => d.Especie)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdEspecie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUTO_ibfk_2");

            entity.HasOne(d => d.Familia)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUTO_ibfk_3");

            entity.HasOne(d => d.Pais)
                .WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUTO_ibfk_1");
        }
    }
}
