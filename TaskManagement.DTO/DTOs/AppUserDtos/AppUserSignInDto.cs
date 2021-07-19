namespace TaskManagement.DTO.DTOs.AppUserDtos
{
    public class AppUserSignInDto
    {
       // [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
       // [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
       // [Required(ErrorMessage = "Parola Boş Geçilemez")]
       // [Display(Name = "Parola:")]
       // [DataType(DataType.Password)]
        public string Password { get; set; }

       // [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
