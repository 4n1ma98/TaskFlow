using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses.DTO
{
    public class ClientProductResponse
    {
        public string DocumentType { get; set; } = null!;
        public string IdentificationNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string ProductTypeName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
