using AutoMapper;
using FirmaSiparisYonetimi.Domain.Dtos.Request;
using FirmaSiparisYonetimi.Domain.Dtos.Response;
using FirmaSiparisYonetimi.Domain.Entities;
using FirmaSiparisYonetimi.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyController(IUnitOfWork unitOfWork,IMapper mapper)
        { 
            this._unitOfWork=unitOfWork;
            this._mapper=mapper;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(AddNewCompanyDto entity)
        {
            var getTheDto = _mapper.Map<Company>(entity);


            var company = await _unitOfWork.Companys.Add(getTheDto);
            var isSaved = await _unitOfWork.completeASync();
            return Ok(company);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var companies = await _unitOfWork.Companys.All();
            var getTheDtos = _mapper.Map<IEnumerable<Company>, IEnumerable<GetCompanyDto>>(companies);

            return Ok(getTheDtos);
        }

        [HttpPut]
        [Route("{companyId:Guid}")]

        public async Task<IActionResult> UpdateCompany(Guid companyId, UpdateCompanyDto data)
        {
            var companyDto=_mapper.Map<Company>(data);
            var result = await _unitOfWork.Companys.Update(companyId, companyDto);
            if (result == null) return BadRequest();
            var company=_mapper.Map<GetCompanyDto>(result);
            var isSaveCorrect = await _unitOfWork.completeASync();
            return Ok(company);
        }
        

        
    }
}
