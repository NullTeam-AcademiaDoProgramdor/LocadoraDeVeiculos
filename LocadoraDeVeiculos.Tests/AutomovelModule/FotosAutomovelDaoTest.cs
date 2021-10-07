using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using FluentAssertions;
using LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule;
using LocadoraDeVeículos.Infra.SQL.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.AutomovelModule;

namespace LocadoraDeVeiculos.Tests.AutomovelModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class FotosAutomovelDaoTest
    {
        private readonly string CaminhoImagens =
            @"..\..\..\AutomovelModule\TestImages";

        GrupoAutomovelDao controladorGrupoAutomovel = null;
        AutomovelAppService controlador = null;

        public FotosAutomovelDaoTest()
        {
            controlador = new(new AutomovelDao(), new FotosAutomovelDao());
            controladorGrupoAutomovel = new();
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [FotoAutomovel]");
            Db.Update("DELETE FROM [Automovel]");
            Db.Update("DELETE FROM [GrupoAutomovel]");
        }

        [TestMethod]
        public void DeveInserir_UmaImagem()
        {
            Automovel automovel = GerarAutomovel();

            Image image = Image.FromFile(PegarCaminhoImagem("img1.jpg"));

            //automovel.Fotos = new Image[]{ image };

            controlador.InserirNovo(automovel);

            Automovel automovelRecuperado = controlador.SelecionarPorId(automovel.id);

            automovelRecuperado.Fotos.Should().HaveCount(1);
        }

        [TestMethod]
        public void DeveInserir_VariasImagens()
        {
            Automovel automovel = GerarAutomovel();

            Image image1 = Image.FromFile(PegarCaminhoImagem("img1.jpg"));
            Image image2 = Image.FromFile(PegarCaminhoImagem("img2.jpg"));
            Image image3 = Image.FromFile(PegarCaminhoImagem("img3.jpg"));

            //automovel.Fotos = new Image[] { image1, image2, image3 };

            controlador.InserirNovo(automovel);

            Automovel automovelRecuperado = controlador.SelecionarPorId(automovel.id);

            automovelRecuperado.Fotos.Should().HaveCount(3);
        }

        [TestMethod]
        public void DeveExcluir_UmaImagem()
        {
            Automovel automovel = GerarAutomovel();
            Image image = Image.FromFile(PegarCaminhoImagem("img1.jpg"));
            //automovel.Fotos = new Image[] { image };
            controlador.InserirNovo(automovel);

            //----

            Automovel novoAutomovel = GerarAutomovel();
            //novoAutomovel.Fotos = new Image[0];
            controlador.Editar(automovel.id, novoAutomovel);

            Automovel automovelRecuperado = controlador.SelecionarPorId(automovel.id);
            automovelRecuperado.Fotos.Should().HaveCount(0);
        }

        [TestMethod]
        public void DeveExcluir_VariasImagens()
        {
            Automovel automovel = GerarAutomovel();
            Image image1 = Image.FromFile(PegarCaminhoImagem("img1.jpg"));
            Image image2 = Image.FromFile(PegarCaminhoImagem("img2.jpg"));
            Image image3 = Image.FromFile(PegarCaminhoImagem("img3.jpg"));
            //automovel.Fotos = new Image[] { image1, image2, image3 };
            controlador.InserirNovo(automovel);

            //----

            Automovel novoAutomovel = GerarAutomovel();
            //novoAutomovel.Fotos = new Image[0];
            controlador.Editar(automovel.id, novoAutomovel);

            Automovel automovelRecuperado = controlador.SelecionarPorId(automovel.id);
            automovelRecuperado.Fotos.Should().HaveCount(0);
        }

        [TestMethod]
        public void DeveModificar_UmaImagem()
        {
            Automovel automovel = GerarAutomovel();
            Image image = Image.FromFile(PegarCaminhoImagem("img1.jpg"));
            //automovel.Fotos = new Image[] { image };
            controlador.InserirNovo(automovel);

            //----

            Automovel novoAutomovel = GerarAutomovel();
            Image image2 = Image.FromFile(PegarCaminhoImagem("img2.jpg"));
            //novoAutomovel.Fotos = new Image[] { image2 };
            controlador.Editar(automovel.id, novoAutomovel);

            Automovel automovelRecuperado = controlador.SelecionarPorId(automovel.id);
            automovelRecuperado.Fotos.Should().HaveCount(1);
        }

        [TestMethod]
        public void DeveModificar_VariasImagens()
        {
            Automovel automovel = GerarAutomovel();
            Image image1 = Image.FromFile(PegarCaminhoImagem("img1.jpg"));
            Image image2 = Image.FromFile(PegarCaminhoImagem("img2.jpg"));
            Image image3 = Image.FromFile(PegarCaminhoImagem("img3.jpg"));
            //automovel.Fotos = new Image[] { image1, image2, image3 };
            controlador.InserirNovo(automovel);

            //----

            Automovel novoAutomovel = GerarAutomovel();
            Image image4 = Image.FromFile(PegarCaminhoImagem("img4.jpg"));
            //novoAutomovel.Fotos = new Image[] { image2, image3, image4 };
            controlador.Editar(automovel.id, novoAutomovel);

            Automovel automovelRecuperado = controlador.SelecionarPorId(automovel.id);
            automovelRecuperado.Fotos.Should().HaveCount(3);
        }

        private GrupoAutomovel CriarGrupo()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            controladorGrupoAutomovel.InserirNovo(novoGrupo);

            return novoGrupo;
        }

        private Automovel GerarAutomovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            return automovel;
        }

        private string PegarCaminhoImagem(string nomeArquivo)
        {
            return $"{CaminhoImagens}\\{nomeArquivo}";
        }
    }
}
