using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Cellphone
{
    public class CreateCellphoneDto
    {
        public int Cant { get; set; }
        public string Img { get; set; }

        public string Descr { get; set; }
        public string Caract { get; set; }
        public string Model { get; set; }
        public decimal Preci { get; set; }
        public string NumSeri { get; set; }

        public CreateCellphoneDto(int cant, string img, string descr, string caract, string model, decimal preci, string numSeri)
        {
            Cant = cant;
            Img = img;
            Descr = descr;
            Caract = caract;
            Model = model;
            Preci = preci;
            NumSeri = numSeri;
        }

        public CreateCellphoneDto()
        {
        }
    }
}
