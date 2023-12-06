using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.FormasGeometricas
{
    public class Trapecio : FormaGeometricaBase
    {
        protected readonly decimal _baseMayor;
        protected readonly decimal _baseMenor;
        protected readonly decimal _ladoNoParalelo1;
        protected readonly decimal _ladoNoParalelo2;
        protected readonly decimal _altura;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal ladoNoParalelo1, decimal ladoNoParalelo2, decimal altura)
            : base(0, 4)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _ladoNoParalelo1 = ladoNoParalelo1;
            _ladoNoParalelo2 = ladoNoParalelo2;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2; ;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _ladoNoParalelo1 + _ladoNoParalelo2; ;
        }

        public override string ObtenerNombre(int cantidad)
        {
            if (cantidad == 1)
                return "Trapecio";
            else
                return "Trapecios";
        }
    }
}
