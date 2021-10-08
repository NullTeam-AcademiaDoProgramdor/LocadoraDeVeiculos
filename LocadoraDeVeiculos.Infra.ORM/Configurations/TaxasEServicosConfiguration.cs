using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    public class TaxasEServicosConfiguration : IEntityTypeConfiguration<TaxaEServico>
    {
        public void Configure(EntityTypeBuilder<TaxaEServico> builder)
        {
            builder.ToTable("TBTaxaEServico");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(e => e.Preco)
                .IsRequired();

            builder.Property(e => e.EhFixo)
                .IsRequired();            
        }
    }
}
