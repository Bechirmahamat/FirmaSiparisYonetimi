using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Request
{
    public class AddNewProductDto
    {
        
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
   
    }
}
