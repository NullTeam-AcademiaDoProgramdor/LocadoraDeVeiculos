using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Controladores.Shared;
using System.Drawing;
using System.IO;
using System.Data;
using System.Collections;

namespace LocadoraDeVeiculos.Controladores.AutomovelModule
{
    public class ControladorFotos
    {
        internal class EntidadeImage
        {
            public int id;
            public Image foto;
            public int automovel;

            public EntidadeImage(int id, Image foto, int automovel)
            {
                this.id = id;
                this.foto = foto;
                this.automovel = automovel;
            }
        }

        public const string sqlInserirImagens =
            @"INSERT INTO [FotoAutomovel]
            (
	            [foto],
	            [automovel]
            ) 
            VALUES
            (
	            @foto,
	            @automovel
            );";

        public const string sqlBuscarImagens =
            @"SELECT
	            [id],
	            [foto],
	            [automovel]
            FROM
	            [FotoAutomovel]
            WHERE
	            [automovel] = @automovel;";

        public const string sqlExcluirImagens =
            @"DELETE FROM [FotoAutomovel]
                WHERE [id] = @id;";

        private void Inserir(Image[] imagens, int automovelId)
        {
            foreach (Image foto in imagens)
            {
                Db.Insert(sqlInserirImagens, ObtemParametrosFoto(foto, automovelId));
            }
        }

        public bool Excluir(int id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"id", id}
            };

            try
            {
                Db.Delete(sqlExcluirImagens, parametros);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private List<EntidadeImage> BuscarEntidades(int automovelId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"automovel", automovelId }
            };

            return Db.GetAll(sqlBuscarImagens, ConverterEmEntidadeImage, parametros);
        }

        public Image[] Buscar(int automovelId)
        {
            return BuscarEntidades(automovelId).Select(e => e.foto).ToArray();
        }

        public void Modificar(Image[] imagens, int automovelId)
        {
            List<EntidadeImage> fotosJaInseridas = BuscarEntidades(automovelId);

            Dictionary<EntidadeImage, char> tabelaDeAlteracoes =
                CriarTabelaDeAlteracoes(imagens, automovelId, fotosJaInseridas);

            foreach (var alteracao in tabelaDeAlteracoes)
            {
                if (alteracao.Value == 'D')
                    this.Excluir(alteracao.Key.id);

                else if (alteracao.Value == 'A')
                    this.Inserir(
                        new Image[] { alteracao.Key.foto },
                        alteracao.Key.automovel);
            }
        }

        private Dictionary<EntidadeImage, char> CriarTabelaDeAlteracoes(Image[] imagens, int automovelId, List<EntidadeImage> fotosJaInseridas)
        {
            /*
            D = Deletar
            M = Manter
            A = Adicionar
            */
            Dictionary<EntidadeImage, char> tabelaDeAlteracoes
                = new Dictionary<EntidadeImage, char>();

            Dictionary<string, EntidadeImage> hashsFotos = new Dictionary<string, EntidadeImage>();

            foreach (EntidadeImage fotoJaInserida in fotosJaInseridas)
            {
                tabelaDeAlteracoes.Add(fotoJaInserida, 'D');
                hashsFotos.Add(GetImageHash(fotoJaInserida.foto), fotoJaInserida);
            }

            foreach (Image novaFoto in imagens)
            {
                string hash = GetImageHash(novaFoto);

                if (hashsFotos.ContainsKey(hash))
                    tabelaDeAlteracoes[hashsFotos[hash]] = 'M';
                else
                {
                    EntidadeImage tempEntidade = new EntidadeImage(0, novaFoto, automovelId);
                    tabelaDeAlteracoes.Add(tempEntidade, 'A');
                    hashsFotos.Add(hash, tempEntidade);
                }
            }

            return tabelaDeAlteracoes;
        }

        private Dictionary<string, object> ObtemParametrosFoto(Image foto, int automovelId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("foto", ImageToByteArray(foto));
            parametros.Add("automovel", automovelId);

            return parametros;
        }

        private EntidadeImage ConverterEmEntidadeImage(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            int automovel = Convert.ToInt32(reader["automovel"]);
            Image foto = ByteArrayToImage((byte[])reader["foto"]);

            return new EntidadeImage(id, foto, automovel);
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

        // Diminui a imagem para ter 32x32 pixel, converte ela para preto e branco e retorna uma string dos pixels
        // https://stackoverflow.com/questions/35151067/algorithm-to-compare-two-images-in-c-sharp
        private string GetImageHash(Image image)
        {
            List<bool> result = new List<bool>();

            Bitmap bmpMin = new Bitmap(image, new Size(32, 32));

            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    result.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }

            BitArray arr = new BitArray(result.ToArray());
            byte[] data = new byte[128];
            arr.CopyTo(data, 0);

            string hash = BitConverter.ToString(data);

            return hash;
        }


    }
}