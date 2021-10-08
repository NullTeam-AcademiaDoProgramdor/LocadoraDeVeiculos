using LocadoraDeVeiculos.Dominio.AutomovelModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.FotoModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    public partial class TelaInformaçõesAutomovelForm : Form
    {
        private Automovel automovel;

        public TelaInformaçõesAutomovelForm(Automovel automovel)
        {
            InitializeComponent();

            this.automovel = automovel;
            NomearCampos();
        }

        private void NomearCampos()
        {
            this.Text = "Informações Detalhadas: " + automovel.Modelo;

            lblId.Text = automovel.Id.ToString();

            lblModelo.Text = automovel.Modelo;
            lblMarca.Text = automovel.Marca;
            lblCor.Text = automovel.Cor;
            lblPlaca.Text = automovel.Placa;
            lblChassi.Text = automovel.Chassi;

            lblAno.Text = automovel.Ano.ToString();
            lblPortas.Text = automovel.Portas.ToString();
            lblCapacidadeCombustivel.Text = automovel.CapacidadeTanque.ToString() + " litros";
            lblTamanhoPortaMalas.Text = automovel.TamanhoPortaMalas.ToString() + " litros";

            lblCombustivel.Text = automovel.TipoCombustivel.ToString();
            lblCambio.Text = automovel.Cambio.ToString();
            lblDirecao.Text = automovel.Direcao.ToString();
            lblGrupo.Text = automovel.Grupo.ToString();

            imageGallery1.AddImages(automovel.Fotos.ToImageArray());

        }
    }
}
