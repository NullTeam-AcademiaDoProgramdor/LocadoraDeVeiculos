using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule
{
    public class GrupoAutomovelDao : SQLDAOBase, IRepositorBase<GrupoAutomovel>
    {
        #region Queries
        private const string sqlInserirGrupo =
            @"INSERT INTO [GrupoAutomovel]
                (
                    [nome],
                    [planoDIario_precoDIa],
                    [planoDiario_precoKm],
                    [planoKmControlado_KmDisponiveis],
                    [planoKmControlado_precoDia],
                    [planoKmControlado_precoKmExtrapolado],
                    [planoKmLivre_precoDia]
                )
            VALUES
                (
                    @nome,
                    @planoDIario_precoDIa,
                    @planoDiario_precoKm,
                    @planoKmControlado_KmDisponiveis,
                    @planoKmControlado_precoDia,
                    @planoKmControlado_precoKmExtrapolado,
                    @planoKmLivre_precoDia
                )";


        private const string sqlEditarGrupo =
            @"UPDATE [GrupoAutomovel]
                SET 
                    [nome] = @nome,
                    [planoDIario_precoDIa] = @planoDIario_precoDIa,
                    [planoDiario_precoKm] = @planoDiario_precoKm,
                    [planoKmControlado_KmDisponiveis] = @planoKmControlado_KmDisponiveis,
                    [planoKmControlado_precoDia] = @planoKmControlado_precoDia,
                    [planoKmControlado_precoKmExtrapolado] = @planoKmControlado_precoKmExtrapolado,
                    [planoKmLivre_precoDia] = @planoKmLivre_precoDia
                WHERE [id] = @id";


        private const string sqlExcluirGrupo =
            @"DELETE FROM [GrupoAutomovel] 
                WHERE[id] = @id";


        private const string sqlSelecionaTodosGrupos =
            @"SELECT 
	            [id],
	            [nome],
	            [planoDIario_precoDIa],
	            [planoDiario_precoKm],
	            [planoKmControlado_precoDia],
	            [planoKmControlado_precoKmExtrapolado],
	            [planoKmControlado_KmDisponiveis],
	            [planoKmLivre_precoDia]
            FROM
	            [GrupoAutomovel] G
            ORDER BY
	            G.nome";

        private const string sqlSelecionaGrupoPorId =
            @"SELECT 
	            [id],
	            [nome],
	            [planoDIario_precoDIa],
	            [planoDiario_precoKm],
	            [planoKmControlado_precoDia],
	            [planoKmControlado_precoKmExtrapolado],
	            [planoKmControlado_KmDisponiveis],
	            [planoKmLivre_precoDia]
            FROM
	            [GrupoAutomovel]
            WHERE
	            [id] = @id";

        private const string sqlExisteGrupo =
            @"SELECT 
	            COUNT(*)
            FROM
	            [GrupoAutomovel]
            WHERE
	            [id] = @id";

        #endregion

        public bool InserirNovo(GrupoAutomovel registro)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Grupo de Automóvel [{registro.Nome}]");

            Serilog.Log.Debug($"SQL inserir Grupo de Automóvel: {sqlInserirGrupo}");
            registro.id = Db.Insert(sqlInserirGrupo, ObtemParametrosGrupo(registro));
            return registro.Id != 0;
        }

        public bool Editar(int id, GrupoAutomovel registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Grupo de Automóvel [{registro.Nome}]:{id}");

                Serilog.Log.Debug($"SQL editar Grupo de Automóvel: {sqlEditarGrupo}");
                registro.id = id;
                Db.Update(sqlEditarGrupo, ObtemParametrosGrupo(registro));

                return true;
            }
            catch (Exception e )
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Excluindo Grupo de Automóvel {id}");

                Serilog.Log.Debug($"SQL excluir Grupo de Automóvel: {sqlExcluirGrupo}");
                Db.Delete(sqlExcluirGrupo, AdicionarParametro("id", id));
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
            return Db.Exists(sqlExisteGrupo, AdicionarParametro("id", id));
        }


        public GrupoAutomovel SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Grupo de Automóvel por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar Grupo de Automóvel por id: {sqlSelecionaGrupoPorId}");
            return Db.Get(sqlSelecionaGrupoPorId, ConverterEmGrupoAutomovel, AdicionarParametro("id", id));
        }

        public List<GrupoAutomovel> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando todos os Grupos de Automóvel");

            Serilog.Log.Debug($"SQL Selecionar todos os Grupos de Automóvel: {sqlSelecionaTodosGrupos}");
            return Db.GetAll(sqlSelecionaTodosGrupos, ConverterEmGrupoAutomovel);
        }

        private GrupoAutomovel ConverterEmGrupoAutomovel(IDataReader reader)
        {
            string nome = Convert.ToString(reader["nome"]);

            double planoDiario_precoDia = Convert.ToDouble(reader["planoDIario_precoDIa"]);
            double planoDiario_precoKm = Convert.ToDouble(reader["planoDiario_precoKm"]);

            double planoKmControlado_precoDia = Convert.ToDouble(reader["planoKmControlado_precoDia"]);
            double planoKmControlado_precoKmExtrapolado = Convert.ToDouble(reader["planoKmControlado_precoKmExtrapolado"]);
            double planoKmControlado_kmDisponiveis = Convert.ToDouble(reader["planoKmControlado_KmDisponiveis"]);

            double planoKmLivre_precoDia = Convert.ToDouble(reader["planoKmLivre_precoDia"]);

            PlanoDiarioStruct planoDiario =
                new PlanoDiarioStruct(planoDiario_precoDia, planoDiario_precoKm);

            PlanoKmControladoStruct planoKmControlado =
                new PlanoKmControladoStruct(planoKmControlado_precoDia, planoKmControlado_precoKmExtrapolado, planoKmControlado_kmDisponiveis);

            PlanoKmLivreStruct planoKmLivre =
                new PlanoKmLivreStruct(planoKmLivre_precoDia);

            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(nome, planoDiario, planoKmControlado, planoKmLivre);

            grupoAutomovel.id = Convert.ToInt32(reader["id"]);

            return grupoAutomovel;
        }

        private Dictionary<string, object> ObtemParametrosGrupo(GrupoAutomovel grupoAutomovel)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("id", grupoAutomovel.id);

            parametros.Add("nome", grupoAutomovel.Nome);

            parametros.Add("planoDIario_precoDIa", grupoAutomovel.PlanoDiario.PrecoDia);
            parametros.Add("planoDiario_precoKm", grupoAutomovel.PlanoDiario.PrecoKm);

            parametros.Add("planoKmControlado_precoDia", grupoAutomovel.PlanoKmControlado.PrecoDia);
            parametros.Add("planoKmControlado_precoKmExtrapolado", grupoAutomovel.PlanoKmControlado.PrecoKmExtrapolado);
            parametros.Add("planoKmControlado_KmDisponiveis", grupoAutomovel.PlanoKmControlado.KmDisponiveis);

            parametros.Add("planoKmLivre_precoDia", grupoAutomovel.PlanoKmLivre.PrecoDia);

            return parametros;
        }
    }
}
