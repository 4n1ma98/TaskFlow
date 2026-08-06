using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public enum ResultCode
    {
        // Éxito (0 - 99)
        Success = 0,
        Created = 1,
        Updated = 2,
        Deleted = 3,

        // Errores de Negocio / Validaciones (100 - 199)
        NotFound = 100,
        BadRequest = 101,
        ClientHasProducts = 102,
        ProductTypeNotFound = 103,

        // Error Inesperado (500)
        InternalError = 500
    }

    public static class ResultCodeExtensions
    {
        public static string GetDefaultMessage(this ResultCode resultCode)
        {
            return resultCode switch
            {
                ResultCode.Success => "Proceso ejecutado exitosamente.",
                ResultCode.Created => "Registro creado exitosamente.",
                ResultCode.Updated => "Registro actualizado exitosamente.",
                ResultCode.Deleted => "Registro eliminado exitosamente.",
                ResultCode.NotFound => "El recurso solicitado no fue encontrado.",
                ResultCode.BadRequest => "La solicitud contiene datos inválidos.",
                ResultCode.ClientHasProducts => "No se puede eliminar el cliente porque tiene productos financieros asociados.",
                ResultCode.ProductTypeNotFound => "El tipo de producto especificado no existe.",
                ResultCode.InternalError => "Ha ocurrido un error inesperado en el servidor.",
                _ => "Operación completada."
            };
        }
    }
}
