using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Procedures
    {
        // Procedures
        public const string CreateUser = "SP_InsertUsuario";
        public const string LoginUser = "SP_Get_Login";
        public const string GetDireccion = "SP_GetDireccion";
        public const string CreateDireccion = "SP_InsertDireccion";
        public const string GetNits = "SP_GetNit";
        public const string CreateNit = "SP_InsertNit";

    }
}
