using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Request
{
    public class AddNewCompanyDto
    {
        public string Name { get; set; } // Company name
        public String OrderStartTime { get; set; } // Order permission start time
        public String OrderEndTime { get; set; } // Order permission end time

    }
}
