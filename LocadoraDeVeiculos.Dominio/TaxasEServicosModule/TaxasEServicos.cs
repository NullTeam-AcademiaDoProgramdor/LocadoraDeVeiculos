﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Shared;

namespace LocadoraDeVeiculos.Dominio.TaxasEServicosModule
{
    public class TaxasEServicos : EntidadeBase
    {
        int id;
        string nome;
        double preco;
        bool ehFixo;

        public TaxasEServicos(string nome, double preco, bool ehFixo)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.EhFixo = ehFixo;
        }               

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public bool EhFixo { get => ehFixo; set => ehFixo = value; }
        public int Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            return obj is TaxasEServicos servicos &&
                   Id == servicos.Id &&
                   nome == servicos.nome &&
                   preco == servicos.preco &&
                   ehFixo == servicos.ehFixo &&
                   Nome == servicos.Nome &&
                   Preco == servicos.Preco &&
                   EhFixo == servicos.EhFixo;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if(!(Nome is string))            
                resultadoValidacao += " O campo nome está inválido";            

            if(!(Preco is double))            
                resultadoValidacao += " O campo preço está inválido";            

            if(!(EhFixo is bool))            
                resultadoValidacao += " O campo ehFixo está inválido";            

            if(resultadoValidacao == "")            
                resultadoValidacao = "ESTA_VALIDO";            

            return resultadoValidacao;
        }

        public override int GetHashCode()
        {
            int hashCode = 1695060689;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(Preco);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(EhFixo);            
            return hashCode;
        }

    }
}
