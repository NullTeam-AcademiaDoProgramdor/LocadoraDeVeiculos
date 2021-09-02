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

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas
{
    public partial class TelaPessoaJuridicaForm : Form
    {
        PessoaJuridica pessoaJuridica;
        public TelaPessoaJuridicaForm()
        {
            InitializeComponent();
        }

        public PessoaJuridica PessoaJuridica
        {
            get { return pessoaJuridica; }

            set
            {
                pessoaJuridica = value;

                txtId.Text = pessoaJuridica.Id.ToString();
                txtNome.Text = pessoaJuridica.Nome;
                txtCNPJ.Text = pessoaJuridica.Cnpj;
                txtEndereco.Text = pessoaJuridica.Endereco;
                txtTelefone.Text = pessoaJuridica.Telefone;
                txtEmail.Text = pessoaJuridica.Email;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome, cnpj, endereco, telefone, email;
            
            nome = txtNome.Text;
            cnpj = txtCNPJ.Text;
            endereco = txtEndereco.Text;
            telefone = txtTelefone.Text;
            email = txtEmail.Text;

            if (txtCNPJ.Text == "  ,   ,   /    -")
                cnpj = null;
            
            if (txtTelefone.Text == "(  )     -")
                telefone = null;

            pessoaJuridica = new PessoaJuridica(nome, cnpj, telefone, endereco, email);

            string resultadoValidacao = pessoaJuridica.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaPessoaJuridicaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
