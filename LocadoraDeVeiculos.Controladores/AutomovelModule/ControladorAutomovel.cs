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
        public override string InserirNovo(Automovel registro)
        {
            throw new NotImplementedException();
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
    }
}
