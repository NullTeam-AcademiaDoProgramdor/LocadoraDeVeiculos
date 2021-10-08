using LocadoraDeVeiculos.Dominio.FotoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.Configurations
{
    internal static class ImageExtensionMethods
    {
        public static byte[] ToByteArray(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image ToImage(this byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

    }

    public class FotoConfiguration : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("TBFoto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Imagem)
                .HasConversion(
                    v => v.ToByteArray(), 
                    v => v.ToImage());
        }
    }
}
