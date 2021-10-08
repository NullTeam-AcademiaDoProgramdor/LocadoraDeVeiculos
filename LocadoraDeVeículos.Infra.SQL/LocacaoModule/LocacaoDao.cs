using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeículos.Infra.SQL.AutomovelModule;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using LocadoraDeVeículos.Infra.SQL.FuncionarioModule;
using LocadoraDeVeículos.Infra.SQL.PessoaFisicaModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.LocacaoModule
{
    public class LocacaoDao : SQLDAOBase, IRepositorLocacaoBase
    {
        PessoaFisicaDao controladorPessoaFisica = null;
        AutomovelDao controladorAutomovel = null;
        FuncionarioDao controladorFuncionario = null;
        CupomDao controladorCupom = null;
        TaxasEServicosUsadosDao controladorTaxas = null;

        public LocacaoDao()
        {
            controladorPessoaFisica = new();
            controladorAutomovel = new();
            controladorFuncionario = new();
            controladorCupom = new();
            controladorTaxas = new();
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
                    [PORCENTAGEMFINALCOMBUSTIVEL],
                    [CUPOM]
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
                    @PORCENTAGEMFINALCOMBUSTIVEL,
                    @CUPOM
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
                    [PORCENTAGEMFINALCOMBUSTIVEL] = @PORCENTAGEMFINALCOMBUSTIVEL,
                    [CUPOM] = @CUPOM
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
                    [PORCENTAGEMFINALCOMBUSTIVEL],
                    [CUPOM]
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
                    [PORCENTAGEMFINALCOMBUSTIVEL],
                    [CUPOM]
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

        public bool InserirNovo(Locacao registro)
        {
            Serilog.Log.Logger.Aqui().Information("Inserindo {Feature}", "Locação");

            Serilog.Log.Debug($"SQL inserir Locação: {sqlInserirLocacao}");
            registro.id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));            

            return registro.Id != 0;
        }

        public bool Devolver(int id, Locacao locacao)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information("Devolvendo {Feature}, id: {Id}", "Locação", id);

                Serilog.Log.Debug($"SQL devolver Locação: {sqlEditarLocacao}");
                locacao.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(locacao));

                return true;
            }
            catch (Exception e )
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool Editar(int id, Locacao locacao)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information("Editando {Feature}, id: {Id}", "Locação", id);

                Serilog.Log.Debug($"SQL editar Locação: {sqlEditarLocacao}");
                locacao.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(locacao));
                
                return true;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool EditarKmRegistrada(Locacao locacao)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Quilometragem registrada do veículo [{locacao.Automovel.Modelo}]");

                locacao.Automovel.KmRegistrada = (int)locacao.KmAutomovelFinal;
                controladorAutomovel.EditarKmRegistrada(locacao.Automovel.id, locacao.Automovel);

                return true;
            }
            catch (DbException e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {locacao.Automovel.Id}");
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information("Excluindo {Feature}, id: {Id}", "Locação", id);

                Serilog.Log.Debug($"SQL excluir Locação: {sqlExcluirLocacao}");
                Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
        }

        public Locacao SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information("Selecionando {Feature}, id: {Id}", "Locação", id);

            Serilog.Log.Debug($"SQL selecionar Locação por id: {sqlSelecionarLocacaoPorId}");
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
        }

        public List<Locacao> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information("Selecionando todas as {Feature}", "Locação");

            Serilog.Log.Debug($"SQL selecionar todas as Locações: {sqlSelecionarTodasLocacao}");
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

            Cupom cupom;
            if (reader["CUPOM"] == DBNull.Value)
                cupom = null;
            else
                cupom = controladorCupom.SelecionarPorId(
                    Convert.ToInt32(reader["CUPOM"])
                );

            locacao.Id = id;
            locacao.Cupom = cupom;
            locacao.TaxasEServicos = controladorTaxas.Buscar(locacao.id).ToList();

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

            if (locacao.Cupom == null)
                parametros.Add("CUPOM", null);
            else
                parametros.Add("CUPOM", locacao.Cupom.id);


            return parametros;
        }
    }
}
