using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.FotoModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.Automoveis
{
    public partial class TelaAutomovelForm : Form
    {
        private Automovel automovel;

        public Automovel Automovel
        {
            get { return automovel; }
            set
            {
                automovel = value;

                txtId.Text = automovel.id.ToString();
                txtModelo.Text = automovel.Modelo;
                txtMarca.Text = automovel.Marca;
                txtCor.Text = automovel.Cor;
                txtPlaca.Text = automovel.Placa;
                txtChassi.Text = automovel.Chassi;

                txtAno.Text = automovel.Ano.ToString();
                txtPortas.Text = automovel.Portas.ToString();
                txtCapacidadeCombustivel.Text = automovel.CapacidadeTanque.ToString();
                txtTamanhoPortaMalas.Text = automovel.TamanhoPortaMalas.ToString();
                txtKm.Text = automovel.KmRegistrada.ToString();

                imageGallery1.AddImages(automovel.Fotos.ToImageArray());

                SetarSelecaoComboTipoCombustivel(automovel.TipoCombustivel);
                SetarSelecaoCombioCambio(automovel.Cambio);
                SetarSelecaoComboDirecao(automovel.Direcao);
                SetarSelecaoComboGrupo(automovel.Grupo);
            }
        }

        private void SetarSelecaoComboGrupo(GrupoAutomovel grupo)
        {
            comboGrupo.SelectedItem = grupo;
        }

        private void SetarSelecaoComboDirecao(DirecaoEnum direcao)
        {
            comboDirecao.SelectedItem = direcao;

        }

        private void SetarSelecaoCombioCambio(CambioEnum cambio)
        {
            comboCambio.SelectedItem = cambio;
        }

        private void SetarSelecaoComboTipoCombustivel(TipoCombustivelEnum tipoCombustivel)
        {
            comboCombustivel.SelectedItem = tipoCombustivel;
        }


        public TelaAutomovelForm(List<GrupoAutomovel> grupos)
        {
            InitializeComponent();

            CarregarEnums();
            CarregarGrupos(grupos);
        }

        private void CarregarEnums()
        {
            comboCombustivel.DataSource = Enum.GetValues(typeof(TipoCombustivelEnum));
            comboDirecao.DataSource = Enum.GetValues(typeof(DirecaoEnum));
            comboCambio.DataSource = Enum.GetValues(typeof(CambioEnum));
        }

        private void CarregarGrupos(List<GrupoAutomovel> grupos)
        {
            comboGrupo.Items.AddRange(grupos.ToArray());
            comboGrupo.SelectedIndex = 0;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string modelo = txtModelo.Text;
            string marca = txtMarca.Text;
            string cor = txtCor.Text;
            string placa = txtPlaca.Text;
            string chassi = txtChassi.Text;

            int? ano = PegarIntComVerificacao(txtAno);
            int? portas = PegarIntComVerificacao(txtPortas);
            int? capacidadeCombustivel = PegarIntComVerificacao(txtCapacidadeCombustivel);
            int? capacidadePortaMalas = PegarIntComVerificacao(txtTamanhoPortaMalas);
            int? kmRegistrada = PegarIntComVerificacao(txtKm);

            if (ano == null)
                return;

            if (portas == null)
                return;

            if (capacidadeCombustivel == null)
                return;

            if (capacidadePortaMalas == null)
                return;
            
            TipoCombustivelEnum tipoCombustivel = (TipoCombustivelEnum)comboCombustivel.SelectedValue;
            CambioEnum cambio = (CambioEnum)comboCambio.SelectedValue;
            DirecaoEnum direcao = (DirecaoEnum)comboDirecao.SelectedValue;
            GrupoAutomovel grupo = (GrupoAutomovel)comboGrupo.SelectedItem;

            Image[] fotos = imageGallery1.Images.ToArray();

            automovel = new Automovel(
                modelo, marca, cor, placa, chassi, (int)ano, (int)portas,
                (int)capacidadeCombustivel, (int) kmRegistrada,(int)capacidadePortaMalas,
                tipoCombustivel, cambio, direcao, grupo
            );

            automovel.Fotos = fotos.ToFotoList();
            
            string resultadoValidacao = automovel.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }

        }

        private int? PegarIntComVerificacao(TextBox textBox)
        {
            try
            {
                return Convert.ToInt32(textBox.Text);
            }
            catch (Exception)
            {
                TelaPrincipalForm.Instancia
                    .AtualizarRodape($"Digite um numero no campo {textBox.AccessibleName}");
                DialogResult = DialogResult.None;
            }

            return null;
        }

    }
}
