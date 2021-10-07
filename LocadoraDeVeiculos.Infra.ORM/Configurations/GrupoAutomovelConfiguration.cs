using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
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
    public class GrupoAutomovelConfiguration : IEntityTypeConfiguration<GrupoAutomovel>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomovel> builder)
        {
            builder.ToTable("TBGrupoAutomovel");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired();

            builder.Property(e => e.PlanoDiario)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null), 
                    v => JsonSerializer.Deserialize<PlanoDiarioStruct>(v, null)
                );
            
            builder.Property(e => e.PlanoKmControlado)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null), 
                    v => JsonSerializer.Deserialize<PlanoKmControladoStruct>(v, null)
                );

            builder.Property(e => e.PlanoKmLivre)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<PlanoKmLivreStruct>(v, null)
                );

        }
    }
}
