using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    public partial class TelaCupomForm : Form
    {
        private Cupom cupom;
        private string codigoAntigoCupom = "";
        List<Cupom> cuponsValidos;
        private bool estaEditando = false;

        public TelaCupomForm(List<Cupom> cupons, List<Parceiro> parceiros)
        {
            InitializeComponent();

            cuponsValidos = cupons;

            CarregarParceiros(parceiros);

            dtpDataVencimento.Value = DateTime.Today;
            cmbTipo.SelectedIndex = 0;
            cmbParceiro.SelectedIndex = 0;
        }

        public Cupom Cupom
        {
            get { return cupom; }

            set
            {
                cupom = value;

                txtId.Text = cupom.Id.ToString();
                txtCodigo.Text = cupom.Codigo;
                txtValor.Text = cupom.Valor.ToString();
                txtValorMinimo.Text = cupom.ValorMinimo.ToString();
                txtQtdUsos.Text = cupom.QtdUsos.ToString();
                cmbParceiro.SelectedItem = cupom.Parceiro;
                cmbTipo.SelectedItem = cupom.Tipo;
                dtpDataVencimento.Value = cupom.DataVencimento;
                estaEditando = true;
                codigoAntigoCupom = cupom.Codigo;
            }
        }

        private void CarregarParceiros(List<Parceiro> parceiros)
        {
            cmbParceiro.Items.Clear();

            foreach (var item in parceiros)
            {
                cmbParceiro.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            Parceiro parceiro = (Parceiro)cmbParceiro.SelectedItem;
            string tipo = cmbTipo.SelectedItem.ToString();
            double valor = 0;
            double valorMinimo = 0;
            VerificarValoresNumericos(ref valor, ref valorMinimo);
            DateTime dataVencimento = dtpDataVencimento.Value;
            int qtdUsos = Convert.ToInt32(txtQtdUsos.Text);

            cupom = new Cupom(codigo, parceiro, tipo, valor, valorMinimo, dataVencimento, qtdUsos);

            if (!EhValido(cupom))
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Este código já está sendo utilizado por outro cupom");
                DialogResult = DialogResult.None;
                return;
            }

            string resultadoValidacao = cupom.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        public bool EhValido(Cupom cupom)
        {
            foreach (var item in cuponsValidos)
            {
                if (item.Codigo == cupom.Codigo && !(estaEditando && cupom.Codigo == codigoAntigoCupom))
                    return false;
            }

            return true;
        }

        public void VerificarValoresNumericos(ref double valor, ref double valorMinimo)
        {
            try
            {
                valor = Convert.ToInt32(txtValor.Text);
            }
            catch (Exception)
            {
                valor = 0;
            }
            try
            {
                valorMinimo = Convert.ToInt32(txtValorMinimo.Text);
            }
            catch (Exception)
            {
                valorMinimo = 0;
            }

        }

        private void TelaCupomForm_Load(object sender, EventArgs e)
        {
        }
    }
}
