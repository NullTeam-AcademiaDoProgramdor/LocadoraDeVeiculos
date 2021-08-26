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

            cmbPlano.SelectedIndex = 0;
            dtpdataSaida.Value = DateTime.Now;
            dtpdataDevolucaoEsperada.Value = DateTime.Now.AddDays(1);

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

                cmbAutomovel.Items.Add(Locacao.Automovel);
                cmbAutomovel.SelectedItem = Locacao.Automovel;

                cmbCondutor.SelectedItem = locacao.Condutor;
                cmbPlano.SelectedIndex = locacao.PlanoSelecionado;
                dtpdataSaida.Value = locacao.DataSaida;
                dtpdataDevolucaoEsperada.Value = locacao.DataDevolucaoEsperada;                
                seletorTaxasEServicosControl1.TaxasEServicosSelecionados = locacao.TaxasEServicos;

                cmbCondutor.Enabled = false;
                cmbAutomovel.Enabled = false;
                cmbPlano.Enabled = false;
                txtCaucao.Enabled = false;               
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
            VerificarValoresNumericos(ref caucao);
            int planoSelecionado = Convert.ToInt32(cmbPlano.SelectedIndex);
            var taxasEServicos = seletorTaxasEServicosControl1.TaxasEServicosSelecionados;
            //inserindo

            locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, planoSelecionado, taxasEServicos);

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

                if (DialogResult == DialogResult.Cancel)
                    DialogResult = DialogResult.None;
            }
        }

        public void VerificarValoresNumericos(ref int caucao)
        {           
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
