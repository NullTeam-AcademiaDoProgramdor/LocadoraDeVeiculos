using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    public class RequisicaoEmailConfiguration : IEntityTypeConfiguration<RequisicaoEmail>
    {
        public void Configure(EntityTypeBuilder<RequisicaoEmail> builder)
        {
            builder.ToTable("TBRequisicaoEmail");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Mensagem)                
                .IsRequired();

            builder.Property(e => e.EmailDestino)
                .IsRequired();

            builder.Property(e => e.Arquivos)
                .HasConversion(v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<string[]>(v, null));

        }
    }
}
