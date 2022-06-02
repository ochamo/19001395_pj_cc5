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
        public const string GetDireccions = "SP_GetDireccions";
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
        public const string InsertCarritoUsuario = "SP_InsertCarritoUsuario"; 
        public const string DeleteItemCarrito = "SP_DeleteItemCarrito"; 
        public const string DeleteCarritoUsuario = "SP_DeleteCarritoUsuario"; 
        public const string GetCarrito = "SP_GetCarrito";
        public const string InsertPago = "SP_InsertPago";
        public const string GetPago = "SP_GetPago";
        public const string CreateFactura = "SP_InsertFactura";
        public const string GetFacturas = "SP_GetFacturas";
        public const string CreateFilasFactura = "SP_InsertFilaFactura";
        public const string GetFilasFactura = "SP_GetFilaFactura";
        public const string GetCellphones = "SP_GetCelulares";
        public const string CreatePedido = "SP_InsertPedido";
    }
}
