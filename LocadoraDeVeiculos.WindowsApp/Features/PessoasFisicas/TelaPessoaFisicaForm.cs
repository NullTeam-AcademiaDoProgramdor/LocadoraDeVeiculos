using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public partial class TelaPessoaFisicaForm : Form
    {
        PessoaFisica pessoaFisica;
        private ControladorPessoaJuridica controladorPJuridica;
        public TelaPessoaFisicaForm()
        {
            InitializeComponent();
            cmbPJuridica.Items.Clear();
        }

        public TelaPessoaFisicaForm(List<PessoaJuridica> pessoasJuridicas, ControladorPessoaJuridica controlador) : this()
        {
            this.controladorPJuridica = controlador;
            CarregarContatos(pessoasJuridicas);
        }

        public PessoaFisica PessoaFisica
        {
            get { return pessoaFisica; }

            set
            {
                pessoaFisica = value;
                txtId.Text = pessoaFisica.Id.ToString();
                txtNome.Text = pessoaFisica.Nome;
                txtTelefone.Text = pessoaFisica.Telefone;
                txtCPF.Text = pessoaFisica.CPF;
                txtRG.Text = pessoaFisica.RG;
                txtEndereco.Text = pessoaFisica.Endereco;
                txtCNH.Text = pessoaFisica.CNH;
                dataPickCNH.Value = pessoaFisica.VencimentoCNH;
                
            }
        }

        private void CarregarContatos(List<PessoaJuridica> pessoasJuridicas)
        {
            cmbPJuridica.Items.Clear();

            foreach (PessoaJuridica item in pessoasJuridicas)
            {
                cmbPJuridica.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome, telefone, cpf, rg, endereco, numCNH;
            DateTime validadeCNH;
            PessoaJuridica pessoaJuridica;
            //inserindo

            nome = txtNome.Text;
            telefone = txtTelefone.Text;
            cpf = txtCPF.Text;
            rg = txtRG.Text;
            endereco = txtEndereco.Text;
            numCNH = txtCNH.Text;
            validadeCNH = dataPickCNH.Value;
            pessoaJuridica = (PessoaJuridica)cmbPJuridica.SelectedItem;

            pessoaFisica = new PessoaFisica(nome, cpf, rg, numCNH, validadeCNH, telefone, endereco, pessoaJuridica);

            string resultadoValidacao = pessoaJuridica.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
