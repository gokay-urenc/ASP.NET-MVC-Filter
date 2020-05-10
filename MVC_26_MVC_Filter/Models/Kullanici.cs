using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // NotMapped bu kütüphane olmadan gelmez.
using System.Linq;
using System.Web;

namespace MVC_26_MVC_Filter.Models
{
    public class Kullanici
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [MaxLength(50), Required, DisplayName("Adı")]
        public string Adi { get; set; }

        [MaxLength(50), Required, DisplayName("Soyadı")]
        public string Soyadi { get; set; }

        [EmailAddress, Required, DisplayName("E-Posta Adresi")]
        public string EmailAdresi { get; set; }

        [MinLength(3), MaxLength(50), Required, DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [MinLength(8), MaxLength(16), Required, DisplayName("Şifre")]
        public string Sifre { get; set; }

        // NotMapped bu kolon(property) veritabanında oluşturulmasın işlemini yapar.
        // Compare birbirine eşit mi olayını kontrol eder. Parametre olarak eşitliği kontrol edecek diğer property'yi ister.
        [MinLength(8), MaxLength(16), NotMapped, Compare("Sifre"), Required, DisplayName("Şifre Tekrarı")]
        public string SifreTekrari { get; set; }
    }
}