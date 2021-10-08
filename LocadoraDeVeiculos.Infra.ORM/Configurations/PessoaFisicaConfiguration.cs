using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("TBPessoaFisica");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired();

            builder.Property(p => p.CPF).IsRequired();

            builder.Property(p => p.RG).IsRequired();

            builder.Property(p => p.CNH).IsRequired();

            builder.Property(p => p.VencimentoCNH).IsRequired();

            builder.Property(p => p.Telefone).IsRequired();
            
            builder.Property(p => p.Endereco).IsRequired();

            builder.Property(p => p.Email).IsRequired();

            builder.HasOne(p => p.PessoaJuridica);
        }
    }
}
