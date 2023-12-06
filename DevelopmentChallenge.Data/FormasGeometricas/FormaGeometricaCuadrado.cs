using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.FormasGeometricas
{
    public class FormaGeometricaCuadrado : FormaGeometricaBase
    {
        public FormaGeometricaCuadrado(decimal lado) : base(lado,1) { }

        public override decimal CalcularArea() => _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 4;


        public override string ObtenerNombre(int cantidad)
        {
            if (cantidad == 1)
                return "Cuadrado";
            else
                return "Cuadrados";
        }

      
    }
}
