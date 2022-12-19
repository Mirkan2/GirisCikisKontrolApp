using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirisCikisKontrolOtomasyonu.Classlar
{
    public class Personel
    {
        [Key]
        public int PeresonelId { get; set; }
        [Required]
        public string PersonelAdi { get; set; }
        [Required]
        public string PersonelSoyAdi { get; set; }
        [Required]
        public string PersonelTC { get; set; }
        [Required]
        public string PersonelCinsiyet { get; set; }
        [Required]
        public string PersonelEmailAdresi { get; set; }
        [Required]
        public string PersonelTelNO { get; set; }
        [ForeignKey("Cihaz")]
        public int CihazId { get; set; }
        public virtual Cihaz Cihaz { get; private set; }
        [ForeignKey("Sirket")]
        public int SirketId { get; set; }
        public virtual Sirket Sirket { get; private set; }

    }
}
