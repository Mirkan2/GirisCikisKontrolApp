using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GirisCikisKontrolOtomasyonu.Classlar
{
    public class KontrolContext:DbContext
    {
        public DbSet<Classlar.Sirket> Sirket { get; set; }
        public DbSet<Classlar.Cihaz> Cihaz { get; set; }
        public DbSet<Classlar.Personel> Personel { get; set; }
        public DbSet<Classlar.GirisCikis> GirisCikis { get; set; }
    }
}
