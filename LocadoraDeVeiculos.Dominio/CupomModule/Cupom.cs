using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.CupomModule
{
    public class Cupom : EntidadeBase
    {
        public Cupom(string codigo, Parceiro parceiro, string tipo, double valor, double valorMinimo, DateTime dataVencimento)
        {
            Codigo = codigo;
            Parceiro = parceiro;
            Tipo = tipo;
            Valor = valor;
            ValorMinimo = valorMinimo;
            DataVencimento = dataVencimento;
        }
        
        public string Codigo { get; }
        public Parceiro Parceiro { get; }
        public string Tipo { get; }
        public double Valor { get; }
        public double ValorMinimo { get; }
        public DateTime DataVencimento { get; }
        public int QtdUsos { get; }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
