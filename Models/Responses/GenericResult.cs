using  Models.Common;

namespace Models.Responses
{
    public class GenericResult
    {
        public int Id { get; set; }
        public bool IsSuccesfull { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }

        /// <summary>
        /// Genera una respuesta exitosa estandarizada.
        /// </summary>
        public static GenericResult SuccessResult(object? data = null, ResultCode code = ResultCode.Success, string? customMessage = null)
        {
            return new GenericResult
            {
                Id = (int)code,
                IsSuccesfull = true,
                Message = customMessage ?? code.GetDefaultMessage(),
                Data = data
            };
        }

        /// <summary>
        /// Genera una respuesta de error estandarizada basándose en el ResultCode.
        /// </summary>
        public static GenericResult ErrorResult(ResultCode code, string? customMessage = null)
        {
            return new GenericResult
            {
                Id = (int)code,
                IsSuccesfull = false,
                Message = customMessage ?? code.GetDefaultMessage(),
                Data = null
            };
        }
    }
}
