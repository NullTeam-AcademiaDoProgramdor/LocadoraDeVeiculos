using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
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
    public partial class TelaLocacaoForm : Form
    {
        private Locacao locacao;
        private ControladorAutomovel controladorAutomovel;
        private ControladorPessoaFisica controladorPessoaFisica;
        private ControladorTaxasEServicos controladorTaxasEServicos;
        public TelaLocacaoForm()
        {
            controladorAutomovel = new ControladorAutomovel();
            controladorPessoaFisica = new ControladorPessoaFisica();
            controladorTaxasEServicos = new ControladorTaxasEServicos();

            InitializeComponent();

            CarregarAutomoveis(controladorAutomovel.SelecionarDisponiveis());
            CarregarCondutores(controladorPessoaFisica.SelecionarTodos());
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
                cmbAutomovel.SelectedItem = locacao.Automovel;
                cmbCondutor.SelectedItem = locacao.Condutor;
                cmbPlano.SelectedIndex = locacao.PlanoSelecionado;
                dtpdataSaida.Value = locacao.DataSaida;
                dtpdataDevolucaoEsperada.Value = locacao.DataDevolucaoEsperada;
                txtKmInicial.Text = locacao.KmAutomovelIncial.ToString();
                seletorTaxasEServicosControl1.TaxasEServicosSelecionados = locacao.TaxasEServicos;
            }
        }

        private void CarregarAutomoveis(List<Automovel> automoveis)
        {
            cmbAutomovel.Items.Clear();

            foreach (Automovel item in automoveis)
            {
                cmbAutomovel.Items.Add(item);
            }
        }

        private void CarregarCondutores(List<PessoaFisica> pessoaFisicas)
        {
            cmbCondutor.Items.Clear();

            foreach (PessoaFisica item in pessoaFisicas)
            {
                cmbCondutor.Items.Add(item);
            }
        }

        private void CarregarTaxasEServicos(List<TaxaEServico> taxaEServicos)
        {
            seletorTaxasEServicosControl1.TaxasEServicos = taxaEServicos.ToArray();
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            Automovel automovel = (Automovel)cmbAutomovel.SelectedItem;
            PessoaFisica condutor = (PessoaFisica)cmbCondutor.SelectedItem;
            Funcionario funcionario = TelaPrincipalForm.Instancia.funcionarioConectado;
            DateTime dataSaida = dtpdataSaida.Value;
            DateTime dataDevolucaoEsperada = dtpdataDevolucaoEsperada.Value;
            int caucao = 0;
            int kmInicial = 0;
            VerificarValoresNumericos(ref kmInicial, ref caucao);
            int planoSelecionado = Convert.ToInt32(cmbPlano.SelectedIndex);
            var taxasEServicos = seletorTaxasEServicosControl1.TaxasEServicosSelecionados;
            //inserindo

            locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, kmInicial, planoSelecionado, taxasEServicos);

            string resultadoValidacao = locacao.Validar();

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
            }
        }

        public void VerificarValoresNumericos(ref int kMInicial, ref int caucao)
        {
            try
            {
                kMInicial = Convert.ToInt32(txtKmInicial.Text);
            }
            catch (Exception)
            {
                kMInicial = 0;
            }
            try
            {
                caucao = Convert.ToInt32(txtCaucao.Text);
            }
            catch (Exception)
            {
                caucao = 0;
            }

        }
    }
}
