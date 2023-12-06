using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.FormasGeometricas
{
    public class FormaGeometricaTrapecioRectangulo : FormaGeometricaBase
    {
        protected readonly decimal _baseMayor;
        protected readonly decimal _baseMenor;
        protected readonly decimal _altura;



        public FormaGeometricaTrapecioRectangulo(decimal baseMayor, decimal baseMenor, decimal altura)
            : base(CalcularLado(baseMayor, baseMenor, altura), 4)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        private static decimal CalcularLado(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            var aux = baseMayor - baseMenor;

            return (decimal)Math.Sqrt(Math.Pow((double)aux, 2) + Math.Pow((double)altura, 2));
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _altura + _lado; 
        }

        public override string ObtenerNombre(int cantidad)
        {
            if (cantidad == 1)
                return "Trapecio";
            else
                return "Trapecios";
        }

        public override bool VerificarFormaGeometrica()
        {
            return _baseMayor > 0 && _baseMenor > 0 && _altura > 0;
        }
    }
}
