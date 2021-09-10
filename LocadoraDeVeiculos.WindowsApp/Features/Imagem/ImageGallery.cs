using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsApp.Features.Imagem
{
    public partial class ImageGallery : UserControl
    {
        private int indexAtual = 0;

        private List<Image> images;

        private bool permitirAdicao = true;

        private bool permitirRemocao = true;

        private bool mostrarContador = true;

        private uint limiteImagens = 0;

        [Description("Lista de imagens que serão exibidas na galeria"),
            Category("Data")]
        public List<Image> Images
        {
            get => images;
            set
            {
                images = value;
                AtualizarImagemExibida();
            }
        }

        [Description("Permite que o usuario adicione a geleria. " +
            "Ao clicar no botão \"+\" abrirá-se uma janela para selecionar a imagem"),
            Category("Behavior")]
        public bool PermitirAdicao
        {
            get => permitirAdicao;
            set
            {
                permitirAdicao = value;
                OrganizarBotoesDeControle();
            }
        }

        [Description("Permite que o usuario exclua uma imagem da galeria. " +
            "Ao clicar no botão de \"-\" será apresentado uma mensagem confirmando a remoção da imagem"),
            Category("Behavior")]
        public bool PermitirRemocao
        {
            get => permitirRemocao;
            set
            {
                permitirRemocao = value;
                OrganizarBotoesDeControle();
            }
        }

        [Description("Mostra um contador, dizendo em qual pagina você está e quantas tem"),
            Category("Appearance")]
        public bool MostrarContador
        {
            get => mostrarContador;
            set
            {
                mostrarContador = value;
                labelContador.Visible = value;
            }
        }

        [Description("Permite limitar quantas imagens poderão ser inseridas. " +
            "Coloque 0 para deixar sem limite"),
            Category("Behavior")]
        public uint LimiteImagens
        {
            get => limiteImagens;
            set
            {
                limiteImagens = value;
                AtualizarEnableBotoesControle();
            }
        }


        public ImageGallery()
        {
            InitializeComponent();

            btnProximaImage.Enabled = false;
            btnAnteriorImage.Enabled = false;

            images = new List<Image>();
        }

        public void AddImages(params Image[] images)
        {
            this.images.AddRange(images);
            AtualizarImagemExibida();
        }

        private void AtualizarImagemExibida()
        {
            if (images.Count == 0)
                pictureBox.Image = null;
            else
                pictureBox.Image = images[indexAtual];

            AtualizarEnableBotoesControle();
            AtualizarContador();
        }

        private void AtualizarEnableBotoesControle()
        {
            if (images.Count > 1)
            {
                btnProximaImage.Enabled = true;
                btnAnteriorImage.Enabled = true;
            }
            else
            {
                btnProximaImage.Enabled = false;
                btnAnteriorImage.Enabled = false;
            }

            if (LimiteImagens != 0 && images.Count >= LimiteImagens)
                btnAdicionar.Enabled = false;
            else
                btnAdicionar.Enabled = true;


            if (images.Count == 0)
                btnRemover.Enabled = false;
            else
                btnRemover.Enabled = true;
        }

        private void AtualizarContador()
        {
            if (images.Count == 0)
                labelContador.Text = "Sem imagens";
            else
                labelContador.Text = $"{indexAtual + 1}/{images.Count}";
        }

        private int TransfomarParaUmIndexValido(int novoIndex)
        {
            return (novoIndex + images.Count) % images.Count;
        }

        private void OrganizarBotoesDeControle()
        {
            if (!PermitirAdicao && !PermitirRemocao)
            {
                ButtonsTableLayoutPanel.Controls.Clear();
                ButtonsTableLayoutPanel.ColumnCount = 2;

                ButtonsTableLayoutPanel.Controls.Add(btnAnteriorImage, 0, 0);
                ButtonsTableLayoutPanel.Controls.Add(btnProximaImage, 1, 0);
                return;
            }

            // PermitirAdicao XOR PermitirRemocao
            if (PermitirAdicao ^ PermitirRemocao)
            {
                Control controlAtivo = (PermitirAdicao) ? btnAdicionar : btnRemover;

                ButtonsTableLayoutPanel.Controls.Clear();
                ButtonsTableLayoutPanel.ColumnCount = 3;

                ButtonsTableLayoutPanel.Controls.Add(btnAnteriorImage, 0, 0);
                ButtonsTableLayoutPanel.Controls.Add(controlAtivo, 1, 0);
                ButtonsTableLayoutPanel.Controls.Add(btnProximaImage, 2, 0);
                return;
            }

            ButtonsTableLayoutPanel.Controls.Clear();
            ButtonsTableLayoutPanel.ColumnCount = 4;

            ButtonsTableLayoutPanel.Controls.Add(btnAnteriorImage, 0, 0);
            ButtonsTableLayoutPanel.Controls.Add(btnRemover, 1, 0);
            ButtonsTableLayoutPanel.Controls.Add(btnAdicionar, 2, 0);
            ButtonsTableLayoutPanel.Controls.Add(btnProximaImage, 3, 0);
        }

        private void btnProximaImage_Click(object sender, EventArgs e)
        {
            indexAtual = TransfomarParaUmIndexValido(indexAtual + 1);
            AtualizarImagemExibida();
        }

        private void btnAnteriorImage_Click(object sender, EventArgs e)
        {
            indexAtual = TransfomarParaUmIndexValido(indexAtual - 1);
            AtualizarImagemExibida();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSelector = new OpenFileDialog();

            fileSelector.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                Image novaImagem = new Bitmap(fileSelector.FileName);
                this.AddImages(novaImagem);

                indexAtual = images.Count - 1;
                AtualizarImagemExibida();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja remover esta imagem?",
                "Galeria de Imagem",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                images.RemoveAt(indexAtual);

                if (images.Count > 0)
                    indexAtual = TransfomarParaUmIndexValido(indexAtual - 1);

                AtualizarImagemExibida();
            }
        }
    }
}
