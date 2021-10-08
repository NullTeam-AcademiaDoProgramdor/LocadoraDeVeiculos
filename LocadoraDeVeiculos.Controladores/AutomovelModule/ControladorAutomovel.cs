using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.AutomovelModule
{
    public class ControladorAutomovel : Controlador<Automovel>
    {
        private ControladorFotos controladorFotos = new ControladorFotos();
        private ControladorSelecionarIdsAutomoveisDisponiveis controladorSelecionarDisponiveis =
            new ControladorSelecionarIdsAutomoveisDisponiveis();

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

        #endregion

        public override string InserirNovo(Automovel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.id = Db.Insert(sqlInserirAutomovel, ObtemParametrosAutomovel(registro));
                //controladorFotos.Modificar(registro.Fotos, registro.id);
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Automovel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.id = id;
                Db.Update(sqlEditarAutomovel, ObtemParametrosAutomovel(registro));
                //controladorFotos.Modificar(registro.Fotos, registro.id);
            }

            return resultadoValidacao;
        }

        public string EditarKmRegistrada(int id, Automovel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.id = id;
                Db.Update(sqlEditarKmAutomovel, ObtemParametrosAutomovel(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirAutomovel, AdicionarParametro("id", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteAutomovel, AdicionarParametro("id", id));
        }

        public override Automovel SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecioneAutomovelPorId, ConverterEmAutomovel, AdicionarParametro("id", id));
        }

        public override List<Automovel> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosAutomoveis, ConverterEmAutomovel);
        }

        public List<Automovel> SelecionarDisponiveis()
        {
            List<Automovel> automovels = new List<Automovel>();
            int[] idsDisponiveis =
                controladorSelecionarDisponiveis.SelecionarIdsDisponiveis();

            foreach (int id in idsDisponiveis)
            {
                automovels.Add(this.SelecionarPorId(id));
            }

            return automovels;
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

            var fotos = controladorFotos.Buscar(automovel.id);

            //automovel.Fotos = fotos;

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
    }
}