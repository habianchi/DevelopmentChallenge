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

        public FormaGeometricaTrapecioRectangulo(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoDiagonal)
            : base(ladoDiagonal, 4)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2; ;
        }

        public override decimal CalcularPerimetro()
        {
            var ladoDiagonal = _lado;
            return _baseMayor + _baseMenor + _altura + ladoDiagonal; ;
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
            decimal lado1 = _baseMayor;
            decimal lado2 = _baseMenor;
            decimal lado3 = _altura;

            // Ordenamos los lados para que lado1 sea el más largo (base mayor o base menor)
            if (lado1 < lado2)
            {
                var temp = lado1;
                lado1 = lado2;
                lado2 = temp;
            }

            // Verificamos el teorema de Pitágoras para los lados no paralelos
            decimal diferenciaBasesAlCuadrado = lado1 * lado1 - lado2 * lado2;
            decimal alturaAlCuadrado = lado3 * lado3;

            // Permitimos una pequeña tolerancia debido a errores de redondeo en cálculos decimales
            decimal tolerancia = 0.0001m;

            return Math.Abs(diferenciaBasesAlCuadrado - alturaAlCuadrado) < tolerancia;
        }
    }
}
