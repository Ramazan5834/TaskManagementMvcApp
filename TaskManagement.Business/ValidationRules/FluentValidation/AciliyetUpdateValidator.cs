using FluentValidation;
using TaskManagement.DTO.DTOs.AciliyetDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
   public class AciliyetUpdateValidator:AbstractValidator<AciliyetUpdateDto>
    {
        public AciliyetUpdateValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");
        }
    }
}
