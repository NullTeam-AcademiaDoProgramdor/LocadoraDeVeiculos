﻿using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace LocadoraDeVeiculos.Dominio.AutomovelModule
{
    public class Automovel : EntidadeBase, IEquatable<Automovel>
    {
        public string Modelo { get; }

        public string Marca { get; }

        public string Cor { get; }
        
        public string Placa { get; }

        public string Chassi { get; }

        public int Ano { get; }

        public int Portas { get; }

        public int CapacidadeTanque { get; }

        public int TamanhoPortaMalas { get; }

        public int KmRegistrada { get; set; }

        public TipoCombustivelEnum TipoCombustivel { get; }

        public CambioEnum Cambio { get; }

        public DirecaoEnum Direcao { get; }

        public GrupoAutomovel Grupo { get; }

        public Image[] Fotos { get; set; }

        public Automovel(string modelo, string marca, string cor, string placa, 
            string chassi, int ano, int portas, int capacidadeTanque, int kmRegistrada, 
            int tamanhoPortaMalas, TipoCombustivelEnum tipoCombustivel, 
            CambioEnum cambio, DirecaoEnum direcao, GrupoAutomovel grupo)
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
            Chassi = chassi;
            Ano = ano;
            Portas = portas;
            CapacidadeTanque = capacidadeTanque;
            KmRegistrada = kmRegistrada;
            TamanhoPortaMalas = tamanhoPortaMalas;
            TipoCombustivel = tipoCombustivel;
            Cambio = cambio;
            Direcao = direcao;
            Grupo = grupo;
            Fotos = new Image[0];
        }

        public Automovel(string modelo, string marca, string cor, string placa, 
            string chassi, int ano, int portas, int capacidadeTanque, int kmRegistrada,
            int tamanhoPortaMalas, TipoCombustivelEnum tipoCombustivel,
            CambioEnum cambio, DirecaoEnum direcao, GrupoAutomovel grupo, 
            Image[] fotos)
        {
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
            Chassi = chassi;
            Ano = ano;
            Portas = portas;
            CapacidadeTanque = capacidadeTanque;
            KmRegistrada = kmRegistrada;
            TamanhoPortaMalas = tamanhoPortaMalas;
            TipoCombustivel = tipoCombustivel;
            Cambio = cambio;
            Direcao = direcao;
            Grupo = grupo;
            Fotos = fotos;
        }

        public override string ToString()
        {
            return Modelo;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Modelo))
                resultadoValidacao += "O campo Modelo é obrigatorio";

            if (string.IsNullOrEmpty(Marca))
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Marca é obrigatorio";

            if (string.IsNullOrEmpty(Cor))
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Cor é obrigatorio";

            if (string.IsNullOrEmpty(Placa))
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Placa é obrigatorio";

            if (string.IsNullOrEmpty(Chassi))
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Chassi é obrigatorio";

            if (Ano < 1900)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"O Ano informado é muito antigo, você pode inserir carros de {PegarAnoFuturoValido()} até 1900";

            if (Ano > PegarAnoFuturoValido())
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"O ano informado é muito futuro, você pode inserir carros de {PegarAnoFuturoValido()} até 1900";

            if (Portas <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"O Numero de portas não pode ser 0 ou negativo";

            if (CapacidadeTanque <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"A capacidade do tanque não pode ser 0 ou negativo";

            if (KmRegistrada < 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"A quilometragem não pode ser negativa";

            if (TamanhoPortaMalas <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"O tamanho do porta malas não pode ser 0 ou negativo";

            if (Grupo == null)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    $"O Automovel obrigatoriamente precisa fazer parte de um Grupo";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        private int PegarAnoFuturoValido()
        {
            return DateTime.Now.AddYears(1).Year;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Automovel);
        }

        public bool Equals(Automovel other)
        {
            return other != null &&
                   id == other.id &&
                   Id == other.Id &&
                   Modelo == other.Modelo &&
                   Marca == other.Marca &&
                   Cor == other.Cor &&
                   Placa == other.Placa &&
                   Chassi == other.Chassi &&
                   Ano == other.Ano &&
                   Portas == other.Portas &&
                   CapacidadeTanque == other.CapacidadeTanque &&
                   TamanhoPortaMalas == other.TamanhoPortaMalas &&
                   KmRegistrada == other.KmRegistrada &&
                   TipoCombustivel == other.TipoCombustivel &&
                   Cambio == other.Cambio &&
                   Direcao == other.Direcao &&
                   EqualityComparer<GrupoAutomovel>.Default.Equals(Grupo, other.Grupo);
            //       EqualityComparer<Image[]>.Default.Equals(Fotos, other.Fotos);
        }

        public override int GetHashCode()
        {
            int hashCode = -2103942314;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Modelo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Marca);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Placa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Chassi);
            hashCode = hashCode * -1521134295 + Ano.GetHashCode();
            hashCode = hashCode * -1521134295 + Portas.GetHashCode();
            hashCode = hashCode * -1521134295 + CapacidadeTanque.GetHashCode();
            hashCode = hashCode * -1521134295 + TamanhoPortaMalas.GetHashCode();
            hashCode = hashCode * -1521134295 + KmRegistrada.GetHashCode();
            hashCode = hashCode * -1521134295 + TipoCombustivel.GetHashCode();
            hashCode = hashCode * -1521134295 + Cambio.GetHashCode();
            hashCode = hashCode * -1521134295 + Direcao.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<GrupoAutomovel>.Default.GetHashCode(Grupo);
            hashCode = hashCode * -1521134295 + EqualityComparer<Image[]>.Default.GetHashCode(Fotos);
            return hashCode;
        }
    }
}
