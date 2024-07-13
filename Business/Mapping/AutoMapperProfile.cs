using AutoMapper;
using Entities.Dtos;
using Entities.Entities;

namespace Business.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderStatusNo, opt => opt.MapFrom(src => src.OrderStatusNo))
                .ForMember(dest => dest.CustomerNo, opt => opt.MapFrom(src => src.CustomerNo))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus))
                .ForMember(dest => dest.RevisedDueDate, opt => opt.MapFrom(src => src.RevisedDueDate))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.CustomerRequestDate, opt => opt.MapFrom(src => src.CustomerRequestDate))
                .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.CreatorId))
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))
                .ForMember(dest => dest.OrderNo, opt => opt.MapFrom(src => src.OrderNo))
                .ForMember(dest => dest.SalesRepresentiveId, opt => opt.MapFrom(src => src.SalesRepresentiveId));

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CustomerNo, opt => opt.MapFrom(src => src.CustomerNo))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
                .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BillingAddress));

            CreateMap<OrderStatus, OrderStatusDto>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.OrderStatusNo, opt => opt.MapFrom(src => src.OrderStatusNo))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PersonImage, opt => opt.MapFrom(src => src.PersonImage))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<SalesRepresentive, SalesRepresentiveDto>()
                .ForMember(dest => dest.SalesRepresentiveId, opt => opt.MapFrom(src => src.SalesRepresentiveId))
                .ForMember(dest => dest.SalesRepresentiveName, opt => opt.MapFrom(src => src.SalesRepresentiveName))
                .ForMember(dest => dest.SalesRepresentiveAbbr, opt => opt.MapFrom(src => src.SalesRepresentiveAbbr));
        }
    }
}
