using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.FormasGeometricas
{
    public class Circulo : FormaGeometricaBase
    {
        public Circulo(decimal radio) : base(radio, 2) { }
        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }

        public override string ObtenerNombre(int cantidad)
        {
            if (cantidad == 1)
                return "Circulo";
            else
                return "Circulos";
        }
    }
}
