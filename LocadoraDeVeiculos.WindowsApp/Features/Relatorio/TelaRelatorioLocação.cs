using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Relatorio
{
    public partial class TelaRelatorioLocação : Form
    {
        public TelaRelatorioLocação()
        {
            InitializeComponent();
        }

        public TelaRelatorioLocação(Locacao locacao)
        {
            InitializeComponent();

            if (locacao.DataDevolucao == null)
            {
                CalcularValoresParcial(locacao);
            } else
            {
                CalcularValoresFinal(locacao);
            }
        }

        private void CalcularValoresParcial(Locacao locacao)
        {
            labelTipoPlano.Text = PegarTipoPlano(locacao.PlanoSelecionado);
            labelQuantDias.Text = (locacao.DataDevolucaoEsperada - locacao.DataSaida)
                .Days.ToString();
            labelQuantKmRodados.Text = "Indisponivel";

            double valorPlano = SetarValoresPlanosParcial(locacao.PlanoSelecionado, locacao);

            double valorTaxas = SetarValoresTaxas(locacao.TaxasEServicos, locacao);

            labelValorTotalAPagar.Text = "R$" + (valorPlano + valorTaxas);

        }

        private void CalcularValoresFinal(Locacao locacao)
        {
            labelTipoPlano.Text = PegarTipoPlano(locacao.PlanoSelecionado);
            labelQuantDias.Text = (locacao.DataDevolucaoEsperada - locacao.DataSaida)
                .Days.ToString();
            labelQuantKmRodados.Text = (locacao.KmAutomovelFinal - locacao.KmAutomovelIncial).ToString();

            double valorPlano = SetarValoresPlanosFinais(locacao.PlanoSelecionado, locacao);

            double valorTaxas = SetarValoresTaxas(locacao.TaxasEServicos, locacao);

            labelValorTotalAPagar.Text = "R$" + (valorPlano + valorTaxas);
        }

        private string PegarTipoPlano(int tipo)
        {
            switch (tipo)
            {
                case 0:
                    return "Plano Km Diario";
                case 1:
                    return "Plano Km Controlado";
                case 2:
                    return "Plano Km Livre";
                default:
                    return "Plano invalido";
            }
        }

        private double SetarValoresTaxas(TaxaEServico[] taxas, Locacao locacao)
        {
            int dias = (locacao.DataDevolucaoEsperada - locacao.DataSaida).Days;

            double totalFixos = 0;
            double totalPorDia = 0;

            listBoxAdicionaisFixos.Items.Clear();
            listBoxAdicionaisPorDia.Items.Clear();

            foreach(TaxaEServico taxaEServico in taxas)
            {
                if (taxaEServico.EhFixo)
                {
                    totalFixos += taxaEServico.Preco;
                    listBoxAdicionaisFixos.Items.Add(taxaEServico.Nome + $" R${taxaEServico.Preco}");
                } else
                {
                    totalPorDia += taxaEServico.Preco;
                    listBoxAdicionaisPorDia.Items.Add(taxaEServico.Nome + $" R${taxaEServico.Preco}");
                }
            }

            labelValorSubTotalDia.Text = "R$" + totalPorDia * dias;
            labelValorSubTotalFixo.Text = "R$" + totalFixos;

            return (totalPorDia * dias) + totalFixos;
        }

        private double SetarValoresPlanosParcial(int plano, Locacao locacao)
        {
            int dias = (locacao.DataDevolucaoEsperada - locacao.DataSaida).Days;
            
            if (plano == 0)
            {
                double valorTaxaDiario = dias * locacao.Automovel.Grupo.PlanoDiario.PrecoDia;
                labelValorTaxaDiaria.Text = "R$" + valorTaxaDiario;
                labelValorTaxaKm.Text = "Indisponivel";
                labelTaxaKmExtrapolado.Visible = labelValorTaxaKmExtrapolado.Visible = false;
                labelValorSubTotal.Text = "R$" + valorTaxaDiario + " + Taxa km";
                return valorTaxaDiario;
            }

            if (plano == 1)
            {
                double valorTaxaDiario = dias * locacao.Automovel.Grupo.PlanoKmControlado.PrecoDia;
                labelValorTaxaDiaria.Text = "R$" + valorTaxaDiario;
                labelTaxaKm.Visible = labelValorTaxaKm.Visible = false;
                labelValorTaxaKmExtrapolado.Text = "Indisponivel";
                labelValorSubTotal.Text = "R$" + valorTaxaDiario + " + Taxa km extrapolado";
                return valorTaxaDiario;
            }

            if (plano == 2)
            {
                double valorTaxaDiario = dias * locacao.Automovel.Grupo.PlanoKmLivre.PrecoDia;
                labelValorTaxaDiaria.Text = "R$" + valorTaxaDiario;
                labelTaxaKm.Visible = labelValorTaxaKm.Visible = false;
                labelTaxaKmExtrapolado.Visible = labelValorTaxaKmExtrapolado.Visible = false;
                labelValorSubTotal.Text = "R$" + valorTaxaDiario;
                return valorTaxaDiario;
            }

            return 0;
        }

        private double SetarValoresPlanosFinais(int plano, Locacao locacao)
        {
            int dias = (locacao.DataDevolucaoEsperada - locacao.DataSaida).Days;


            if (plano == 0)
            {
                double valorTaxaDiario = dias * locacao.Automovel.Grupo.PlanoDiario.PrecoDia;
                double kms = (double)locacao.KmAutomovelFinal - locacao.KmAutomovelIncial;
                double valorKms = kms * locacao.Automovel.Grupo.PlanoDiario.PrecoKm;

                labelValorTaxaDiaria.Text = "R$" + valorTaxaDiario;
                labelValorTaxaKm.Text = "R$" + valorKms;
                labelTaxaKmExtrapolado.Visible = labelValorTaxaKmExtrapolado.Visible = false;
                labelValorSubTotal.Text = "R$" + valorTaxaDiario + valorKms;
                return valorTaxaDiario + valorKms;
            }

            if (plano == 1)
            {
                double valorTaxaDiario = dias * locacao.Automovel.Grupo.PlanoKmControlado.PrecoDia;
                double kmsTotais = (double)locacao.KmAutomovelFinal - locacao.KmAutomovelIncial;
                double kmExtrapolados = 0;

                if (kmsTotais > locacao.Automovel.Grupo.PlanoKmControlado.KmDisponiveis)
                    kmExtrapolados = kmsTotais - locacao.Automovel.Grupo.PlanoKmControlado.KmDisponiveis;

                double valorKmExtrapoldo = kmExtrapolados * locacao.Automovel.Grupo.PlanoKmControlado.PrecoKmExtrapolado;

                labelValorTaxaDiaria.Text = "R$" + valorTaxaDiario;
                labelTaxaKm.Visible = labelValorTaxaKm.Visible = false;
                labelValorTaxaKmExtrapolado.Text = "R$" + valorKmExtrapoldo;
                labelValorSubTotal.Text = "R$" + valorTaxaDiario + valorKmExtrapoldo;
                return valorTaxaDiario + valorKmExtrapoldo;
            }

            if (plano == 2)
            {
                double valorTaxaDiario = dias * locacao.Automovel.Grupo.PlanoKmLivre.PrecoDia;
                labelValorTaxaDiaria.Text = "R$" + valorTaxaDiario;
                labelTaxaKm.Visible = labelValorTaxaKm.Visible = false;
                labelTaxaKmExtrapolado.Visible = labelValorTaxaKmExtrapolado.Visible = false;
                labelValorSubTotal.Text = "R$" + valorTaxaDiario;
                return valorTaxaDiario;
            }

            return 0;
        }
    }
}
