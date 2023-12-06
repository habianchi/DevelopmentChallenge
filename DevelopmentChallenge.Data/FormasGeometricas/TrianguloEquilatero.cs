using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.FormasGeometricas
{
    public class TrianguloEquilatero : FormaGeometricaBase
    {

        public TrianguloEquilatero(decimal lado) : base(lado,3) { }
        public override decimal CalcularArea()
        {
           return  ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string ObtenerNombre(int cantidad)
        {
            if (cantidad == 1)
                return "Triangulo";
            else
                return "Triangulos";
        }
    }
}
