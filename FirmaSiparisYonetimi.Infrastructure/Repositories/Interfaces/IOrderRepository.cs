using FirmaSiparisYonetimi.Domain.Dtos.Response;
using FirmaSiparisYonetimi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository:IGenericRepositories<Order>
    {
        Task<OrderResultDto> PlaceAnOrder(Order order);
    }
}
