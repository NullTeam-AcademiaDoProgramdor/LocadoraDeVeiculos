using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.CupomModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("TBCupom");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Codigo)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
                
            builder.Property(e => e.DataVencimento)
                .IsRequired();

            builder.Property(e => e.QtdUsos)
                .IsRequired();

            builder.Property(e => e.Tipo)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(e => e.Valor)
                .IsRequired();

            builder.Property(e => e.ValorMinimo)
                .IsRequired();

            builder.HasOne(e => e.Parceiro);
        }
    }
}
