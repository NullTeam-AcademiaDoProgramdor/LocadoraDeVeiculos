using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
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
        public TelaPessoaFisicaForm()
        {
            InitializeComponent();
            cmbPJuridica.Items.Clear();
        }

        public TelaPessoaFisicaForm(List<PessoaJuridica> pessoasJuridicas) : this()
        {
            CarregarPessoasJuridicas(pessoasJuridicas);
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
                txtEmail.Text = pessoaFisica.Email;
                txtCNH.Text = pessoaFisica.CNH;
                dataPickCNH.Value = pessoaFisica.VencimentoCNH;
                cmbPJuridica.SelectedItem = pessoaFisica.PessoaJuridica;

            }
        }

        private void CarregarPessoasJuridicas(List<PessoaJuridica> pessoasJuridicas)
        {
            cmbPJuridica.Items.Clear();

            foreach (PessoaJuridica item in pessoasJuridicas)
            {
                cmbPJuridica.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome, telefone, cpf, rg, endereco, numCNH, email;
            DateTime validadeCNH;
            PessoaJuridica pessoaJuridica;
            //inserindo

            nome = txtNome.Text;
            telefone = txtTelefone.Text;
            cpf = txtCPF.Text;
            rg = txtRG.Text;
            endereco = txtEndereco.Text;
            email = txtEmail.Text;
            numCNH = txtCNH.Text;
            validadeCNH = dataPickCNH.Value;

            pessoaJuridica = (PessoaJuridica)cmbPJuridica.SelectedItem != null &&
                cmbPJuridica.Enabled ? (PessoaJuridica)cmbPJuridica.SelectedItem : null;

            pessoaFisica = new PessoaFisica(nome, cpf, rg, numCNH, validadeCNH, telefone, endereco, pessoaJuridica, email);

            string resultadoValidacao = pessoaFisica.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void cbNaoHaPJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNaoHaPJuridica.Checked)
                cmbPJuridica.Enabled = false;
            else
                cmbPJuridica.Enabled = true;
        }
    }
}
