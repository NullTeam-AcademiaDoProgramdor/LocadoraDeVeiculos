using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.ParceiroModule
{
    public class ControladorParceiro : Controlador<Parceiro>
    {
        #region Queries
        private const string sqlInserirParceiro =
            @"INSERT INTO [PARCEIRO]
                (       
                    [NOME]
                )
            VALUES
                (
                    @NOME
                )";

        private const string sqlEditarParceiro =
            @" UPDATE [PARCEIRO]
                SET 
                    [NOME] = @NOME

                WHERE [ID] = @ID";

        private const string sqlExcluirParceiro =
            @"DELETE FROM [PARCEIRO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarParceiroPorId =
            @"SELECT
                        [ID],
		                [NOME]
	                FROM
                        PARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosParceiros =
            @"SELECT
                        [ID],
		                [NOME]
	                FROM
                        PARCEIRO";

        private const string sqlExisteParceiros =
            @"SELECT 
                COUNT(*) 
            FROM 
                [PARCEIRO]
            WHERE 
                [ID] = @ID";

        #endregion

        public override string InserirNovo(Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(registro));
            }

            return resultadoValidacao;
        }

        
        public override string Editar(int id, Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiro(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }


        public override Parceiro SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Parceiro> SelecionarTodos()
        {
            throw new NotImplementedException();
        }


        private Dictionary<string, object> ObtemParametrosParceiro(Parceiro registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);

            return parametros;
        }
    }
}
