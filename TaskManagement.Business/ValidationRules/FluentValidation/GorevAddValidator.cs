using FluentValidation;
using TaskManagement.DTO.DTOs.GorevDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
    public class GorevAddValidator : AbstractValidator<GorevAddDto>
    {
        public GorevAddValidator()
        {
            RuleFor(I => I.Ad).NotNull().WithMessage("Ad Alanı Gereklidir");
            RuleFor(I => I.AciliyetId).ExclusiveBetween(0, int.MaxValue)
                .WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
