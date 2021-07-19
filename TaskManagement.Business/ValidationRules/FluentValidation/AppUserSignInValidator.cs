using FluentValidation;
using TaskManagement.DTO.DTOs.AppUserDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator:AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre alanı boş geçilemez");

        }
    }
}
