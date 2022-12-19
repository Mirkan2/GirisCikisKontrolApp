using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirisCikisKontrolOtomasyonu.Classlar
{
    public class Sirket
    {
        [Key]
        public int SirketId { get; set; }
        [Required]
        public string SirketAdi { get; set; }
        public virtual List<Personel> Personels { get; set; } = new List<Personel>();
    }
}
