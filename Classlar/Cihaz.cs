using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirisCikisKontrolOtomasyonu.Classlar
{
    public class Cihaz
    {
        [Key]
        public int CihazId { get; set; }
        [Required]
        public string CihazNo { get; set; }
        public virtual List<Personel> Personels { get; set; } = new List<Personel>();
       
    }
}
