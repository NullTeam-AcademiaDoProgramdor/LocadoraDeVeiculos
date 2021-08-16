using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Shared
{
    public interface ICadastravel
    {
        void InserirNovoRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        UserControl ObterTabela();

        void FiltrarRegistros();

        void AgruparRegistros();

        void DesagruparRegistros();

        void ExibirInformacoesDetalhadas();
    }
}
