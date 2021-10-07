using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("TBPessoaJuridica");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cnpj)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(e => e.Endereco)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(e => e.Telefone)
                .IsRequired();
        }
    }
}
