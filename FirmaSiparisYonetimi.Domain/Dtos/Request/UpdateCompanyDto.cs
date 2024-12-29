using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Request
{
    public class UpdateCompanyDto
    {
        public TimeSpan OrderStartTime { get; set; }
        public TimeSpan OrderEndTime { get; set; }
        public bool ApprovalStatus { get; set; }

    }
}
