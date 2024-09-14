using FluentValidation;
using Real_Estate.Dto.PropertyDtos;

namespace Real_Estate.WebUI.Validation.PropertyValidator
{
   
    public class CreatePropertyValidator : AbstractValidator<CreatePropertyDto>
    {
        public CreatePropertyValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Başlık boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(x => x.AddedDate).NotEmpty().WithMessage("Eklenme tarihi boş olamaz.");
           
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş olamaz.");
            RuleFor(x => x.NumberOfRooms).GreaterThan(0).WithMessage("Oda sayısı 0'dan büyük olmalıdır.");
            RuleFor(x => x.NumberOfBathrooms).GreaterThan(0).WithMessage("Banyo sayısı 0'dan büyük olmalıdır.");
            RuleFor(x => x.SquareFeet).GreaterThan(0).WithMessage("Metrekare 0'dan büyük olmalıdır.");
            RuleFor(x => x.PropertyType).NotEmpty().WithMessage("Emlak türü boş olamaz.");
            RuleFor(x => x.ContactInfo).NotEmpty().WithMessage("İletişim bilgisi boş olamaz.");
        }
    }
}
