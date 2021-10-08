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

        protected DBLocadoraContext db;

        protected ORMDAOBase(DBLocadoraContext db)
        {
            this.db = db;
        }

        public virtual bool Editar(int id, T registro)
        {
            try
            {
                T temp = db.Set<T>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                registro.Id = id;

                db.Entry(temp).CurrentValues.SetValues(registro);

                foreach (var navObj in db.Entry(registro).Navigations)
                {
                    foreach (var navExist in db.Entry(temp).Navigations)
                    {
                        if (navObj.Metadata.Name == navExist.Metadata.Name)
                            navExist.CurrentValue = navObj.CurrentValue;
                    }
                }

                db.Update(temp);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                T temp = db.Set<T>()
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

        public bool Existe(int id)
        {
            return db.Set<T>().Any(x => x.Id == id);
        }

        public virtual bool InserirNovo(T registro)
        {
            try 
            { 
                db.Add(registro);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public T SelecionarPorId(int id)
        {
            return db.Set<T>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<T> SelecionarTodos()
        {
            return db.Set<T>().ToList();
        }


    }
}
