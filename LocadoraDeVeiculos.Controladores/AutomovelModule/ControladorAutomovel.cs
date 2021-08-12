using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.AutomovelModule
{
    public class ControladorAutomovel : Controlador<Automovel>
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
		        [grupo]
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
		        @grupo
	        );";
        #endregion

        public override string InserirNovo(Automovel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.id = Db.Insert(sqlInserirAutomovel, ObtemParametrosAutomovel(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Automovel registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override Automovel SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Automovel> SelecionarTodos()
        {
            throw new NotImplementedException();
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

            return parametros;
        }
    }
}
