using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class RequisicaoEmail
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public string EmailDestino { get; set; }
        public string NomePdf { get; set; }
    }
}
