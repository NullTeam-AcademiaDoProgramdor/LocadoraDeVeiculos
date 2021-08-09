using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxasEServicosModule
{
    class TaxasEServicos
    {
        string nome;
        double preco;
        bool ehFixo;

        public TaxasEServicos(string nome, double preco, bool ehFixo)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.EhFixo = ehFixo;
        }

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public bool EhFixo { get => ehFixo; set => ehFixo = value; }

    }
}
