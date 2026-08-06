using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProductTypeId { get; set; }
        public int ClientId { get; set; }
        public bool IsActive { get; set; } = true;

        // Propiedades de Navegación
        public ProductType ProductType { get; set; } = null!;
        public Client Client { get; set; } = null!;
    }
}
