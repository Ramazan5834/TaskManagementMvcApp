using FluentValidation;
using TaskManagement.DTO.DTOs.AciliyetDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
   public class AciliyetAddValidator:AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
