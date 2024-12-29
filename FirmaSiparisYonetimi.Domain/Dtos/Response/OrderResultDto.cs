using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Response
{
    public class OrderResultDto
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Order? Order { get; set; }
    }
}
