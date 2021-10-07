using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.ORM.PessoaJuridicaModule
{
    public class PessoaJuridicaORMDao : ORMDAOBase<PessoaJuridica>
    {
        public PessoaJuridicaORMDao(DBLocadoraContext db) : base(db)
        {
        }
    }
}
