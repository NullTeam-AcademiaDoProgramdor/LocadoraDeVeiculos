using LocadoraDeVeiculos.Controladores.CupomModule;
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
        private readonly ControladorCupom controlador = null;
        private readonly TabelaCupomControl tabelaCupom = null;

        public OperacoesCupons(ControladorCupom controladorCupom)
        {
            this.controlador = controladorCupom;
            tabelaCupom = new TabelaCupomControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCupomForm tela = new TelaCupomForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Cupom);

                List<Cupom> cupons = controlador.SelecionarTodos();

                tabelaCupom.AtualizarRegistros(cupons);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionario [{tela.Cupom.Codigo}] inserido com sucesso");
            }
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
    }
}
