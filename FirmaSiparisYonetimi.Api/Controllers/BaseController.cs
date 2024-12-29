using AutoMapper;
using FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimi.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController:ControllerBase
    {
        protected readonly IUnitOfWork _unityOfWork;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        { 
            this._unityOfWork = unitOfWork;
            this._mapper = mapper;  
        }

    }
}
