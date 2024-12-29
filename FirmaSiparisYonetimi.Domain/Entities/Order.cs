using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Entities
{
    public  class Order:BaseEntity
    {
        public Guid CompanyId { get; set; } // Foreign key to Company
        public Guid ProductId { get; set; } // Foreign key to Product
        public string CustomerName { get; set; } // Name of the person placing the order
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }


    }
}
