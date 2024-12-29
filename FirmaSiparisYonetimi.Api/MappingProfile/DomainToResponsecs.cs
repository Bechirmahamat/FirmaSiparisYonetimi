using AutoMapper;
using FirmaSiparisYonetimi.Domain.Dtos.Request;
using FirmaSiparisYonetimi.Domain.Dtos.Response;
using FirmaSiparisYonetimi.Domain.Entities;

namespace FirmaSiparisYonetimi.Api.MappingProfile
{
    public class DomainToResponsecs:Profile
    {
        public DomainToResponsecs()
        {
            //get product
            CreateMap<Product, GetProductDto>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(des => des.Company, opt => opt.MapFrom(src => src.Company))
                .ForMember(des => des.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(des => des.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));


            // get the companies

            CreateMap<Company, GetCompanyDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus))
                .ForMember(des => des.OrderStartTime, opt => opt.MapFrom(src => src.OrderStartTime))
                .ForMember(des => des.OrderEndTime, opt => opt.MapFrom(src => src.OrderEndTime))
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(des => des.Products, opt => opt.MapFrom(src => src.Products));

            // getOrder
            CreateMap<Order, GetOrderDetaiiDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(des => des.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(des => des.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.OrderDate, opt => opt.MapFrom(src => src.OrderDate));

        }

        

    }
}
