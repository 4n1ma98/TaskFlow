using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string DocumentType { get; set; } = null!;
        public string IdentificationNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        // Relación con Productos
        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
