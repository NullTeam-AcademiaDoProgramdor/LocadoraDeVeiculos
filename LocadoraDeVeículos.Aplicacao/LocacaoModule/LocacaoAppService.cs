using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService : ICadastravel<Locacao>
    {
        public string InserirNovo(Locacao registro)
        {
            throw new NotImplementedException();
        }
        
        public string Editar(int id, Locacao registro)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
