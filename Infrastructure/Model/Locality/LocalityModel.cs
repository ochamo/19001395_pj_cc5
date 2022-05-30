using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Locality
{
    public class LocalityModel
    {
        public int IdDep { get; set; }
        public string NombreDep { get; set; }

        public List<MuniModel> munis { get; set; }

        public LocalityModel(int idDep, string nombreDep, List<MuniModel> munis)
        {
            IdDep = idDep;
            NombreDep = nombreDep;
            this.munis = munis;
        }

        public LocalityModel()
        {
        }
    }
}
