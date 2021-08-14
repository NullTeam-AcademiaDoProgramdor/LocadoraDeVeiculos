using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.PessoasFisicas
{
    public class OperacoesPessoaFisica
    {
        private readonly ControladorPessoaFisica controlador = null;
        private readonly ControladorPessoaJuridica controladorPJuridica = null;
        private readonly TabelaPessoaFisicaControl tabelaPessoaFisica = null;

        public OperacoesPessoaFisica(ControladorPessoaFisica ctrl)
        {
            controlador = ctrl;
            tabelaPessoaFisica = new TabelaPessoaFisicaControl();
            controladorPJuridica = new ControladorPessoaJuridica();
        }

        public void InserirNovoRegistro()
        {
            var pessoasJuridicas = controladorPJuridica.SelecionarTodos();

            TelaPessoaFisicaForm tela = new TelaPessoaFisicaForm(pessoasJuridicas, controlador);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.PessoaFisica);

                tabelaPessoaFisica.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Pessoa física: [{tela.PessoaFisica.Nome}] inserido com sucesso");
            }

        }
    }
}
