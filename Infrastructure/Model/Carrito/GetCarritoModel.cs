using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Carrito
{
    public class GetCarritoModel
    {
        public int IdUsuario { get; set; }
        public int IdCelular { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
        public string Modelo { get; set; }

        public decimal Precio { get; set; }

        public GetCarritoModel(int idUsuario, int idCelular, int cantidad, string imagen, string modelo)
        {
            IdUsuario = idUsuario;
            IdCelular = idCelular;
            Cantidad = cantidad;
            Imagen = imagen;
            Modelo = modelo;
        }

        public GetCarritoModel()
        {
        }
    }
}
