using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    public partial class TelaCupomForm : Form
    {
        private Cupom cupom;
        ControladorParceiro controladorParceiro;

        public TelaCupomForm()
        {
            InitializeComponent();

            controladorParceiro = new ControladorParceiro();
            CarregarParceiros();
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
                cmbParceiro.SelectedItem = cupom.Parceiro;
                cmbTipo.SelectedItem = cupom.Tipo;
                dtpDataVencimento.Value = cupom.DataVencimento;
            }
        }

        private void CarregarParceiros()
        {
            cmbParceiro.Items.Clear();
            var parceiros = controladorParceiro.SelecionarTodos();

            foreach (var item in parceiros)
            {
                cmbParceiro.Items.Add(item);
            }
        }

    }
}
