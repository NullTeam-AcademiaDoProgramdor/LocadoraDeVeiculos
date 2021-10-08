using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.RequisicaoEmailModule
{
    public class RequisicaoEmailORMDao : IRepositorRequisicaoEmail
    {
        public RequisicaoEmailORMDao()
        {
        }

        public bool Excluir(int id)
        {
            try
            {
                using DBLocadoraContext db = new();

                RequisicaoEmail temp = db.Set<RequisicaoEmail>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                db.Remove(temp);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExisteAlgum()
        {
            using DBLocadoraContext db = new();

            return db.RequisicaoEmails.Any();
        }

        public bool InserirNovo(RequisicaoEmail registro)
        {
            try
            {
                using DBLocadoraContext db = new();

                db.Add(registro);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<RequisicaoEmail> SelecionarTodos()
        {
            using DBLocadoraContext db = new();

            return db.Set<RequisicaoEmail>().ToList();
        }
    }
}
