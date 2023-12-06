/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */
using DevelopmentChallenge.Data.Extensions;
using DevelopmentChallenge.Data.Enum;
using DevelopmentChallenge.Data.FormasGeometricas;
using DevelopmentChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data
{
    public class ReporteFormaGeometrica
    {
    

        public static string lenguaje  { get; set; }

        public static string Imprimir(List<IFormaGeometrica> formasGeometricas, IdiomaEnum idioma)
        {

            lenguaje = idioma.GetDescription();
            var sb = new StringBuilder();

            if (!formasGeometricas.Any())
            {
                sb.Append($"<h1>{TextosIdiomas.ObtenerTexto("ListaVaciaDeFormas", lenguaje)}</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{TextosIdiomas.ObtenerTexto("ReporteDeFormas", lenguaje)}</h1>");

                var formasGeometricasAgrupadas = ObtenerDatosFormasGeometricasAgrupadas(formasGeometricas);

                foreach (var figura in formasGeometricasAgrupadas.OrderBy(x => x.OrdenImpresion))
                {
                    sb.Append(ObtenerLineasFiguras(figura));
                }
              

                // FOOTER
                sb.Append($"{TextosIdiomas.ObtenerTexto("Total", lenguaje)}:<br/>");
                sb.Append(formasGeometricasAgrupadas.Sum(x=>x.Cantidad) + " " + TextosIdiomas.ObtenerTexto("Formas", lenguaje) + " ") ;
                sb.Append($"{TextosIdiomas.ObtenerTexto("Perimetro", lenguaje)} {formasGeometricasAgrupadas.Sum(x => x.Perimetro).ToString("#.##")} ");
                sb.Append($"{TextosIdiomas.ObtenerTexto("Area", lenguaje)} " + formasGeometricasAgrupadas.Sum(x=>x.Area).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static List<FormaGeometricaVO> ObtenerDatosFormasGeometricasAgrupadas(List<IFormaGeometrica> formasGeometricas)
        {
            var result = new List<FormaGeometricaVO>();

            var tiposFormasGeometricas = formasGeometricas.Select(f => f.GetType()).Distinct();

            foreach (var tipoFromaGeometrica in tiposFormasGeometricas)
            {

                var formasGeometricasPorTipo = formasGeometricas.Where(f => f.GetType() == tipoFromaGeometrica);

                var cantidad = formasGeometricasPorTipo.Count();
                var nombre = formasGeometricasPorTipo.First().ObtenerNombre(cantidad);
                var area = formasGeometricasPorTipo.Sum(f => f.CalcularArea());
                var perimetro = formasGeometricasPorTipo.Sum(f => f.CalcularPerimetro());
                var ordernImpresion = formasGeometricasPorTipo.First().ObtenerOrdenImpresion();
                result.Add(new FormaGeometricaVO { Cantidad = cantidad, Area = area, Perimetro =perimetro, Nombre = nombre, OrdenImpresion = ordernImpresion });
            }

            return result;
        }

        private static string ObtenerLineasFiguras(FormaGeometricaVO formaGeometrica)
        {
            return $"{formaGeometrica.Cantidad } {TextosIdiomas.ObtenerTexto(formaGeometrica.Nombre, lenguaje)} | {TextosIdiomas.ObtenerTexto("Area", lenguaje)} {formaGeometrica.Area:#.##} | {TextosIdiomas.ObtenerTexto("Perimetro", lenguaje)} {formaGeometrica.Perimetro:#.##} <br/>";
        
        }

    }
}
