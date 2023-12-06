using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data;
using DevelopmentChallenge.Data.Enum;
using DevelopmentChallenge.Data.FormasGeometricas;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
       
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReporteFormaGeometrica.Imprimir(new List<IFormaGeometrica>(), IdiomaEnum.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReporteFormaGeometrica.Imprimir(new List<IFormaGeometrica>(), IdiomaEnum.Ingles));
        }
        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>",
                ReporteFormaGeometrica.Imprimir(new List<IFormaGeometrica>(), IdiomaEnum.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new FormaGeometricaCuadrado(5) };

            var resumen = ReporteFormaGeometrica.Imprimir(cuadrados, IdiomaEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new FormaGeometricaCuadrado(5),
                new FormaGeometricaCuadrado(1),
                new FormaGeometricaCuadrado(3)
            };

            var resumen = ReporteFormaGeometrica.Imprimir(cuadrados, IdiomaEnum.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new FormaGeometricaCuadrado (5),
                new Circulo( 3),
                new FormaGeometricaTrianguloEquilatero( 4),
                new FormaGeometricaCuadrado( 2),
                new FormaGeometricaTrianguloEquilatero(9),
                new Circulo(2.75m),
                new FormaGeometricaTrianguloEquilatero( 4.2m),
                new FormaGeometricaTrapecioRectangulo(5, 3, 4)
            };

            var resumen = ReporteFormaGeometrica.Imprimir(formas, IdiomaEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 trapeze | Area 16 | Perimeter 16,47 <br/>TOTAL:<br/>8 shapes Perimeter 114,14 Area 107,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new FormaGeometricaCuadrado(5),
                new Circulo(3),
                new FormaGeometricaTrianguloEquilatero(4),
                new FormaGeometricaCuadrado(2),
                new FormaGeometricaTrianguloEquilatero(9),
                new Circulo(2.75m),
                new FormaGeometricaTrianguloEquilatero(4.2m),
                new FormaGeometricaTrapecioRectangulo(5, 3, 4)
            };

            var resumen = ReporteFormaGeometrica.Imprimir(formas, IdiomaEnum.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>1 Trapecio | Area 16 | Perimetro 16,47 <br/>TOTAL:<br/>8 formas Perimetro 114,14 Area 107,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new FormaGeometricaCuadrado(5),
                new Circulo(3),
                new FormaGeometricaTrianguloEquilatero(4),
                new FormaGeometricaCuadrado(2),
                new FormaGeometricaTrianguloEquilatero(9),
                new Circulo(2.75m),
                new FormaGeometricaTrianguloEquilatero(4.2m),
                new FormaGeometricaTrapecioRectangulo(5, 3, 4)
            };

            var resumen = ReporteFormaGeometrica.Imprimir(formas, IdiomaEnum.Italiano);

            Assert.AreEqual(
                "<h1>Report di forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>1 Trapezio | Area 16 | Perimetro 16,47 <br/>TOTALE:<br/>8 Forme Perimetro 114,14 Area 107,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var cuadrados = new List<IFormaGeometrica> { new FormaGeometricaTrapecioRectangulo(5, 3, 4) };

            var resumen = ReporteFormaGeometrica.Imprimir(cuadrados, IdiomaEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 16 | Perimetro 16,47 <br/>TOTAL:<br/>1 formas Perimetro 16,47 Area 16", resumen);
        }



        [TestCase]
        public void TestResumenListaCuadradoNoValido()
        {
            var cuadrados = new List<IFormaGeometrica> { new FormaGeometricaCuadrado(-5) };
            Assert.AreEqual("<h1>Hay formas que no cumplen sus condiciones geometricas</h1>",
                ReporteFormaGeometrica.Imprimir(cuadrados, IdiomaEnum.Castellano));
        }

        [TestCase]
        public void TestResumenListaTrapecioRectanguloNoValido()
        {
            var cuadrados = new List<IFormaGeometrica> { new FormaGeometricaTrapecioRectangulo(1,-1,100) };
            Assert.AreEqual("<h1>Hay formas que no cumplen sus condiciones geometricas</h1>",
                ReporteFormaGeometrica.Imprimir(cuadrados, IdiomaEnum.Castellano));
        }

    }
}
