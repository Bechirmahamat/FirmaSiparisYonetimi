using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Entities
{
    public class Company:BaseEntity
    {

        public string Name { get; set; } // Company name
        public bool ApprovalStatus { get; set; } // Approval status: true = approved, false = not approved
        public TimeSpan OrderStartTime { get; set; } // Order permission start time
        public TimeSpan OrderEndTime { get; set; } // Order permission end time

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
