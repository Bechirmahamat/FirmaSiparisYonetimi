using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Entities
{
    public class Product:BaseEntity
    {
       
        public Guid CompanyId { get; set; } // Foreign key to Company
        public string Name { get; set; } // Product name
        public int Stock { get; set; } // Available stock
        public decimal Price { get; set; } // Product price

        // Navigation Property
        public virtual Company Company { get; set; }

    }
}
