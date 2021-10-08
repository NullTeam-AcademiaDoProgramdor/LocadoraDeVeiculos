using LocadoraDeVeiculos.Dominio.AutomovelModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    public class AutomovelConfiguration : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> builder)
        {
            builder.ToTable("TBAutomovel");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Modelo)
                .IsRequired();

            builder.Property(e => e.Marca)
                .IsRequired();

            builder.Property(e => e.Cor)
                .IsRequired();

            builder.Property(e => e.Placa)
                .IsRequired();

            builder.Property(e => e.Chassi)
                .IsRequired();

            builder.Property(e => e.Ano)
                .IsRequired();

            builder.Property(e => e.Portas)
                .IsRequired();

            builder.Property(e => e.CapacidadeTanque)
                .IsRequired();

            builder.Property(e => e.TamanhoPortaMalas)
                .IsRequired();

            builder.Property(e => e.KmRegistrada)
                .IsRequired();

            builder.Property(e => e.TipoCombustivel)
                .IsRequired();

            builder.Property(e => e.Cambio)
                .IsRequired();

            builder.Property(e => e.Direcao)
                .IsRequired();

            builder.HasOne(e => e.Grupo);

            builder.HasMany(e => e.Fotos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
