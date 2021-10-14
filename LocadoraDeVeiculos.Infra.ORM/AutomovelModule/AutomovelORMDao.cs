using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.AutomovelModule
{
    public class AutomovelORMDao : ORMDAOBase<Automovel>, IRepositorAutomovelBase
    {
        public AutomovelORMDao(DBLocadoraContext db) : base(db)
        {
        }

        public virtual bool EditarKmRegistrada(int id, Automovel registro)
        {
            return this.Editar(id, registro);
        }

        public List<Automovel> SelecionarAutomoveisDisponiveis()
        {
            List<Locacao> locacoes = db.Locacoes.ToList();

            Dictionary<Automovel, bool> tabelaDeFiltragem = new();

            foreach(Automovel automovel in db.Automoveis)
            {
                tabelaDeFiltragem.Add(automovel, true);
            }

            foreach(Locacao locacao in locacoes)
            {
                if (locacao.DataDevolucao == null)
                    tabelaDeFiltragem[locacao.Automovel] = false;
            }

            return tabelaDeFiltragem
                .Where(x => x.Value == true)
                .Select(x => x.Key)
                .ToList();
        }
    }
}
