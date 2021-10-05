using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.CupomModule
{
    public class Cupom : EntidadeBase, IEquatable<Cupom>
    {
        public Cupom(string codigo, Parceiro parceiro, string tipo, double valor, double valorMinimo, DateTime dataVencimento, int qtdUsos)
        {
            Codigo = codigo;
            Parceiro = parceiro;
            Tipo = tipo;
            Valor = valor;
            ValorMinimo = valorMinimo;
            DataVencimento = dataVencimento;
            QtdUsos = qtdUsos;
        }

        public Cupom()
        {
        }

        public string Codigo { get; }
        public virtual Parceiro Parceiro { get; set; }
        public string Tipo { get; }
        public double Valor { get; }
        public double ValorMinimo { get; }
        public DateTime DataVencimento { get; }
        public int QtdUsos { get; set; }

        public override string ToString()
        {
            return Codigo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cupom);
        }

        public bool Equals(Cupom other)
        {
            return other != null &&
                   id == other.id &&
                   Id == other.Id &&
                   Codigo == other.Codigo &&
                   EqualityComparer<Parceiro>.Default.Equals(Parceiro, other.Parceiro) &&
                   Tipo == other.Tipo &&
                   Valor == other.Valor &&
                   ValorMinimo == other.ValorMinimo &&
                   DataVencimento == other.DataVencimento &&
                   QtdUsos == other.QtdUsos;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (String.IsNullOrEmpty(Codigo))
                resultadoValidacao = "O campo código não pode estar vazio";

            if (String.IsNullOrEmpty(Tipo))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo tipo não pode estar vazio";

            if (Tipo == "Porcentagem" && Valor > 100)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O valor não pode ser maior que 100";

            if (Valor <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Insira um valor Válido";

            if (ValorMinimo < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Insira um valor mínimo Válido";

            if (DataVencimento < DateTime.Today)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data de vencimento não pode ser no passado";

            if (Parceiro == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um parceiro";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}