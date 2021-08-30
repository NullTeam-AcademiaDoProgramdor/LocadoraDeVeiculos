using LocadoraDeVeiculos.Controladores.CupomModule;
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.WindowsApp.Features.Relatorio;
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

namespace LocadoraDeVeiculos.WindowsApp.Features.LocacaoModule
{
    public partial class TelaDevolucaoForm : Form
    {

        private Locacao locacao;
        private ControladorTaxasEServicos controladorTaxasEServicos;
        private ControladorCupom controladorCupom;
        private object cupom;

        public TelaDevolucaoForm()
        {
            controladorCupom = new ControladorCupom();
            controladorTaxasEServicos = new ControladorTaxasEServicos();

            InitializeComponent();

            CarregarTaxasEServicos(controladorTaxasEServicos.SelecionarTodos());
        }

        public Locacao Locacao
        {
            get { return locacao; }

            set
            {
                locacao = value;
                txtId.Text = locacao.Id.ToString();
                txtCaucao.Text = locacao.Caucao.ToString();
                txtAutomovel.Text = locacao.Automovel.ToString();
                txtCondutor.Text = locacao.Condutor.ToString();
                txtPlano.Text = PlanoParaString(locacao.PlanoSelecionado);
                txtDataSaida.Text = locacao.DataSaida.ToString();
                txtDataDevEsperada.Text = locacao.DataDevolucaoEsperada.ToString();
                txtKmInicial.Text = locacao.KmAutomovelIncial.ToString();
                txtKmAtual.Text = locacao.KmAutomovelFinal.ToString();
                seletorTaxasEServicosControl1.TaxasEServicosSelecionados = locacao.TaxasEServicos;
                if (locacao.Cupom != null)
                    txtCupom.Text = locacao.Cupom.ToString();
            }
        }

        private void CarregarTaxasEServicos(List<TaxaEServico> taxaEServicos)
        {
            seletorTaxasEServicosControl1.TaxasEServicos = taxaEServicos.ToArray();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Automovel automovel = locacao.Automovel;
            PessoaFisica condutor = locacao.Condutor;
            Funcionario funcionario = TelaPrincipalForm.Instancia.funcionarioConectado;
            DateTime dataSaida = locacao.DataSaida;
            DateTime dataDevolucaoEsperada = locacao.DataDevolucaoEsperada;
            int caucao = locacao.Caucao;
            int kmInicial = locacao.KmAutomovelIncial;
            int planoSelecionado = locacao.PlanoSelecionado;
            int kmAutomovelFinal = 0;
            VerificarValoresNumericos(ref kmAutomovelFinal);
            int porcentagemFinalCombustivel = PegarPorcentagemFinal();
            DateTime dataDevolucao = DateTime.Today;
            var taxasEServicos = seletorTaxasEServicosControl1.TaxasEServicosSelecionados;
            var cupom = controladorCupom.SelecionarPorCodigo(txtCupom.Text);

            if (cupom != null && cupom.DataVencimento.CompareTo(DateTime.Now) < 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Cupom com data inválida");
                return;
            }
            //inserindo

            locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, kmInicial, planoSelecionado, kmAutomovelFinal, porcentagemFinalCombustivel, dataDevolucao, taxasEServicos, cupom);

            string resultadoValidacao = locacao.ValidarDevolucao();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
            else
            {
                TelaRelatorioLocação telaRelatorio = new TelaRelatorioLocação(locacao);
                telaRelatorio.ShowDialog();
                DialogResult = telaRelatorio.DialogResult;

                if (DialogResult == DialogResult.Cancel)
                    DialogResult = DialogResult.None;
            }
        }

        private int PegarPorcentagemFinal()
        {
            var controls = this.Controls;

            foreach (var item in controls)
            {
                if (item is RadioButton && (item as RadioButton).Checked == true)
                {
                    return Convert.ToInt32((item as RadioButton).AccessibleDescription);
                }
            }

            return 0;
        }

        public void VerificarValoresNumericos(ref int kmFinal)
        {
            try
            {
                kmFinal = Convert.ToInt32(txtKmAtual.Text);
                return;
            }
            catch (Exception)
            {
                kmFinal = 0;
            }

        }

        private string PlanoParaString(int plano)
        {
            switch (plano)
            {
                case 0:
                    return "Plano diario";
                case 1:
                    return "Plano Km Controlado";
                case 2:
                    return "Plano Livre";

                default:
                    return "";
            }
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            Cupom cupom = controladorCupom.SelecionarPorCodigo(txtCupom.Text);

            if (cupom == null)
                TelaPrincipalForm.Instancia.AtualizarRodape("Cupom inválido");

            else
                TelaPrincipalForm.Instancia.AtualizarRodape("Cupom válido");
        }
    }
}
