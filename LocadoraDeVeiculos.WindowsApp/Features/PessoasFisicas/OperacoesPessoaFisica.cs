using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.WindowsApp.Features.PessoasJuridicas;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public class OperacoesPessoaFisica : ICadastravel
    {
        private readonly ControladorPessoaFisica controlador = null;
        private readonly ControladorPessoaJuridica controladorPJuridica = null;
        private readonly TabelaPessoaFisicaControl tabelaPessoaFisica = null;

        public OperacoesPessoaFisica(ControladorPessoaFisica ctrl)
        {
            controlador = ctrl;
            tabelaPessoaFisica = new TabelaPessoaFisicaControl();
            controladorPJuridica = new ControladorPessoaJuridica();
        }

        public void InserirNovoRegistro()
        {
            var pessoasJuridicas = controladorPJuridica.SelecionarTodos();

            TelaPessoaFisicaForm tela = new TelaPessoaFisicaForm(pessoasJuridicas, controlador);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.PessoaFisica);

                tabelaPessoaFisica.DesagruparRegistros();
                tabelaPessoaFisica.AtualizarRegistros();
                tabelaPessoaFisica.AgruparRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa física: [{tela.PessoaFisica.Nome}] inserido com sucesso");
            }

        }

        public void EditarRegistro()
        {
            int id = tabelaPessoaFisica.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma pessoa física para poder editar!", "Edição de Pessoas Físicas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PessoaFisica pessoaFisicaSeleciada = controlador.SelecionarPorId(id);


            TelaPessoaFisicaForm tela = new TelaPessoaFisicaForm();

            tela.PessoaFisica = pessoaFisicaSeleciada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.PessoaFisica);

                tabelaPessoaFisica.DesagruparRegistros();
                tabelaPessoaFisica.AtualizarRegistros();
                tabelaPessoaFisica.AgruparRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa física: [{tela.PessoaFisica.Nome}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaPessoaFisica.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma pessoa física para poder excluir!", "Exclusão de Pessoa Física",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PessoaFisica pessoaFisicaSeleciada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a pessoa física: [{pessoaFisicaSeleciada.Nome}] ?",
                "Exclusão de Compromissos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool conseguiuExcluir = controlador.Excluir(id);

                if (!conseguiuExcluir)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape("O condutor está ligado a uma locação, impossível excluir.");
                    return;
                }

                tabelaPessoaFisica.DesagruparRegistros();
                tabelaPessoaFisica.AtualizarRegistros();
                tabelaPessoaFisica.AgruparRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa física: [{pessoaFisicaSeleciada.Nome}] removida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            tabelaPessoaFisica.AtualizarRegistros();

            return tabelaPessoaFisica;
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            AgrupamentoPessoaFisicaForm telaOrdemPessoaFisica = new AgrupamentoPessoaFisicaForm();

            if (telaOrdemPessoaFisica.ShowDialog() == DialogResult.OK)
            {
                tabelaPessoaFisica.AgruparRegistros(telaOrdemPessoaFisica.TipoOrdem);
            }
        }

        public void DesagruparRegistros()
        {
            tabelaPessoaFisica.DesagruparRegistros();
        }

        public void ExibirInformacoesDetalhadas()
        {
            throw new NotImplementedException();
        }
    }
}
