using LocadoraDeVeiculos.Controladores.AutomovelModule;
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
        ControladorPessoaFisica controladorPessoaFisica;
        ControladorFuncionario controladorFuncionario;
        ControladorAutomovel controladorAutomovel;

        public ControladorLocacao(ControladorPessoaFisica controladorPessoaFisica, ControladorFuncionario controladorFuncionario, ControladorAutomovel controladorAutomovel)
        {
            this.controladorPessoaFisica = controladorPessoaFisica;
            this.controladorFuncionario = controladorFuncionario;
            this.controladorAutomovel = controladorAutomovel;
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
                    [FUNCIONARIO],                
                    [KMAUTOMOVELINICIAL],         
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
                    @FUNCIONARIO,
                    @KMAUTOMOVELINICIAL,
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
                    [FUNCIONARIO] = @FUNCIONARIO,     
                    [KMAUTOMOVELINICIAL] = @KMAUTOMOVELINICIAL,
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
                    [FUNCIONARIO],                
                    [KMAUTOMOVELINICIAL],         
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
                    [FUNCIONARIO],                
                    [KMAUTOMOVELINICIAL],         
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
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExisteLocacao, AdicionarParametro("ID", id));
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

        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            var condutor = controladorPessoaFisica.SelecionarPorId((int)reader["CONDUTOR"]);
            var automovel = controladorAutomovel.SelecionarPorId((int)reader["AUTOMOVEL"]);
            var funcionario = controladorFuncionario.SelecionarPorId((int)reader["FUNCIONARIO"]);
            var dataSaida = Convert.ToDateTime(reader["DATASAIDA"]);
            var dataDevolucaoEsperada = Convert.ToDateTime(reader["DATADEVOLUCAOESPERADA"]);
            var caucao = Convert.ToInt32(reader["CAUCAO"]);
            var kmInicial = Convert.ToInt32(reader["KMAUTOMOVELINICIAL"]);

            return new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, kmInicial);
        }

        public override List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("CONDUTOR", locacao.condutor.id);
            parametros.Add("AUTOMOVEL", locacao.automovel.id);
            parametros.Add("DATASAIDA", locacao.dataSaida);
            parametros.Add("DATADEVOLUCAOESPERADA", locacao.dataDevolucaoEsperada);
            parametros.Add("DATADEVOLUCAO", locacao.dataDevolucao);
            parametros.Add("CAUCAO", locacao.caucao);
            parametros.Add("FUNCIONARIO", locacao.funcionario.id);
            parametros.Add("KMAUTOMOVELINICIAL", locacao.kmAutomovelIncial);
            parametros.Add("KMAUTOMOVELFINAL", locacao.kmAutomovelFinal);
            parametros.Add("PORCENTAGEMFINALCOMBUSTIVEL", locacao.porcentagemFinalCombustivel);

            return parametros;
        }
    }
}
