using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class ErrorModel
    {
        public string Code { get; set; }

        public ErrorModel()
        {
            this.Code = "";
        }

        public ErrorModel(string code)
        {
            this.Code = code;
        }

    }
}
