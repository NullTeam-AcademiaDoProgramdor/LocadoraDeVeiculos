﻿using LocadoraDeVeiculos.Dominio.FuncionarioModule;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.FuncionarioModule
{
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;
        public TelaFuncionarioForm()
        {
            InitializeComponent();
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                txtId.Text = funcionario.Id.ToString();

                txtNome.Text = funcionario.Nome;
                txtSalario.Text = funcionario.Salario.ToString();
                txtSenha.Text = funcionario.Senha;
                dtpDataAdmissao.Value = funcionario.DataAdmissao;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            DateTime dataAdmissao = dtpDataAdmissao.Value;
            double salario = Convert.ToDouble(txtSalario.Text);
            string senha = txtSenha.Text;

            funcionario = new Funcionario(nome, dataAdmissao, salario, senha);

            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
