﻿using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.LocacaoModule
{
    public class ControladorLocacao : Controlador<Locacao>
    {
        ControladorPessoaFisica controladorPessoaFisica = new ControladorPessoaFisica();
        ControladorFuncionario controladorFuncionario;
        ControladorAutomovel controladorAutomovel;

        private ControladorTaxasEServicosUsados controladorTaxas;

        public ControladorLocacao()
        {
         //   this.controladorPessoaFisica = new ControladorPessoaFisica();
            this.controladorFuncionario = new ControladorFuncionario();
            this.controladorAutomovel = new ControladorAutomovel();

            this.controladorTaxas = new ControladorTaxasEServicosUsados();
        }

        #region Queries
        private const string sqlInserirLocacao =
            @"INSERT INTO [Locacao]
                (   
                    [CONDUTOR],
                    [AUTOMOVEL],            
                    [DATASAIDA],                 
                    [DATADEVOLUCAOESPERADA],
                    [DATADEVOLUCAO],
                    [CAUCAO],       
                    [PLANOSELECIONADO],
                    [FUNCIONARIO],                
                    [KMREGISTRADA],         
                    [KMAUTOMOVELFINAL],          
                    [PORCENTAGEMFINALCOMBUSTIVEL]
                )
            VALUES
                (
                    @CONDUTOR,
                    @AUTOMOVEL,
                    @DATASAIDA,
                    @DATADEVOLUCAOESPERADA,
                    @DATADEVOLUCAO,
                    @CAUCAO,       
                    @PLANOSELECIONADO,
                    @FUNCIONARIO,
                    @KMREGISTRADA,
                    @KMAUTOMOVELFINAL,
                    @PORCENTAGEMFINALCOMBUSTIVEL
                )";
        private const string sqlEditarLocacao =
            @" UPDATE [Locacao]
                SET 
                    [CONDUTOR] = @CONDUTOR, 
                    [AUTOMOVEL] = @AUTOMOVEL,
                    [DATASAIDA] = @DATASAIDA,                    
                    [DATADEVOLUCAOESPERADA] = @DATADEVOLUCAOESPERADA,     
                    [DATADEVOLUCAO] = @DATADEVOLUCAO,     
                    [CAUCAO] = @CAUCAO,       
                    [PLANOSELECIONADO] = @PLANOSELECIONADO,     
                    [FUNCIONARIO] = @FUNCIONARIO,     
                    [KMREGISTRADA] = @KMREGISTRADA,
                    [KMAUTOMOVELFINAL] = @KMAUTOMOVELFINAL,
                    [PORCENTAGEMFINALCOMBUSTIVEL] = @PORCENTAGEMFINALCOMBUSTIVEL

                WHERE [ID] = @ID";

        private const string sqlExcluirLocacao =
            @"DELETE FROM [Locacao] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodasLocacao =
            @"SELECT 
                    [ID],
                    [CONDUTOR],
                    [AUTOMOVEL],            
                    [DATASAIDA],                 
                    [DATADEVOLUCAOESPERADA],
                    [DATADEVOLUCAO],
                    [CAUCAO],           
                    [PLANOSELECIONADO],
                    [FUNCIONARIO],                
                    [KMREGISTRADA],         
                    [KMAUTOMOVELFINAL],          
                    [PORCENTAGEMFINALCOMBUSTIVEL]
            FROM
                    [Locacao]";

        private const string sqlSelecionarLocacaoPorId =
            @"SELECT 
                    [ID],
                    [CONDUTOR],
                    [AUTOMOVEL],            
                    [DATASAIDA],                 
                    [DATADEVOLUCAOESPERADA],
                    [DATADEVOLUCAO],
                    [CAUCAO],        
                    [PLANOSELECIONADO],                 
                    [FUNCIONARIO],                
                    [KMREGISTRADA],         
                    [KMAUTOMOVELFINAL],          
                    [PORCENTAGEMFINALCOMBUSTIVEL]
            FROM
                    [Locacao]
            WHERE 
                    [ID] = @ID";

        private const string sqlExisteLocacao =
            @"SELECT 
                COUNT(*) 
            FROM 
                [Locacao]
            WHERE 
                [ID] = @ID";        

        #endregion

        public override string InserirNovo(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));
                controladorTaxas.Modificar(registro.TaxasEServicos, registro.id);
            }

            return resultadoValidacao;
        }

        public string Devolver(int id, Locacao locacao)
        {
            string resultadoValidacao = locacao.ValidarDevolucao();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                locacao.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(locacao));
            }

            return resultadoValidacao;
        }


        public override string Editar(int id, Locacao locacao)
        {
            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                locacao.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(locacao));
                controladorTaxas.Modificar(locacao.TaxasEServicos, locacao.id);
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
        }

        public override Locacao SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
        }

        public override List<Locacao> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasLocacao, ConverterEmLocacao);
        }

        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var condutor = controladorPessoaFisica.SelecionarPorId((int)reader["CONDUTOR"]);
            var automovel = controladorAutomovel.SelecionarPorId((int)reader["AUTOMOVEL"]);
            var funcionario = controladorFuncionario.SelecionarPorId((int)reader["FUNCIONARIO"]);
            var dataSaida = Convert.ToDateTime(reader["DATASAIDA"]);
            var dataDevolucaoEsperada = Convert.ToDateTime(reader["DATADEVOLUCAOESPERADA"]);
            var caucao = Convert.ToInt32(reader["CAUCAO"]);
            var planoSelecionado = Convert.ToInt32(reader["PLANOSELECIONADO"]);
            var kmInicial = Convert.ToInt32(reader["KMREGISTRADA"]);

            Locacao locacao;
            if (reader["DATADEVOLUCAO"] == DBNull.Value)
                locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, planoSelecionado);

            else
            {
                var dataDevolucao = Convert.ToDateTime(reader["DATADEVOLUCAO"]);
                var kmFinal = Convert.ToInt32(reader["KMAUTOMOVELFINAL"]);
                var combustivelFinal = Convert.ToInt32(reader["PORCENTAGEMFINALCOMBUSTIVEL"]);

                locacao = new Locacao(condutor, automovel, funcionario
                , dataSaida, dataDevolucaoEsperada, caucao, kmInicial, planoSelecionado, kmFinal, combustivelFinal, dataDevolucao);

            }

            locacao.Id = id;

            locacao.TaxasEServicos = controladorTaxas.Buscar(locacao.id).ToArray();

            return locacao;
        }

        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("CONDUTOR", locacao.Condutor.id);
            parametros.Add("AUTOMOVEL", locacao.Automovel.id);
            parametros.Add("DATASAIDA", locacao.DataSaida);
            parametros.Add("DATADEVOLUCAOESPERADA", locacao.DataDevolucaoEsperada);
            parametros.Add("DATADEVOLUCAO", locacao.DataDevolucao);
            parametros.Add("CAUCAO", locacao.Caucao);
            parametros.Add("PLANOSELECIONADO", locacao.PlanoSelecionado);
            parametros.Add("FUNCIONARIO", locacao.Funcionario.id);
            parametros.Add("KMREGISTRADA", locacao.KmAutomovelIncial);
            parametros.Add("KMAUTOMOVELFINAL", locacao.KmAutomovelFinal);
            parametros.Add("PORCENTAGEMFINALCOMBUSTIVEL", locacao.PorcentagemFinalCombustivel);
           

            return parametros;
        }
    }
}
