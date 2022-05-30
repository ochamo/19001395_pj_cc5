using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Carrito
{
    public class CarritoModel
    {
        public int IdUsuario { get; set; }
        public int IdCelular { get; set; }
        public string Imagen { get; set; }
        public string Model { get; set; }

        public CarritoModel(int idUsuario, int idCelular, string imagen, string model)
        {
            IdUsuario = idUsuario;
            IdCelular = idCelular;
            Imagen = imagen;
            Model = model;
        }

        public CarritoModel()
        {
        }
    }
}
