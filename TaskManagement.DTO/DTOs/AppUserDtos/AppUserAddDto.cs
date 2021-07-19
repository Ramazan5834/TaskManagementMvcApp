namespace TaskManagement.DTO.DTOs.AppUserDtos
{
   public class AppUserAddDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
       // [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
       // [Required(ErrorMessage = "Parola Boş Geçilemez")]
        //[Display(Name = "Parola:")]
       // [DataType(DataType.Password)]
        public string Password { get; set; }
       // [Compare("Password", ErrorMessage = "Parolalar Eşleşmiyor")]
       // [Display(Name = "Parola Doğrula:")]
       // [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
       // [Required(ErrorMessage = "Email Boş Geçilemez")]
       // [Display(Name = "Email:")]
       // [EmailAddress(ErrorMessage = "Geçersiz email")]
        public string Email { get; set; }
       // [Required(ErrorMessage = "Ad Boş Geçilemez")]
       // [Display(Name = "Ad:")]
        public string Name { get; set; }
      //  [Required(ErrorMessage = "Soyad Boş Geçilemez")]
      //  [Display(Name = "Soyad:")]
        public string Surname { get; set; }
    }
}
