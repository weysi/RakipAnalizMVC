using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Data Access Layer - DAL
namespace DAL
{
    public class RakipContext : DbContext
    {
        public RakipContext() : base("RakipBaglanti")
        {

        }

        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<UrunGrubu> UrunGruplari { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<RakipAnaliz> RakipAnalizleri { get; set; }
        public virtual DbSet<Kayit> Kayitlar { get; set; }
    }
}
