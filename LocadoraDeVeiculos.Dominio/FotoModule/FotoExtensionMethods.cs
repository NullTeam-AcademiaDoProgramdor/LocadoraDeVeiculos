using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.FotoModule
{
    public static class FotoExtensionMethods
    {

        public static List<Foto> ToFotoList(this Image[] images)
        {
            return images.Select(x => new Foto(x)).ToList();
        }

        public static List<Foto> ToFotoList(this List<Image> images)
        {
            return images.Select(x => new Foto(x)).ToList();
        }

        public static Image[] ToImageArray(this List<Foto> fotos)
        {
            return fotos.Select(x => x.Imagem).ToArray();
        }
    } 
}
