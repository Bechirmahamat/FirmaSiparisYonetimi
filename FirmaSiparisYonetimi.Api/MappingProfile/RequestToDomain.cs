using AutoMapper;
using FirmaSiparisYonetimi.Domain.Dtos.Request;
using FirmaSiparisYonetimi.Domain.Dtos.Response;
using FirmaSiparisYonetimi.Domain.Entities;

namespace FirmaSiparisYonetimi.Api.MappingProfile
{
    public class RequestToDomain:Profile
    {
        public RequestToDomain()
        {
            //create product
            CreateMap<ProductDto, Product>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(des => des.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(des => des.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));


            // update product
            CreateMap<UpdateProductDto, Product>()
             .ForMember(req => req.Name, opt => opt.MapFrom(scr => scr.Name))
             .ForMember(req => req.Price, opt => opt.MapFrom(scr => scr.Price))
             .ForMember(req => req.Name, opt => opt.MapFrom(scr => scr.CompanyId))
             .ForMember(req => req.UpdatedAt, opt => opt.MapFrom(scr => DateTime.Now))
             .ForMember(req => req.Stock, opt => opt.MapFrom(scr => scr.Stock));

            // Add new product 
            CreateMap<AddNewProductDto, Product>()
               .ForMember(req => req.Name, opt => opt.MapFrom(scr => scr.Name))
            
               .ForMember(req => req.Price, opt => opt.MapFrom(scr => scr.Price))
               .ForMember(req => req.Stock, opt => opt.MapFrom(scr => scr.Stock))
               .ForMember(req => req.CreatedAt, opt => opt.MapFrom(scr => DateTime.Now))
               .ForMember(req => req.UpdatedAt, opt => opt.MapFrom(scr => DateTime.Now));

            // ******  company setup *********//
            // create new company   //

            //create product
            CreateMap<AddNewCompanyDto, Company>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.ApprovalStatus, opt => opt.MapFrom(src => false))
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(des => des.OrderStartTime, opt => opt.MapFrom(src => TimeSpan.FromHours(8.5)))  // 08:30 AM
                .ForMember(des => des.OrderEndTime, opt => opt.MapFrom(src => TimeSpan.FromHours(11)));

            CreateMap<UpdateCompanyDto, Company>()
                .ForMember(req => req.OrderStartTime, opt => opt.MapFrom(src => src.OrderStartTime))
                .ForMember(req => req.OrderEndTime, opt => opt.MapFrom(src => src.OrderEndTime))
                .ForMember(req => req.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus))
                .ForMember(req => req.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
            // ******  orders setup *********//
            // create new order   //
            // getOrder
            CreateMap<CreateOrderDto,Order>()
       
               .ForMember(des => des.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
               .ForMember(des => des.ProductId, opt => opt.MapFrom(src => src.ProductId))
               .ForMember(des => des.OrderDate, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

        }


    

   }


}

