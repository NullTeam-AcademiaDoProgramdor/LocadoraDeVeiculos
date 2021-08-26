using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ParceiroModule
{
    public class Parceiro : IEquatable<Parceiro>
    {
        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parceiro);
        }

        public bool Equals(Parceiro other)
        {
            return other != null &&
                   Nome == other.Nome;
        }

        public override int GetHashCode()
        {
            return 285249808 + EqualityComparer<string>.Default.GetHashCode(Nome);
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
