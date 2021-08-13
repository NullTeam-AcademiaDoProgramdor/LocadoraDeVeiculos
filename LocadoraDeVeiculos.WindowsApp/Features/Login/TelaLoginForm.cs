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

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                funcionario = controladorFuncionario.SelecionarPorNomeESenha(txtNome.Text, txtSenha.Text);
            }
        }
    }
}
