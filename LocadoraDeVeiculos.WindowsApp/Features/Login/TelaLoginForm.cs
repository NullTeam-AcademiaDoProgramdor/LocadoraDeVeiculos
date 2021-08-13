using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Login
{
    public partial class TelaLoginForm : Form
    {
        private Funcionario funcionario;
        private ControladorFuncionario controladorFuncionario;

        public TelaLoginForm()
        {
            InitializeComponent();
            controladorFuncionario = new ControladorFuncionario();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "Admin" && txtSenha.Text == "Admin")
            {
                TelaPrincipalForm telaPrincipal = new TelaPrincipalForm();
                telaPrincipal.ShowDialog();
                return;
            }

            funcionario = controladorFuncionario.SelecionarPorNomeESenha(txtNome.Text, txtSenha.Text);
            
            if(funcionario == null)
            {
                labelRodape.Text = "Nome ou senha inválidos";
            }
            else
            {
                labelRodape.Text = "Bem Vindo!";
                TelaPrincipalForm telaPrincipal = new TelaPrincipalForm(funcionario);                
                telaPrincipal.ShowDialog();                
            }
        }
    }
}
