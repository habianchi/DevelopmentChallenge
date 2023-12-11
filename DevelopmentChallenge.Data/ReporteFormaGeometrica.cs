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
            else if (formasGeometricas.Any(x => !x.VerificarFormaGeometrica()))
            {
                sb.Append($"<h1>{TextosIdiomas.ObtenerTexto("FormasGeometricasNoValidas", lenguaje)}</h1>");
            }
            else
            {

                // Hay por lo menos una forma
                // HEADER
                sb.Append($"<h1>{TextosIdiomas.ObtenerTexto("ReporteDeFormas", lenguaje)}</h1>");


                var formasGeometricasAgrupadasPorTipo = formasGeometricas.GroupBy(x => x.GetType()).OrderBy(x=>x.First().ObtenerOrdenImpresion());

                foreach (var f in formasGeometricasAgrupadasPorTipo)
                {
                    sb.Append(ObtenerLineasFiguras(f.ToList()));
                    
                }
            
                // FOOTER
                sb.Append($"{TextosIdiomas.ObtenerTexto("Total", lenguaje)}:<br/>");


                sb.Append(formasGeometricasAgrupadasPorTipo.Sum(x=>x.Count())+ " " + TextosIdiomas.ObtenerTexto("Formas", lenguaje) + " ");
                sb.Append($"{TextosIdiomas.ObtenerTexto("Perimetro", lenguaje)} {formasGeometricasAgrupadasPorTipo.Sum(x => x.Sum(y=>y.CalcularPerimetro())).ToString("#.##")} ");
                sb.Append($"{TextosIdiomas.ObtenerTexto("Area", lenguaje)} " + formasGeometricasAgrupadasPorTipo.Sum(x => x.Sum(y => y.CalcularArea())).ToString("#.##"));
            }

            return sb.ToString();
        }

     

      

        private static string ObtenerLineasFiguras(List<IFormaGeometrica> formasGeometricas)
        {
            var count = formasGeometricas.Count();
            return $"{count } {TextosIdiomas.ObtenerTexto(formasGeometricas.First().ObtenerNombre(count), lenguaje)} | {TextosIdiomas.ObtenerTexto("Area", lenguaje)} {formasGeometricas.Sum(x=>x.CalcularArea()):#.##} | {TextosIdiomas.ObtenerTexto("Perimetro", lenguaje)} {formasGeometricas.Sum(x => x.CalcularPerimetro()):#.##} <br/>";

        }

    }
}
