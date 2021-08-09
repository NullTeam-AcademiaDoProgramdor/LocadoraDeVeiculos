using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Tests.GrupoAutomovelModule
{
   
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorGupoAutomovelTest
    {
        ControladorGrupoAutomovel controlador = null;

        public ControladorGupoAutomovelTest()
        {
            controlador = new ControladorGrupoAutomovel();
        }
        
        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [GrupoAutomovel]");
        }


        [TestMethod]
        public void DeveInserir_GrupoAutomovel()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            controlador.InserirNovo(novoGrupo);

            GrupoAutomovel grupoEncontrado = controlador.SelecionarPorId(novoGrupo.id);
            grupoEncontrado.Should().Be(novoGrupo);
        }
    }
}
