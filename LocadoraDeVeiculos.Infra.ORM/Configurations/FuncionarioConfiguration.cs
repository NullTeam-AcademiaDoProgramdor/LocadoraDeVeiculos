using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)        
                .IsRequired();

            builder.Property(e => e.DataAdmissao)  
                .IsRequired();

            builder.Property(e => e.Salario)
                .IsRequired();

            builder.Property(e => e.Senha)        
                .IsRequired();
        }
    }
}