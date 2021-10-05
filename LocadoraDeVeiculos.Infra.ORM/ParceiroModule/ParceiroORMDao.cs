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
            using var db = new DBLocadoraContext();

            registro.Id = id;

            db.Parceiros.Update(registro);

            db.SaveChanges();

            return true;
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override bool InserirNovo(Parceiro registro)
        {
            using var db = new DBLocadoraContext();

            db.Parceiros.Update(registro);

            db.SaveChanges();

            return true; 
        }

        public override Parceiro SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Parceiro> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
