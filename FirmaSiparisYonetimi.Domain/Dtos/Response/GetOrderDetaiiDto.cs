using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Response
{
    public class GetOrderDetaiiDto
    {
        public Guid Id { get; set; }
    
        public string CustomerName { get; set; } // Name of the person placing the order
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public GetProductDto Product { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
