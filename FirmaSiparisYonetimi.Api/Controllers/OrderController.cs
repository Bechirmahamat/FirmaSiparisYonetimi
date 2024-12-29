using AutoMapper;
using FirmaSiparisYonetimi.Domain.Dtos.Request;
using FirmaSiparisYonetimi.Domain.Dtos.Response;
using FirmaSiparisYonetimi.Domain.Entities;
using FirmaSiparisYonetimi.Infrastructure.Data;
using FirmaSiparisYonetimi.Infrastructure.Repositories;
using FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unityOfWork,IMapper mapper)
        {
            this._unityOfWork = unityOfWork;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnOrder(CreateOrderDto entity)
        {
            var orderObject = _mapper.Map<Order>(entity);

            var request= await _unityOfWork.Orders.PlaceAnOrder(orderObject);

            if (!request.success) {
                return BadRequest(request.message);
            
            }

            var response = _mapper.Map<GetOrderDetaiiDto>(request.Order);
            await _unityOfWork.completeASync();
            return Ok(response);
        }
    }
}
