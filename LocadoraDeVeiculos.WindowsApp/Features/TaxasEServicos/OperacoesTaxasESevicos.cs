using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using System.IO;
using System.Windows.Forms;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.TaxasEServicos
{
    class OperacoesTaxasESevicos : ICadastravel
    {
        private readonly TaxaEServicoAppService controlador = null;
        private readonly TabelaTaxasEServicosControl tabelaTaxasEServicos = null;

        public OperacoesTaxasESevicos(TaxaEServicoAppService controlador)
        {
            this.controlador = controlador;
            tabelaTaxasEServicos = new TabelaTaxasEServicosControl();
        }
        public void InserirNovoRegistro()
        {
            TelaTaxasEServicosForm tela = new TelaTaxasEServicosForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.TaxasEServicos);

                List<TaxaEServico> taxas = controlador.SelecionarTodos();

                tabelaTaxasEServicos.AtualizarRegistros(taxas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa/Serviço [{tela.TaxasEServicos.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaTaxasEServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Taxa/Serviço para poder editar!", "Edição de Taxas e Serviços",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TaxaEServico taxaSelecionada = controlador.SelecionarPorId(id);

            TelaTaxasEServicosForm tela = new TelaTaxasEServicosForm();

            tela.TaxasEServicos = taxaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.TaxasEServicos);

                List<TaxaEServico> taxas = controlador.SelecionarTodos();

                tabelaTaxasEServicos.AtualizarRegistros(taxas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa/Serviço [{tela.TaxasEServicos.Nome}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaTaxasEServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Taxa ou Serviço para poder excluir!", "Exclusão de Taxas e Serviços",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TaxaEServico taxaSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a taxa/serviço: [{taxaSelecionada.Nome}] ?",
                "Exclusão de Taxas e Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<TaxaEServico> taxas = controlador.SelecionarTodos();

                tabelaTaxasEServicos.AtualizarRegistros(taxas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa/Serviço: [{taxaSelecionada.Nome}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }


        public UserControl ObterTabela()
        {
            List<TaxaEServico> taxas = controlador.SelecionarTodos();

            tabelaTaxasEServicos.AtualizarRegistros(taxas);

            return tabelaTaxasEServicos;
        }

        public void ExibirInformacoesDetalhadas()
        {
            throw new NotImplementedException();
        }
    }
}
