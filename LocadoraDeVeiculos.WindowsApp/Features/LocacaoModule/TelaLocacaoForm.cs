using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
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
        public TelaLocacaoForm()
        {
            controladorAutomovel = new ControladorAutomovel();
            controladorPessoaFisica = new ControladorPessoaFisica();

            InitializeComponent();

            CarregarAutomoveis(controladorAutomovel.SelecionarTodos());
            CarregarCondutores(controladorPessoaFisica.SelecionarTodos());
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Automovel automovel = (Automovel)cmbAutomovel.SelectedItem;
            PessoaFisica condutor = (PessoaFisica)cmbCondutor.SelectedItem;
            Funcionario funcionario = TelaPrincipalForm.Instancia.funcionarioConectado;
            DateTime dataSaida = dtpdataSaida.Value;
            DateTime dataDevolucaoEsperada = dtpdataDevolucaoEsperada.Value;
            int caucao = Convert.ToInt32(txtCaucao.Text);
            int kmInicial = Convert.ToInt32(txtKmInicial.Text);
            int planoSelecionado = Convert.ToInt32(cmbPlano.SelectedIndex);
            //inserindo

            locacao = new Locacao(condutor, automovel, funcionario, dataSaida, dataDevolucaoEsperada, caucao, kmInicial, planoSelecionado);

            string resultadoValidacao = locacao.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
