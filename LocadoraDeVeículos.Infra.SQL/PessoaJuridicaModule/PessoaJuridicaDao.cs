using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.PessoaJuridicaModule
{
    public class PessoaJuridicaDao : SQLDAOBase, IRepositorBase<PessoaJuridica>
    {
        #region Queries
        private const string sqlInserirPessoaJuridica =
            @"INSERT INTO [PESSOAJURIDICA]
                (       
                    [NOME], 
                    [CNPJ],
                    [ENDERECO],                    
                    [TELEFONE],         
                    [EMAIL]         
                )
            VALUES
                (
                    @NOME,
                    @CNPJ,
                    @ENDERECO,
                    @TELEFONE,         
                    @EMAIL
                )";

        private const string sqlEditarPessoaJuridica =
            @" UPDATE [PESSOAJURIDICA]
                SET 
                    [NOME] = @NOME, 
                    [CNPJ] = @CNPJ, 
                    [ENDERECO] = @ENDERECO,
                    [TELEFONE] = @TELEFONE,         
                    [EMAIL] = @EMAIL
                WHERE [ID] = @ID";

        private const string sqlExcluirPessoaJuridica =
            @"DELETE FROM [PESSOAJURIDICA] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarPessoaJuridicaPorId =
            @"SELECT
                    [ID],
		            [NOME], 
		            [CNPJ], 
		            [ENDERECO],
                    [TELEFONE],         
                    [EMAIL]   
	            FROM
                    PESSOAJURIDICA
                WHERE 
                    ID = @ID";

        private const string sqlSelecionarTodosPessoasJuridicas =
            @"SELECT
                    [ID],
		            [NOME], 
		            [CNPJ], 
		            [ENDERECO],
                    [TELEFONE],         
                    [EMAIL]   
	            FROM
                    PESSOAJURIDICA";

        private const string sqlExistePessoaJuridica =
            @"SELECT 
                COUNT(*) 
            FROM 
                [PESSOAJURIDICA]
            WHERE 
                [ID] = @ID";

        #endregion

        public bool InserirNovo(PessoaJuridica registro)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Pessoa Jurídica [{registro.Nome}]");

            Serilog.Log.Debug($"SQL inserir Pessoa Jurídica: {sqlInserirPessoaJuridica}");
            registro.Id = Db.Insert(sqlInserirPessoaJuridica, ObtemParametrosPessoaJuridica(registro));
            return registro.Id != 0;
        }

        public bool Editar(int id, PessoaJuridica registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Pessoa Jurídica [{registro.Nome}]:{id}");

                Serilog.Log.Debug($"SQL editar Pessoa Jurídica: {sqlEditarPessoaJuridica}");
                registro.Id = id;
                Db.Update(sqlEditarPessoaJuridica, ObtemParametrosPessoaJuridica(registro));
                return true;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Excluindo Pessoa Jurídica {id}");

                Serilog.Log.Debug($"SQL excluir Pessoa Jurídica: {sqlExcluirPessoaJuridica}");
                Db.Delete(sqlExcluirPessoaJuridica, AdicionarParametro("ID", id));
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
            return Db.Exists(sqlExistePessoaJuridica, AdicionarParametro("ID", id));
        }


        public PessoaJuridica SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Pessoa Jurídica por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar Pessoa Jurídica por id: {sqlSelecionarPessoaJuridicaPorId}");
            return Db.Get(sqlSelecionarPessoaJuridicaPorId, ConverterEmPessoaJuridica, AdicionarParametro("ID", id));
        }

        public List<PessoaJuridica> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando todas as Pessoa Jurídica");

            Serilog.Log.Debug($"SQL Selecionar todas as Pessoa Jurídica: {sqlSelecionarTodosPessoasJuridicas}");
            return Db.GetAll(sqlSelecionarTodosPessoasJuridicas, ConverterEmPessoaJuridica);
        }

        private Dictionary<string, object> ObtemParametrosPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", pessoaJuridica.Id);
            parametros.Add("NOME", pessoaJuridica.Nome);
            parametros.Add("CNPJ", pessoaJuridica.Cnpj);
            parametros.Add("ENDERECO", pessoaJuridica.Endereco);
            parametros.Add("TELEFONE", pessoaJuridica.Telefone);
            parametros.Add("EMAIL", pessoaJuridica.Email);

            return parametros;
        }

        private PessoaJuridica ConverterEmPessoaJuridica(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string cnpj = Convert.ToString(reader["CNPJ"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string email = Convert.ToString(reader["EMAIL"]);

            PessoaJuridica pessoaJuridica = new PessoaJuridica(nome, cnpj, telefone, endereco, email);

            pessoaJuridica.Id = id;

            return pessoaJuridica;
        }
    }
}
