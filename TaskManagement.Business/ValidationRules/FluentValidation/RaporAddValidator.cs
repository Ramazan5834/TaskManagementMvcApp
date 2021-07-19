using FluentValidation;
using TaskManagement.DTO.DTOs.RaporDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
  public  class RaporAddValidator:AbstractValidator<RaporAddDto>
    {
        public RaporAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");
            RuleFor(I => I.Detay).NotNull().WithMessage("Detay Alanı Boş Geçilemez");
        }
    }
}
