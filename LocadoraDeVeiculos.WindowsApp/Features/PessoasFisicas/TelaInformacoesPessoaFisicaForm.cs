using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public partial class TelaInformacoesPessoaFisicaForm : Form
    {
        private PessoaFisica pessoa;
        public TelaInformacoesPessoaFisicaForm(PessoaFisica pessoaSelecionada)
        {
            InitializeComponent();
            pessoa = pessoaSelecionada;

            NomearCampos();
        }

        private void NomearCampos()
        {
            this.Text = "Informações Detalhadas: " + pessoa.Nome;

            lblId.Text = pessoa.Id.ToString();
            lblCNH.Text = pessoa.CNH;
            lblCPF.Text = pessoa.CPF;
            lblEmail.Text = pessoa.Email;
            lblEmpresaLigada.Text = !(pessoa.PessoaJuridica == null)? pessoa.PessoaJuridica.Nome : "Nenhuma";
            lblEndereço.Text = pessoa.Endereco;
            lblNome.Text = pessoa.Nome;
            lblRG.Text = pessoa.RG;
            lblTelefone.Text = pessoa.Telefone;
            lblVencimento.Text = pessoa.VencimentoCNH.ToString("dd/MM/yyyy");
        }
    }
}
