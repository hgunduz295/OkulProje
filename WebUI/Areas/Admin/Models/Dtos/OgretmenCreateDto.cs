using Okul.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class OgretmenCreateDto
    {

        [Required(ErrorMessage = "Ad Alani Boş Olamaz")]
        [MaxLength(50)]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Soyad Alani Boş Olamaz")]
        [MaxLength(50)]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "TCNo Alani Boş Olamaz")]
        [MaxLength(11)]
        public string TcNo { get; set; }
        [EmailAddress]

        public string Email { get; set; }
        [Phone]
        public string Gsm { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }

        public decimal Maas { get; set; }

        public int BransId { get; set; }
        public Brans Brans { get; set; }
    }
}
