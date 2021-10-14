using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.CupomModule
{
    public class CupomORMDao : ORMDAOBase<Cupom>, IRepositorCupomBase

    {
        public CupomORMDao(DBLocadoraContext db) : base(db)
        {
        }

        public virtual bool EditarQtdUsos(Cupom cupom)
        {
            try
            {
                cupom.QtdUsos++;

                db.Update(cupom);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cupom SelecionarPorCodigo(string codigo)
        {
            return db.Cupons
                .Where(x => x.Codigo == codigo)
                .FirstOrDefault();
        }

        public List<Cupom> SelecionarValidos()
        {
            var dataHoje = DateTime.Now;

            return db.Cupons
                .Where(x => x.DataVencimento >= dataHoje)
                .ToList();
        }
    }
}
