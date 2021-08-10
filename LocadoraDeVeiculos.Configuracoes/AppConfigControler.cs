using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Configuracoes
{
    internal class AppConfigControler
    {
        internal void AdicionarCamposCasoNaoExisntente(Dictionary<string, string> campos)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            foreach (var campo in campos)
            {
                if (settings[campo.Key] == null)
                    settings.Add(campo.Key, campo.Value);
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }



    }
}
