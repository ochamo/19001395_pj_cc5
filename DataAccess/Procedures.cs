using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal static class Procedures
    {
        // Procedures
        public const string CreateUser = "SP_InsertUsuario";
        public const string LoginUser = "SP_Get_Login";
        public const string GetDireccion = "SP_GetDireccion";
        public const string CreateDireccion = "SP_InsertDireccion";
        public const string GetNits = "SP_GetNit";
        public const string CreateNit = "SP_InsertNit";
        public const string GetDepartments = "SP_GetDepartmento";
        public const string GetMunis = "SP_GetMunicipio";
        public const string CreateCellphone = "SP_InsertCelular";
        public const string UpdatePassword = "SP_UpdatePassword";
        public const string GetCellPhoneDetail = "SP_GetCelularDet";
        public const string UpdateStockCellphone = "SP_UpdateStockCelular";
        public const string InsertCarritoUsuario = "SP_DeleteItemCarrito";      
    }
}
