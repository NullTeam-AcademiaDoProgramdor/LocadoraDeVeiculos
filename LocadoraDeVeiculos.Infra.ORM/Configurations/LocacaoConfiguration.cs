using LocadoraDeVeiculos.Dominio.LocacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataSaida);

            builder.Property(p => p.DataDevolucaoEsperada);

            builder.Property(p => p.DataDevolucao);

            builder.Property(p => p.PlanoSelecionado);

            builder.Property(p => p.Caucao);

            builder.Property(p => p.Situacao);

            builder.Property(p => p.KmAutomovelIncial);

            builder.Property(p => p.KmAutomovelFinal);

            builder.Property(p => p.PorcentagemFinalCombustivel);

            builder.HasOne(p => p.Condutor);

            builder.HasOne(p => p.Automovel);

            builder.HasOne(p => p.Funcionario);

            builder.HasOne(p => p.Cupom);

            builder.HasMany(p => p.TaxasEServicos)
                .WithMany(p => p.Locacoes);
        }
    }
}
