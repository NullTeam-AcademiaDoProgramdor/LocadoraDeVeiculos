using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
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
        public TelaDevolucaoForm()
        {
            InitializeComponent();

            controladorTaxasEServicos = new ControladorTaxasEServicos();
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
                txtPlano.Text = locacao.PlanoSelecionado.ToString();
                txtDataSaida.Text = locacao.DataSaida.ToString();
                txtDataDevEsperada.Text = locacao.DataDevolucaoEsperada.ToString();
                txtKmInicial.Text = locacao.KmAutomovelIncial.ToString();
                txtKmAtual.Text = locacao.KmAutomovelFinal.ToString();
                seletorTaxasEServicosControl1.TaxasEServicosSelecionados = locacao.TaxasEServicos;
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
            int planoSelecionado =locacao.PlanoSelecionado;
            int kmAutomovelFinal = Convert.ToInt32(txtKmAtual.Text);
            int porcentagemFinalCombustivel = PegarPorcentagemFinal();
            DateTime dataDevolucao = DateTime.Today;
            var taxasEServicos = seletorTaxasEServicosControl1.TaxasEServicosSelecionados;
            //inserindo

            locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, kmInicial, planoSelecionado, kmAutomovelFinal, porcentagemFinalCombustivel, dataDevolucao, taxasEServicos);

            string resultadoValidacao = locacao.ValidarDevolucao();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
                
                DialogResult = DialogResult.None;
            }

            TelaRelatorioLocação telaRelatorio = new TelaRelatorioLocação(locacao);
            telaRelatorio.ShowDialog();
            DialogResult = telaRelatorio.DialogResult;
        }

        private int PegarPorcentagemFinal()
        {
            var controls = this.Controls;

            foreach (var item in controls)
            {
                if(item is RadioButton && (item as RadioButton).Checked == true)
                {
                    return Convert.ToInt32((item as RadioButton).AccessibleDescription);
                }
            }

            return 0;
        }

    }
}
