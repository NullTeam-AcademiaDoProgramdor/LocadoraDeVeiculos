using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Infra.Configuracoes;

namespace LocadoraDeVeiculos.Dominio.RelatorioModule
{
    public class Relatorio
    {
        public Locacao locacao;
        public Relatorio(Locacao locacao)
        {
            this.locacao = locacao;
        }

        public string Plano
        {
            get
            {
                switch (locacao.PlanoSelecionado)
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
        }

        public int DiasAlugados
        {
            get
            {
                if (LocacaoEstaDevolvida())
                {
                    return ((DateTime)locacao.DataDevolucao - locacao.DataSaida).Days + 1;
                }
                else
                {
                    return (locacao.DataDevolucaoEsperada - locacao.DataSaida).Days + 1;
                }
            }
        }

        public int? KmsAlugados
        {
            get
            {
                if (LocacaoEstaDevolvida())
                {
                    return locacao.KmAutomovelFinal - locacao.Automovel.KmRegistrada;
                }
                else
                {
                    return null;
                }
            }
        }

        public double TaxaDiariaTotal
        {
            get
            {
                double precoDia = PegarPrecoDia();

                return DiasAlugados * precoDia;
            }
        }

        public double? TaxaKmTotal
        {
            get
            {
                if (locacao.PlanoSelecionado != 0 || !LocacaoEstaDevolvida())
                    return null;

                return KmsAlugados * locacao.Automovel.Grupo.PlanoDiario.PrecoKm;
            }
        }

        public double? TaxaKmExtrapoladadaTotal
        {
            get
            {
                if (locacao.PlanoSelecionado != 1 || !LocacaoEstaDevolvida())
                    return null;

                double kmExtrapolados = 0;
                double kmsPermitidos = (locacao.Automovel.Grupo.PlanoKmControlado.KmDisponiveis * DiasAlugados);

                if ((double)KmsAlugados > kmsPermitidos)
                    kmExtrapolados = (double)KmsAlugados - kmsPermitidos;

                return kmExtrapolados * locacao.Automovel.Grupo.PlanoKmControlado.PrecoKmExtrapolado;
            }
        }

        public double SubTotalPlanos
        {
            get
            {
                double subtotal = TaxaDiariaTotal;

                if (TaxaKmTotal != null)
                    subtotal += (double)TaxaKmTotal;

                if (TaxaKmExtrapoladadaTotal != null)
                    subtotal += (double)TaxaKmExtrapoladadaTotal;

                return subtotal;
            }
        }

        public double SubTotalAdicionaisDia
        {
            get
            {
                double subtotal = locacao.TaxasEServicos
                    .Where(t => !t.EhFixo)
                    .Aggregate(0d, (acc, t) => acc + (t.Preco * DiasAlugados));

                return subtotal;
            }
        }

        public double SubTotalAdicionaisFixos
        {
            get
            {
                double subtotal = locacao.TaxasEServicos
                    .Where(t => t.EhFixo)
                    .Aggregate(0d, (acc, t) => acc + t.Preco);

                return subtotal;
            }
        }

        public string TipoCombustivel
        {
            get
            {
                return locacao.Automovel.TipoCombustivel.ToString();
            }
        }

        public double? LitrosParaEncher
        {
            get
            {
                if (LocacaoEstaDevolvida())
                {
                    return locacao.Automovel.CapacidadeTanque -
                        ((double)locacao.PorcentagemFinalCombustivel / 100 *
                        locacao.Automovel.CapacidadeTanque);
                }
                else
                    return null;
            }
        }

        public double? ValorParaAbastecer
        {
            get
            {
                if (LocacaoEstaDevolvida())
                {
                    return (double)LitrosParaEncher * PegarValorCombustivel();
                }
                else
                    return null;
            }
        }

        private double TotalAPagarSemCupom
        {
            get
            {
                double total = SubTotalPlanos + SubTotalAdicionaisFixos + SubTotalAdicionaisDia;

                if (ValorParaAbastecer != null)
                    total += (double)ValorParaAbastecer;

                return total;

            }
        }

        public bool CupomEstaValido
        {
            get
            {
                if (locacao.Cupom == null)
                    return false;

                else if (TotalAPagarSemCupom < locacao.Cupom.ValorMinimo)
                    return false;

                return true;
            }
        }

        public double? ValorDecontadoCupom
        {
            get
            {
                if (!CupomEstaValido)
                    return null;

                if (locacao.Cupom.Tipo == "Porcentagem")
                    return TotalAPagarSemCupom * (locacao.Cupom.Valor / 100);
                else
                    return locacao.Cupom.Valor;
            }
        }

        public double TotalAPagar
        {
            get
            {
                double total = TotalAPagarSemCupom;

                if (ValorDecontadoCupom != null)
                    total -= (double)ValorDecontadoCupom;

                return total;
            }
        }

        private double PegarValorCombustivel()
        {
            switch (locacao.Automovel.TipoCombustivel)
            {
                case TipoCombustivelEnum.Gasolina:
                    return Configuracao.PrecoGasolina;
                case TipoCombustivelEnum.Gas:
                    return Configuracao.PrecoGas;
                case TipoCombustivelEnum.Diesel:
                    return Configuracao.PrecoDiesel;
                case TipoCombustivelEnum.Alcool:
                    return Configuracao.PrecoAlcool;
                default:
                    return 0;
            }
        }

        private bool LocacaoEstaDevolvida()
        {
            return locacao.DataDevolucao != null;
        }

        private double PegarPrecoDia()
        {
            switch (locacao.PlanoSelecionado)
            {
                case 0:
                    return locacao.Automovel.Grupo.PlanoDiario.PrecoDia;
                case 1:
                    return locacao.Automovel.Grupo.PlanoKmControlado.PrecoDia;
                case 2:
                    return locacao.Automovel.Grupo.PlanoKmLivre.PrecoDia;
                default:
                    return 0;
            }
        }

    }
}