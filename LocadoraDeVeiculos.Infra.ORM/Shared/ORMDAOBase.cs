using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Shared
{
    public abstract class ORMDAOBase<T> : IRepositorBase<T>
        where T : EntidadeBase, new()
    {
        public bool Editar(int id, T registro)
        {
            try
            {
                using var db = new DBLocadoraContext();

                registro.Id = id;

                db.Update(registro);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                using var db = new DBLocadoraContext();

                T temp = new()
                {
                    Id = id
                };

                db.Remove(temp);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Existe(int id)
        {
            using var db = new DBLocadoraContext();

            return db.Set<T>().Any(x => x.Id == id);
        }

        public bool InserirNovo(T registro)
        {
            try 
            { 
                using var db = new DBLocadoraContext();

                db.Add(registro);

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public T SelecionarPorId(int id)
        {
            using var db = new DBLocadoraContext();

            return db.Set<T>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<T> SelecionarTodos()
        {
            using var db = new DBLocadoraContext();

            return db.Set<T>().ToList();
        }


    }
}
