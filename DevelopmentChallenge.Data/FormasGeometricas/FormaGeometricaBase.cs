using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.FormasGeometricas
{
    public abstract class FormaGeometricaBase : IFormaGeometrica
    {
        protected readonly decimal _lado;
        protected readonly decimal _nombre;
        protected readonly int _ordenImpresion;
        protected FormaGeometricaBase(decimal lado, int ordenImpresion)
        {
            _lado = lado;
            _ordenImpresion = ordenImpresion;
        }

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

        public abstract string ObtenerNombre(int cantidad);

        public int ObtenerOrdenImpresion()
        {
            return _ordenImpresion;
        }

        public virtual bool VerificarFormaGeometrica()
        {
            return _lado > 0;
        }
    }


}
