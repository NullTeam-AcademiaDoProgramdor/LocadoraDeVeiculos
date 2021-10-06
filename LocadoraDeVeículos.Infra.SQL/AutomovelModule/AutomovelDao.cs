using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.AutomovelModule
{
    public class AutomovelDao : SQLDAOBase, IRepositorAutomovelBase
    {
        #region Queries
        private const string sqlInserirAutomovel =
            @"INSERT INTO [Automovel]
	        (
		        [placa],
		        [chassi],
		        [marca],
		        [cor],
		        [modelo],
		        [tipoCombustivel],
		        [capacidadeTanque],
		        [ano],
		        [capacidadePortaMalas],
		        [n_portas],
		        [cambio],
		        [direcao],
		        [grupo],
                [kmRegistrada]
	        )
	        VALUES
	        (
		        @placa,
		        @chassi,
		        @marca,
		        @cor,
		        @modelo,
		        @tipoCombustivel,
		        @capacidadeTanque,
		        @ano,
		        @capacidadePortaMalas,
		        @n_portas,
		        @cambio,
		        @direcao,
		        @grupo,
                @kmRegistrada
	        );";

        private const string sqlEditarAutomovel =
            @"UPDATE [Automovel]
	        SET
		        [placa] = @placa,
		        [chassi] = @chassi,
		        [marca] = @marca,
		        [cor] = @cor,
		        [modelo] = @modelo,
		        [tipoCombustivel] = @tipoCombustivel,
	            [capacidadeTanque] = @capacidadeTanque,
		        [ano] = @ano,
		        [capacidadePortaMalas] = @capacidadePortaMalas,
		        [n_portas] = @n_portas,
		        [cambio] = @cambio,
	            [direcao] = @direcao,
		        [grupo] = @grupo,
                [kmRegistrada] = @kmRegistrada
	        WHERE [id] = @id;";

        private const string sqlExcluirAutomovel =
            @"DELETE FROM [Automovel]
	            WHERE [id] = @id;";

        private const string sqlExisteAutomovel =
            @"SELECT
	            COUNT(*)
            FROM
	            [Automovel]
            WHERE
	            [id] = @id;";

        private const string sqlSelecionarTodosAutomoveis =
            @"SELECT
	            A.id,
	            A.placa,
	            A.chassi,
	            A.marca,
	            A.cor,
	            A.modelo,
	            A.tipoCombustivel,
	            A.capacidadeTanque,
	            A.ano,
	            A.capacidadePortaMalas,
	            A.n_portas,
	            A.cambio,
	            A.direcao,
	            A.grupo,
                A.kmRegistrada,
	            G.nome,
	            G.planoDIario_precoDIa,
	            G.planoDiario_precoKm,
	            G.planoKmControlado_KmDisponiveis,
	            G.planoKmControlado_precoDia,
	            G.planoKmControlado_precoKmExtrapolado,
	            G.planoKmLivre_precoDia
            FROM
	            [Automovel] as A LEFT JOIN
	            [GrupoAutomovel] AS G
            ON
	            G.id = A.grupo;";

        private const string sqlSelecionarDisponíveis =
            @"SELECT
	            A.id,
	            A.placa,
	            A.chassi,
	            A.marca,
	            A.cor,
	            A.modelo,
	            A.tipoCombustivel,
	            A.capacidadeTanque,
	            A.ano,
	            A.capacidadePortaMalas,
	            A.n_portas,
	            A.cambio,
	            A.direcao,
	            A.grupo,
                A.kmRegistrada,
	            G.nome,
	            G.planoDIario_precoDIa,
	            G.planoDiario_precoKm,
	            G.planoKmControlado_KmDisponiveis,
	            G.planoKmControlado_precoDia,
	            G.planoKmControlado_precoKmExtrapolado,
	            G.planoKmLivre_precoDia
            FROM
                [Locacao] L RIGHT JOIN
                [Automovel] A on L.automovel = A.id LEFT JOIN
                [GrupoAutomovel] G on A.grupo = G.id
            WHERE L.id is NULL or L.dataDevolucao is NOT NULL;";

        private const string sqlSelecioneAutomovelPorId =
            @"SELECT
	            A.id,
	            A.placa,
	            A.chassi,
	            A.marca,
	            A.cor,
	            A.modelo,
	            A.tipoCombustivel,
	            A.capacidadeTanque,
	            A.ano,
	            A.capacidadePortaMalas,
	            A.n_portas,
	            A.cambio,
	            A.direcao,
	            A.grupo,
                A.kmRegistrada,
	            G.nome,
	            G.planoDIario_precoDIa,
	            G.planoDiario_precoKm,
	            G.planoKmControlado_KmDisponiveis,
	            G.planoKmControlado_precoDia,
	            G.planoKmControlado_precoKmExtrapolado,
	            G.planoKmLivre_precoDia
            FROM
	            [Automovel] as A LEFT JOIN
	            [GrupoAutomovel] AS G
            ON
	            G.id = A.grupo
            WHERE
	            A.id = @id;";

        private const string sqlEditarKmAutomovel =
            @"UPDATE [Automovel]
	        SET		        
                [kmRegistrada] = @kmRegistrada
	        WHERE [id] = @id";

        private const string sqlSelecionarDatasDevolucaoAutomoveis =
            @"SELECT
	            A.id,
	            L.id as locacaoId,
	            L.dataDevolucao
            FROM
	            [Automovel] A LEFT JOIN
	            [Locacao] L
		            ON A.id = L.automovel";

        #endregion

        private class EntidadeAutomovelDataDevolucao
        {
            public int automovelId;
            public int? locacaoId;
            public DateTime? dataDevolucao;

            public EntidadeAutomovelDataDevolucao(int automovelId, int? locacaoId, DateTime? dataDevolucao)
            {
                this.automovelId = automovelId;
                this.locacaoId = locacaoId;
                this.dataDevolucao = dataDevolucao;
            }
        }

        public bool Editar(int id, Automovel registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Automovel [{registro.Modelo}]:{id}");

                Serilog.Log.Debug($"SQL editar automovel: {sqlEditarAutomovel}");

                registro.id = id;
                Db.Update(sqlEditarAutomovel, ObtemParametrosAutomovel(registro));

                return true;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool EditarKmRegistrada(int id, Automovel registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Km Registrada do Automovel [{registro.Modelo}]:{id}");

                Serilog.Log.Debug($"SQL editar km automovel: {sqlEditarKmAutomovel}");

                registro.id = id;
                Db.Update(sqlEditarKmAutomovel, ObtemParametrosAutomovel(registro));

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
                Serilog.Log.Logger.Aqui().Information($"Excluindo Automovel {id}");

                Serilog.Log.Debug($"SQL excluir automovel: {sqlExcluirAutomovel}");

                Db.Delete(sqlExcluirAutomovel, AdicionarParametro("id", id));
            }
            catch (DbException e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteAutomovel, AdicionarParametro("id", id));
        }

        public bool InserirNovo(Automovel registro)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Automovel [{registro.Modelo}]");

            Serilog.Log.Debug($"SQL inserir automovel: {sqlInserirAutomovel}");

            registro.id = Db.Insert(sqlInserirAutomovel, ObtemParametrosAutomovel(registro));

            return registro.Id != 0;
        }

        public Automovel SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Automovel por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar automovel por id: {sqlSelecioneAutomovelPorId}");

            return Db.Get(sqlSelecioneAutomovelPorId, ConverterEmAutomovel, AdicionarParametro("id", id));
        }

        public List<Automovel> SelecionarAutomoveisDisponiveis()
        {
            List<Automovel> automovels = new List<Automovel>();
            int[] idsDisponiveis = this.SelecionarIdsDisponiveis();

            foreach (int id in idsDisponiveis)
            {
                automovels.Add(this.SelecionarPorId(id));
            }

            Serilog.Log.Logger.Aqui().Information($"Selecionando Automoveis disponiveis: {automovels}");

            return automovels;
        }

        public List<Automovel> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Automoveis todos os automoveis");

            Serilog.Log.Debug($"SQL Selecionar todos os automoveis: {sqlSelecionarTodosAutomoveis}");

            return Db.GetAll(sqlSelecionarTodosAutomoveis, ConverterEmAutomovel);
        }

        private Automovel ConverterEmAutomovel(IDataReader reader)
        {
            #region Automovel
            var placa = Convert.ToString(reader["placa"]);
            var chassi = Convert.ToString(reader["chassi"]);
            var marca = Convert.ToString(reader["marca"]);
            var cor = Convert.ToString(reader["cor"]);
            var modelo = Convert.ToString(reader["modelo"]);

            var ano = Convert.ToInt32(reader["ano"]);
            var portas = Convert.ToInt32(reader["n_portas"]);
            var capacidadeTanque = Convert.ToInt32(reader["capacidadeTanque"]);
            var tamanhoPortaMalas = Convert.ToInt32(reader["capacidadePortaMalas"]);
            var kmInicial = Convert.ToInt32(reader["kmRegistrada"]);

            var tipoCombustivel = Convert.ToInt32(reader["tipoCombustivel"]);
            var cambio = Convert.ToInt32(reader["cambio"]);
            var direcao = Convert.ToInt32(reader["direcao"]);

            var grupo_id = Convert.ToInt32(reader["grupo"]);
            #endregion

            #region grupo
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

            GrupoAutomovel grupoAutomovel =
                new GrupoAutomovel(nome, planoDiario, planoKmControlado, planoKmLivre)
                {
                    Id = grupo_id
                };

            #endregion

            Automovel automovel = new Automovel(modelo, marca, cor, placa, chassi, ano,
                portas, capacidadeTanque, kmInicial, tamanhoPortaMalas,
                (TipoCombustivelEnum)tipoCombustivel, (CambioEnum)cambio,
                (DirecaoEnum)direcao, grupoAutomovel);

            automovel.Id = Convert.ToInt32(reader["id"]);

            return automovel;
        }

        private Dictionary<string, object> ObtemParametrosAutomovel(Automovel automovel)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("id", automovel.id);

            parametros.Add("placa", automovel.Placa);
            parametros.Add("chassi", automovel.Chassi);
            parametros.Add("marca", automovel.Marca);
            parametros.Add("cor", automovel.Cor);
            parametros.Add("modelo", automovel.Modelo);
            parametros.Add("tipoCombustivel", automovel.TipoCombustivel);
            parametros.Add("capacidadeTanque", automovel.CapacidadeTanque);
            parametros.Add("ano", automovel.Ano);
            parametros.Add("capacidadePortaMalas", automovel.TamanhoPortaMalas);
            parametros.Add("n_portas", automovel.Portas);
            parametros.Add("cambio", automovel.Cambio);
            parametros.Add("direcao", automovel.Direcao);
            parametros.Add("grupo", automovel.Grupo.Id);
            parametros.Add("kmRegistrada", automovel.KmRegistrada);

            return parametros;
        }

        private int[] SelecionarIdsDisponiveis()
        {
            var automoveis = Db.GetAll(sqlSelecionarDatasDevolucaoAutomoveis, ConverterParaEntidade);
            Dictionary<int, bool> tabelaDeFiltragem = new Dictionary<int, bool>();

            foreach (var entidade in automoveis)
            {
                if (entidade.locacaoId == null)
                {
                    tabelaDeFiltragem.Add(entidade.automovelId, true);
                    continue;
                }

                if (entidade.dataDevolucao == null)
                {
                    if (tabelaDeFiltragem.ContainsKey(entidade.automovelId))
                        tabelaDeFiltragem[entidade.automovelId] = false;
                    else
                        tabelaDeFiltragem.Add(entidade.automovelId, false);

                    continue;
                }

                if (!tabelaDeFiltragem.ContainsKey(entidade.automovelId))
                    tabelaDeFiltragem.Add(entidade.automovelId, true);
            }

            return tabelaDeFiltragem
                .Where(e => e.Value == true)
                .Select(e => e.Key)
                .ToArray();
        }

        private EntidadeAutomovelDataDevolucao ConverterParaEntidade(IDataReader reader)
        {
            int automovelId = Convert.ToInt32(reader["id"]);

            int? locacaoId;
            if (reader["locacaoId"] == DBNull.Value)
                locacaoId = null;
            else
                locacaoId = Convert.ToInt32(reader["locacaoId"]);

            DateTime? dataDevolucao;
            if (reader["dataDevolucao"] == DBNull.Value)
                dataDevolucao = null;
            else
                dataDevolucao = Convert.ToDateTime(reader["dataDevolucao"]);

            return new EntidadeAutomovelDataDevolucao(automovelId, locacaoId, dataDevolucao);
        }
    }
}
