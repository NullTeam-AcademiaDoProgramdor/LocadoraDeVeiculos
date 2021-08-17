using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Controladores.Shared;
using System.Drawing;

namespace LocadoraDeVeiculos.Controladores.AutomovelModule
{
    public class ControladorFotos
    {
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

        public void Inserir(Image[] imagens, int automovelId)
        {
            foreach(Image foto in imagens)
            {
                Db.Insert(sqlInserirImagens, ObtemParametrosFoto(foto, automovelId));
            }
        }

        private Dictionary<string, object> ObtemParametrosFoto(Image foto, int automovelId)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("foto", foto);
            parametros.Add("automovel", automovelId);

            return parametros;
        }
    }
}
