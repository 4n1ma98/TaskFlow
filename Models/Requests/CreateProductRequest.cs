using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El ID del tipo de producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe especificar un ID de tipo de producto válido.")]
        public int ProductTypeId { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe especificar un ID de tipo de producto válido.")]
        public int ClientId { get; set; }
    }
}
