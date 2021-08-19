using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using System.Windows.Forms;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorLocacao controlador = null;
        public OperacoesLocacao(ControladorLocacao controlador)
        {

        }

        public void InserirNovoRegistro()
        {
            var locacoes = controlador.SelecionarTodos();

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
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExibirInformacoesDetalhadas()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            throw new NotImplementedException();
        }
    }
}
