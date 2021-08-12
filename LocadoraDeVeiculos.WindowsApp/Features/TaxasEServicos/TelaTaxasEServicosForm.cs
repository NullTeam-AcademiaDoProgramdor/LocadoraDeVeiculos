using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System.IO;

namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    public partial class TelaTaxasEServicosForm : Form
    {

        private TaxaEServico taxasEServicos;
        ControladorTaxasEServicos controlador = new ControladorTaxasEServicos();

        public TelaTaxasEServicosForm()
        {
            InitializeComponent();

            rdbTaxaFixa.Checked = true;
        }

        public TaxaEServico TaxasEServicos
        {
            get { return taxasEServicos; }
            set
            {
                taxasEServicos = value;

                txtId.Text = taxasEServicos.Id.ToString();

                txtNome.Text = taxasEServicos.Nome;

                txtPreco.Text = taxasEServicos.Preco.ToString();

                if (taxasEServicos.EhFixo == true)
                    rdbTaxaFixa.Checked = true;

                if (taxasEServicos.EhFixo == false)
                    rdbTaxaPorDia.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
           
            string nome = txtNome.Text;

            double preco = 0;
                
            CorrigirPreco(ref preco);

            if (preco == 0)
                DialogResult = DialogResult.None;

            bool ehFixo = VerificarSeEhFixo();

            taxasEServicos = new TaxaEServico(nome, preco, ehFixo);

            string resultadoValidacao = taxasEServicos.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }            
        }

        public bool VerificarSeEhFixo()
        {
            if(rdbTaxaFixa.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }

        public void CorrigirPreco(ref double preco)
        {
            try
            {
                preco = Convert.ToDouble(txtPreco.Text);
                return;
            }
            catch (Exception)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Campo preço inválido");
            }
            
        }

        private void TelaTaxasEServicosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
       
    }
}
