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
using LocadoraDeVeiculos.Servicos.PDFModule;
using LocadoraDeVeículos.Aplicacao.LocacaoModule;
using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;
using LocadoraDeVeículos.Aplicacao.CupomModule;

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    class OperacoesLocacao : ICadastravel
    {

        private readonly LocacaoAppService controlador = null;
        private readonly TabelaLocacaoControl tabelaLocacao = null;

        private AutomovelAppService controladorAutomovel;
        private PessoaFisicaAppService controladorCondutor;
        private TaxaEServicoAppService controladorTaxaEServico;
        private CupomAppService controladorCupom;

        public OperacoesLocacao(LocacaoAppService controlador,
                                AutomovelAppService controladorAutomovel,
                                PessoaFisicaAppService controladorCondutor,
                                TaxaEServicoAppService controladorTaxaEServico,
                                CupomAppService controladorCupom)
        {
            this.controlador = controlador;

            this.controladorAutomovel = controladorAutomovel;
            this.controladorCondutor = controladorCondutor;
            this.controladorCupom = controladorCupom;
            this.controladorTaxaEServico = controladorTaxaEServico;

            tabelaLocacao = new TabelaLocacaoControl();
        }

        public void InserirNovoRegistro()
        {

            TelaLocacaoForm tela = new TelaLocacaoForm(
                controladorCupom, 
                controladorAutomovel.SelecionarDisponiveis(), 
                controladorCondutor.SelecionarTodos(), 
                controladorTaxaEServico.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Locacao);

                tabelaLocacao.AtualizarRegistros(controlador.SelecionarTodos());

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.Automovel}] inserida com sucesso");
            }

        }

        public void EditarRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para poder editar!", "Edição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Locacao locacaoSelecionada = controlador.SelecionarPorId(id);


            TelaLocacaoForm tela = new TelaLocacaoForm(
                controladorCupom,
                controladorAutomovel.SelecionarDisponiveis(),
                controladorCondutor.SelecionarTodos(),
                controladorTaxaEServico.SelecionarTodos());

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Locacao);

                tabelaLocacao.AtualizarRegistros(controlador.SelecionarTodos());

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do automóvel: [{tela.Locacao.Automovel}] editada com sucesso");
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

        public void ExcluirRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma locação para poder excluir!", "Exclusão de Locação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Locacao locacaoSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a locação do automóvel: [{locacaoSelecionada.Automovel}] ?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                tabelaLocacao.AtualizarRegistros(controlador.SelecionarTodos());

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do automóvel: [{locacaoSelecionada.Automovel}] removida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            tabelaLocacao.AtualizarRegistros(controlador.SelecionarTodos());
            tabelaLocacao.SetOnClick(TelaPrincipalForm.Instancia.panelRegistros_Click);

            return tabelaLocacao;
        }

        public void ExibirInformacoesDetalhadas()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            FiltroLocacaoForm telaFiltro = new FiltroLocacaoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Locacao> locacoes = new List<Locacao>();
                string tipoLocacao = "";
                List<Locacao> todasLocacoes = controlador.SelecionarTodos();

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroLocacaoEnum.TodasLocacoes:
                        locacoes = todasLocacoes;
                        break;

                    case FiltroLocacaoEnum.LocacoesDevolvidas:
                        {
                            foreach (Locacao loc in todasLocacoes)
                            {
                                if (loc.DataDevolucao != null)
                                    locacoes.Add(loc);
                            }
                            tipoLocacao = "concluídas(s)";
                            break;
                        }

                    case FiltroLocacaoEnum.LocacoesNaoDevolvidas:
                        {
                            foreach (Locacao loc in todasLocacoes)
                            {
                                if (loc.DataDevolucao == null)
                                    locacoes.Add(loc);
                            }
                            tipoLocacao = "pendente(s)";
                            break;
                        }

                    default:
                        break;
                }

                tabelaLocacao.AtualizarRegistros(locacoes);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locações(s) {tipoLocacao}");
            }
        }

        public void DevolverRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para poder devolver!", "Devolução de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Locacao locacaoSelecionada = controlador.SelecionarPorId(id);

            TelaDevolucaoForm tela = new TelaDevolucaoForm(controladorCupom, controladorTaxaEServico.SelecionarTodos());

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Devolver(id, tela.Locacao, tela.CupomFoiUsado); 

                tabelaLocacao.AtualizarRegistros(controlador.SelecionarTodos());

                TelaPrincipalForm.Instancia.AtualizarRodape($"Devolução do automóvel: [{tela.Locacao.Automovel}] concluída com sucesso");
            }
        }

        public bool RegistroSelecionadoEstaDevolvido()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
                return false;

            Locacao locacaoSelecionada = controlador.SelecionarPorId(id);

            return locacaoSelecionada.DataDevolucao != null;
        }
    }
}
