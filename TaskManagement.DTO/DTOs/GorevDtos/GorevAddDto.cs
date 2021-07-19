namespace TaskManagement.DTO.DTOs.GorevDtos
{
 public   class GorevAddDto
    {
       // [Required(ErrorMessage = "Ad alanı gereklidir")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
       // [Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçinz")]
        public int AciliyetId { get; set; }
    }
}
