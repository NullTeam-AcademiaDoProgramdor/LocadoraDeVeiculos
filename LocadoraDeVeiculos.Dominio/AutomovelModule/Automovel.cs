using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.AutomovelModule
{
    public class Automovel : EntidadeBase, IEquatable<Automovel>
    {
        public string Modelo { get; }

        public string Marca { get; }

        public string Cor { get; }
        
        public string Placa { get; }

        public string Chassi { get; }

        public int Ano { get; }

        public int NPortas { get; }

        public int CapacidadeTanque { get; }

        public int TamanhoPortaMalas { get; }

        public TipoCombustivelEnum TipoCombustivel { get; }

        public GrupoAutomovel Grupo { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Automovel);
        }

        public bool Equals(Automovel other)
        {
            return other != null &&
                   id == other.id &&
                   Id == other.Id &&
                   Modelo == other.Modelo &&
                   Marca == other.Marca &&
                   Cor == other.Cor &&
                   Placa == other.Placa &&
                   Chassi == other.Chassi &&
                   Ano == other.Ano &&
                   NPortas == other.NPortas &&
                   CapacidadeTanque == other.CapacidadeTanque &&
                   TamanhoPortaMalas == other.TamanhoPortaMalas &&
                   TipoCombustivel == other.TipoCombustivel &&
                   EqualityComparer<GrupoAutomovel>.Default.Equals(Grupo, other.Grupo);
        }

        public override int GetHashCode()
        {
            int hashCode = -1684633869;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Modelo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Marca);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Placa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Chassi);
            hashCode = hashCode * -1521134295 + Ano.GetHashCode();
            hashCode = hashCode * -1521134295 + NPortas.GetHashCode();
            hashCode = hashCode * -1521134295 + CapacidadeTanque.GetHashCode();
            hashCode = hashCode * -1521134295 + TamanhoPortaMalas.GetHashCode();
            hashCode = hashCode * -1521134295 + TipoCombustivel.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<GrupoAutomovel>.Default.GetHashCode(Grupo);
            return hashCode;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }


    }
}
