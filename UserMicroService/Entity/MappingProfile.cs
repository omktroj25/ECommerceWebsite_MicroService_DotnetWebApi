using AutoMapper;
using Entity.Dto;
using Entity.Model;

namespace Entity
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            //For user registeration ProfileDto to user table
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UserId));

            //For creating new address for the user in address table
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.Line1))
                .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.Line2))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.AddressType, opt => opt.MapFrom(src => src.AddressType))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UserId));

            //For Creating new payment for the user in the payment table
            CreateMap<PaymentDto, Payment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UserId));
            
            //For Creating new upi payment for the user in the upi payment table
            CreateMap<PaymentDto, UpiPayment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PaymentTypeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UpiId, opt => opt.MapFrom(src => src.UpiId))
                .ForMember(dest => dest.UpiApp, opt => opt.MapFrom(src => src.UpiApp))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UserId));
            
            //For Creating new card payment for the user in the card payment table
            CreateMap<PaymentDto, CardPayment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PaymentTypeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CardHolderName, opt => opt.MapFrom(src => src.CardHolderName))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CardNumber))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UserId));

                

        }

    }
}