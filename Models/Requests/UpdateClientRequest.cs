using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class UpdateClientRequest
    {
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio.")]
        [StringLength(10)]
        public string DocumentType { get; set; } = null!;

        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        [StringLength(20)]
        public string IdentificationNumber { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [StringLength(200)]
        public string? Address { get; set; }

        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(150)]
        public string? Email { get; set; }
    }
}
