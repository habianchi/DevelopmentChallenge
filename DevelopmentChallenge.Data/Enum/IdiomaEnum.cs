using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Enum
{
    public enum IdiomaEnum
    {
        [Description("es")]
        Castellano = 1,
        [Description("en")]
        Ingles,
        [Description("it")]
        Italiano
    }
}
