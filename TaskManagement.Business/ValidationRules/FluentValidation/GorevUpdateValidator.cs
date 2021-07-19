using FluentValidation;
using TaskManagement.DTO.DTOs.GorevDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
    public class GorevUpdateValidator : AbstractValidator<GorevUpdateDto>
    {
        public GorevUpdateValidator()
        {
            RuleFor(I => I.Ad).NotNull().WithMessage("Ad Alanı Gereklidir");
            RuleFor(I => I.AciliyetId).ExclusiveBetween(0, int.MaxValue)
                .WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
