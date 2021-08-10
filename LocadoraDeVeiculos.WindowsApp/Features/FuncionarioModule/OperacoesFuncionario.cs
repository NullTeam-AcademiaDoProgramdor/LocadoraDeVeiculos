using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.FuncionarioModule
{
    public class OperacoesFuncionario : ICadastravel
    {
        private readonly ControladorFuncionario controlador = null;
        private readonly TabelaFuncionarioControl tabelaFuncionario = null;

        public OperacoesFuncionario(ControladorFuncionario controladorFuncionario)
        {
            this.controlador = controladorFuncionario;
            tabelaFuncionario = new TabelaFuncionarioControl(); 
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaFuncionario.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para poder editar!", "Edição de Funcionários",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Funcionario funcionarioSelecionado = controlador.SelecionarPorId(id);

            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Funcionario);

                List<Funcionario> funcionarios = controlador.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário [{tela.Funcionario.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Funcionario);

                List<Funcionario> funcionarios = controlador.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionario [{tela.Funcionario.Nome}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Funcionario> grupos = controlador.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(grupos);

            return tabelaFuncionario;
        }
    }
}
