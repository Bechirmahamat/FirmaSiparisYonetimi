using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Domain.Dtos.Response
{
    public class GetCompanyDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; } // Company name
        public bool ApprovalStatus { get; set; } // Approval status: true = approved, false = not approved
        public TimeSpan OrderStartTime { get; set; } // Order permission start time
        public TimeSpan OrderEndTime { get; set; } // Order permission end time
        public List<GetProductDto> Products { get; set; } = new List<GetProductDto>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }



    }
}
