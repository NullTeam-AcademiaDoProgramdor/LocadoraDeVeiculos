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
        public bool EditarQtdUsos(Cupom cupom)
        {
            try
            {
                using var db = new DBLocadoraContext();

                cupom.QtdUsos++;

                db.Update(cupom);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cupom SelecionarPorCodigo(string codigo)
        {
            using var db = new DBLocadoraContext();

            return db.Cupoms
                .Where(x => x.Codigo == codigo)
                .FirstOrDefault();
        }

        public List<Cupom> SelecionarValidos()
        {
            using var db = new DBLocadoraContext();

            var dataHoje = DateTime.Now;

            return db.Cupoms
                .Where(x => x.DataVencimento >= dataHoje)
                .ToList();
        }
    }
}
