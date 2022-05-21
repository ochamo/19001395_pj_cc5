using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class DepModel
    {
        public int IdDep { get; set; }
        public string NombreDep { get; set; }

        public IEnumerable<MuniModel> munis { get; set; }

        public DepModel(int idDep, string nombreDep, IEnumerable<MuniModel> munis)
        {
            IdDep = idDep;
            NombreDep = nombreDep;
            this.munis = munis;
        }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public DepModel()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
        }
    }
}
