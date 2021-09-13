﻿using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService : ICadastravel<Parceiro>
    {
        private IRepositor<Parceiro> repositorio;

        public ParceiroAppService(IRepositor<Parceiro> repositor)
        {
            repositorio = repositor;
        }

        public string InserirNovo(Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.Editar(id, registro);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            return repositorio.Excluir(id);
        }

        public bool Existe(int id)
        {
            return repositorio.Existe(id);
        }


        public Parceiro SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<Parceiro> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
