using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.GrupoAutomovelModule
{
    public class GrupoAutomovel : EntidadeBase, IEquatable<GrupoAutomovel>
    {

        public string Nome { get; }

        public PlanoDiarioStruct PlanoDiario { get; }

        public PlanoKmControladoStruct PlanoKmControlado { get; }

        public PlanoKmLivreStruct PlanoKmLivre { get; }

        public GrupoAutomovel(string nome, PlanoDiarioStruct planoDiario,
            PlanoKmControladoStruct planoKmControlado, PlanoKmLivreStruct planoKmLivre)
        {
            Nome = nome;
            PlanoDiario = planoDiario;
            PlanoKmControlado = planoKmControlado;
            PlanoKmLivre = planoKmLivre;
        }

        public GrupoAutomovel()
        {
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GrupoAutomovel);
        }

        public bool Equals(GrupoAutomovel other)
        {
            return other != null &&
                   id == other.id &&
                   Nome == other.Nome &&
                   EqualityComparer<PlanoDiarioStruct>.Default.Equals(PlanoDiario, other.PlanoDiario) &&
                   EqualityComparer<PlanoKmControladoStruct>.Default.Equals(PlanoKmControlado, other.PlanoKmControlado);
        }

        public override int GetHashCode()
        {
            int hashCode = 1937713517;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + PlanoDiario.GetHashCode();
            hashCode = hashCode * -1521134295 + PlanoKmControlado.GetHashCode();
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = string.Empty;

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += "O campo nome é obrigatorio";

            if (PlanoDiario.PrecoDia <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Preco Dia do Plano Diario não pode ser 0 ou negativo";

            if (PlanoDiario.PrecoKm <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Preco Km do Plano Diario não pode ser 0 ou negativo";

            if (PlanoKmControlado.PrecoDia <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Preco Dia do Plano Km Controlado não pode ser 0 ou negativo";

            if (PlanoKmControlado.KmDisponiveis <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Km Disponivel do Plano Km Controlado não pode ser 0 ou negativo";

            if (PlanoKmControlado.PrecoKmExtrapolado <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Preco Km Extrapolado do Plano Km Controlado não pode ser 0 ou negativo";

            if (PlanoKmLivre.PrecoDia <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    "O campo Preco Dia do Plano Km Livre não pode ser 0 ou negativo";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}