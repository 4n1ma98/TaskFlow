using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class CreateClientRequest
    {
        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]
        [StringLength(10, ErrorMessage = "El tipo de documento no puede exceder los 10 caracteres.")]
        public string DocumentType { get; set; } = null!;

        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        [StringLength(20, ErrorMessage = "La identificación no puede exceder los 20 caracteres.")]
        public string IdentificationNumber { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
        public string LastName { get; set; } = null!;

        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        public string? Address { get; set; }

        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(150, ErrorMessage = "El correo no puede exceder los 150 caracteres.")]
        public string? Email { get; set; }
    }
}
