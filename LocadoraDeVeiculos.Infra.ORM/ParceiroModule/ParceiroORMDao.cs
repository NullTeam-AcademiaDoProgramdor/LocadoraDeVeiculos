using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ParceiroModule
{
    public class ParceiroORMDao : RepositorBase<Parceiro>
    {
        public override bool Editar(int id, Parceiro registro)
        {
            try 
            {

                using var db = new DBLocadoraContext();

                registro.Id = id;

                db.Parceiros.Update(registro);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Excluir(int id)
        {
            try
            {
                using var db = new DBLocadoraContext();

                Parceiro temp = new()
                {
                    Id = id
                };

                db.Parceiros.Remove(temp);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Existe(int id)
        {
            using var db = new DBLocadoraContext();

            return db.Parceiros.Any(x => x.Id == id);
        }

        public override bool InserirNovo(Parceiro registro)
        {
            try
            {
                using var db = new DBLocadoraContext();

                db.Parceiros.Update(registro);

                db.SaveChanges();

                return true; 
            } 
            catch (Exception)
            {
                // Logar o erro aqui
                return false;
            }
        }

        public override Parceiro SelecionarPorId(int id)
        {
            using var db = new DBLocadoraContext();

            return db.Parceiros
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public override List<Parceiro> SelecionarTodos()
        {
            using var db = new DBLocadoraContext();

            return db.Parceiros.ToList();
        }
    }
}
