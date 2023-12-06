using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Resources
{
    public static class TextosIdiomas
    {
        private static System.Resources.ResourceManager rm = new System.Resources.ResourceManager("DevelopmentChallenge.Data.Resources.textos", System.Reflection.Assembly.GetExecutingAssembly());

        public static string ObtenerTexto(string clave, string idioma)
        {
            return  rm.GetString(clave, new CultureInfo(idioma));   
        }

        //public static void Setidioma(string idioma)
        //{
        //    var cultureInfo = new CultureInfo(idioma);
        //    CultureInfo.CurrentUICulture = cultureInfo;
        //    CultureInfo.CurrentCulture = cultureInfo;

        //}
    }
}
