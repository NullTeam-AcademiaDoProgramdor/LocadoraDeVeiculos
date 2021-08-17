using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Controladores.Shared;
using System.Drawing;
using System.IO;
using System.Data;

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

     

        public void Inserir(Image[] imagens, int automovelId)
        {
            foreach(Image foto in imagens)
            {
                Db.Insert(sqlInserirImagens, ObtemParametrosFoto(foto, automovelId));
            }
        }

        public Image[] Buscar(int automovelId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"automovel", automovelId }
            };

            List<EntidadeImage> entidadeImages = Db.GetAll(sqlBuscarImagens, ConverterEmEntidadeImage, parametros);

            return entidadeImages.Select(e => e.foto).ToArray();
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
    }
}
