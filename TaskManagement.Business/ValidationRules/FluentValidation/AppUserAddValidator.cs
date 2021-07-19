using FluentValidation;
using TaskManagement.DTO.DTOs.AppUserDtos;

namespace TaskManagement.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola Alanı Boş Geçilemez");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Parola Onay Alanı Boş Geçilemez");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parolalarınız eşleşmiyor");
            RuleFor(I => I.Email).NotNull().WithMessage("Email alnı boş geçilemez").EmailAddress()
                .WithMessage("Geçersiz email adresi");
            RuleFor(I => I.Name).NotNull().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(I => I.Surname).NotNull().WithMessage("Soyad Alanı Boş Geçilemez");
        }
    }
}
