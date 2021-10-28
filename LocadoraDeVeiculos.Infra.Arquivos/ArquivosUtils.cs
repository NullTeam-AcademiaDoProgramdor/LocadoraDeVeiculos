using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Arquivos
{
    public static class ArquivosUtils
    {
        public static void ExcluirArquivo(string caminho)
        {
            File.Delete(caminho);
        }

        public static string GetEnderecoPastaArquivos(string nomeArquivo)
        {
            return @"C:\Users\pedro\OneDrive\Área de Trabalho\NDD\Projetos\ProjetosTime\teste\Arquivos\" + nomeArquivo;
        }
    }
}
