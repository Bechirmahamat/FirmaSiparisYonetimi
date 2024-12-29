using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Request
{
    public  class CreateOrderDto
    {
      
        public Guid ProductId { get; set; } // Foreign key to Product
        public string CustomerName { get; set; } // Name of the person placing the order
     
    }
}
