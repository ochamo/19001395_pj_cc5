using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Cellphone
{
    public class CelularModel
    {
        public int IdCelular { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public string Caracteristicas { get; set; }

        public string Modelo { get; set; }

        public decimal Precio { get; set; }
        public string NumSerie { get; set; }

        public CelularModel(int idCelular, int cantidad, string imagen, string descripcion, string caracteristicas, string model, decimal precio, string numSerie)
        {
            IdCelular = idCelular;
            Cantidad = cantidad;
            Imagen = imagen;
            Descripcion = descripcion;
            Caracteristicas = caracteristicas;
            Modelo = model;
            Precio = precio;
            NumSerie = numSerie;
        }

        public CelularModel()
        {
        }
    }
}
