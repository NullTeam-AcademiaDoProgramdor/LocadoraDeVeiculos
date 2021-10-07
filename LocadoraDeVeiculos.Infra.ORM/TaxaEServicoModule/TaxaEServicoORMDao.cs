using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.TaxaEServicoModule
{
    public class TaxaEServicoORMDao : ORMDAOBase<TaxaEServico>, IRepositorTaxaEServicoBase
    {
        public TaxaEServicoORMDao(DBLocadoraContext db) : base(db)
        {

        }

        public TaxaEServico SelecionarPorNome(string nome)
        {
            return db.TaxasEServicos
                .Where(x => x.Nome == nome)
                .FirstOrDefault();
        }
    }

}
