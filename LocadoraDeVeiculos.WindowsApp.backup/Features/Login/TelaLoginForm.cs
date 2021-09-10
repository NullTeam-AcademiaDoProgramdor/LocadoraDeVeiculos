﻿using LocadoraDeVeiculos.Controladores.FuncionarioModule;
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
            if (txtNome.Text.ToLower() == "admin" && txtSenha.Text.ToLower() == "admin")
            {
                TelaPrincipalForm telaPrincipal = new TelaPrincipalForm();
                this.Hide();
                telaPrincipal.ShowDialog();
                this.Show();
                return;
            }

            funcionario = controladorFuncionario.SelecionarPorNomeESenha(txtNome.Text, txtSenha.Text);

            if (funcionario != null)
            {
                if ((funcionario.Nome == txtNome.Text) && (funcionario.Senha == txtSenha.Text))
                {
                    labelRodape.Text = "Bem Vindo!";
                    TelaPrincipalForm telaPrincipal = new TelaPrincipalForm(funcionario);

                    this.Hide();
                    telaPrincipal.ShowDialog();
                    this.Show();
                }
            }
            else
                labelRodape.Text = "Nome ou senha inválidos";


        }

        private void TelaLoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar_Click(sender, e);
        }
    }
}