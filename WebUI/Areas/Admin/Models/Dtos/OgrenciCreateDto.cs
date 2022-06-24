using System;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class OgrenciCreateDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alani Boş Geçilemez")]
        [MaxLength(30, ErrorMessage = "Ad alani 30 karakterden buyuk olamaz.")]
        public string Adi { get; set; }


        [Required(ErrorMessage = "Soyad alani Boş Geçilemez")]
        [MaxLength(50, ErrorMessage = "Soyad alani 50 karakterden buyuk olamaz.")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "TcNo alani Boş Geçilemez")]
        [MaxLength(11, ErrorMessage = "TCNo 11 karakterden buyuk olamaz.")]

        public string TcNo { get; set; }


        [MaxLength(50, ErrorMessage = "Email alani 50 karakterden buyuk olamaz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gsm zorunlu alandir")]
        [DataType(DataType.PhoneNumber)]
        public string Gsm { get; set; }

        [Required(ErrorMessage = "Cinsiyet alani Zorunludur")]
        public bool Cinsiyet { get; set; }

        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

        public int SinifId { get; set; }
    }
}
