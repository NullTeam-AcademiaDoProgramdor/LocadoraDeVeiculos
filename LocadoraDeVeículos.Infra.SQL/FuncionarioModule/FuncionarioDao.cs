using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeículos.Infra.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.FuncionarioModule
{
    public class FuncionarioDao : RepositorFuncionarioBase
    {
        #region queries
        private const string sqlInserirFuncionario =
            @"INSERT INTO FUNCIONARIO 
	                (
		                [NOME], 
		                [DATADEENTRADA], 
		                [SALARIO],
                        [SENHA]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @DATADEENTRADA,
                        @SALARIO,
		                @SENHA
	                )";

        private const string sqlEditarFuncionario =
            @"UPDATE FUNCIONARIO
                    SET
                        [NOME] = @NOME, 
		                [DATADEENTRADA] = @DATADEENTRADA, 
		                [SALARIO] = @SALARIO,
                        [SENHA] = @SENHA
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirFuncionario =
            @"DELETE 
                    FROM 
                        FUNCIONARIO
                    WHERE
                        ID = @ID";

        private const string sqlExisteFuncionario =
            @"SELECT 
                COUNT(*) 
            FROM 
                [FUNCIONARIO]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarFuncionarioPorId =
            @"SELECT
                        [ID],
                        [NOME],
                        [DATADEENTRADA],
                        [SALARIO],
                        [SENHA]
                    FROM
                        FUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarFuncionarioNomeESenha =
            @"SELECT
                        [ID],
                        [NOME],
                        [DATADEENTRADA],
                        [SALARIO],
                        [SENHA]
                    FROM
                        FUNCIONARIO
                    WHERE 
                        NOME = @NOME 
                    AND
                        SENHA = @SENHA";

        private const string sqlSelecionarTodosFuncionarios =
            @"SELECT
                        [ID],
                        [NOME],
                        [DATADEENTRADA],
                        [SALARIO],
                        [SENHA]
	                FROM
                        FUNCIONARIO";
        #endregion

        public override bool InserirNovo(Funcionario funcionario)
        {
            funcionario.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(funcionario));
            return funcionario.Id != 0;
        }

        public override bool Editar(int id, Funcionario funcionario)
        {
            funcionario.Id = id;
            Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(funcionario));
            try
            {
                funcionario.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(funcionario));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public override Funcionario SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public override List<Funcionario> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
        }

        public override Funcionario SelecionarPorNomeESenha(string nome, string senha)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"NOME", nome}, {"SENHA",senha}
            };
            return Db.Get(sqlSelecionarFuncionarioNomeESenha, ConverterEmFuncionario, parametros);
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Nome);
            parametros.Add("DATADEENTRADA", funcionario.DataAdmissao);
            parametros.Add("SALARIO", funcionario.Salario);
            parametros.Add("SENHA", funcionario.Senha);

            return parametros;
        }

        private Funcionario ConverterEmFuncionario(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var nome = Convert.ToString(reader["NOME"]);
            var dataDeEntrada = Convert.ToDateTime(reader["DATADEENTRADA"]);
            var salario = Convert.ToDouble(reader["SALARIO"]);
            var senha = Convert.ToString(reader["SENHA"]);

            Funcionario funcionario = new Funcionario(nome, dataDeEntrada, salario, senha);

            funcionario.Id = id;

            return funcionario;
        }

    }
}
