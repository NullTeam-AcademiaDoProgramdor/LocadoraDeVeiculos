using LocadoraDeVeículos.Aplicacao.CupomModule;
using LocadoraDeVeículos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Controladores.CupomModule;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Cupons
{
    public class OperacoesCupons : ICadastravel
    {
        private readonly CupomAppService controlador = null;
        private readonly ParceiroAppService controladorParceiro = null;
        private readonly TabelaCupomControl tabelaCupom = null;

        public OperacoesCupons(CupomAppService controladorCupom,
                               ParceiroAppService controladorParceiro)
        {
            this.controlador = controladorCupom;
            this.controladorParceiro = controladorParceiro;
            tabelaCupom = new TabelaCupomControl();
        }

        public void InserirNovoRegistro()
        {
            if (!PodeCadastrar())
                return;

            TelaCupomForm tela = new TelaCupomForm(
                controlador.SelecionarValidos(), 
                controladorParceiro.SelecionarTodos());

            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultadoValidacao = controlador.InserirNovo(tela.Cupom);

                if (resultadoValidacao != "ESTA_VALIDO")
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao);
                else
                {
                    List<Cupom> cupons = controlador.SelecionarTodos();

                    tabelaCupom.AtualizarRegistros(cupons);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom [{tela.Cupom.Codigo}] inserido com sucesso");
                }
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaCupom.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Cupom para poder editar!", "Edição de Cupons",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cupom cupomSelecionado = controlador.SelecionarPorId(id);

            TelaCupomForm tela = new TelaCupomForm(
                controlador.SelecionarValidos(), 
                controladorParceiro.SelecionarTodos());

            tela.Cupom = cupomSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Cupom);

                List<Cupom> cupons = controlador.SelecionarTodos();

                tabelaCupom.AtualizarRegistros(cupons);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom [{tela.Cupom.Codigo}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaCupom.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cupom para poder excluir!", "Exclusão de cupoms",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cupom cupomSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o cupom: [{cupomSelecionado.Codigo}] ?",
                "Exclusão de de cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool conseguiuExcluir = controlador.Excluir(id);

                if (conseguiuExcluir == false)
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Não foi possível excluir o Cupom [{cupomSelecionado.Codigo}] " +
                        $"por estar vinculado à uma locação.");
                    return;
                }

                List<Cupom> cupons = controlador.SelecionarTodos();

                tabelaCupom.AtualizarRegistros(cupons);

                TelaPrincipalForm.Instancia.AtualizarRodape($"cupom: [{cupomSelecionado.Codigo}] removido com sucesso");
            }
        }

        public void ExibirInformacoesDetalhadas()
        {
            throw new NotImplementedException();
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
            List<Cupom> cupons = controlador.SelecionarTodos();

            tabelaCupom.AtualizarRegistros(cupons);

            return tabelaCupom;
        }
        private bool PodeCadastrar()
        {
            if (controladorParceiro.SelecionarTodos().Count > 0)
                return true;
            else
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre um parceiro para poder cadastrar um cupom!");

            return false;
        }
    }
}
