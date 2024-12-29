using AutoMapper;
using FirmaSiparisYonetimi.Domain.Dtos.Request;
using FirmaSiparisYonetimi.Domain.Dtos.Response;
using FirmaSiparisYonetimi.Domain.Entities;
using FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }



        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProductById(Guid id) { 
            var product=await _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<GetProductDto>(product);
            return Ok(result);
        }

        [HttpPost]

        [Route("{companyId:Guid}")]
        public async Task<IActionResult> AddProduct(Guid companyId, AddNewProductDto entity) {

            var productDto=_mapper.Map<Product>(entity);


            var response = await _unitOfWork.Products.Add(companyId,productDto);
            if (response == null) return BadRequest("Company or Product types is incorrect utilize the documentation ");
            var responseDto=_mapper.Map<GetProductDto>(productDto);
            var isSavedCorrectly=await _unitOfWork.completeASync();
            return Ok(responseDto);
        }
    }
}
