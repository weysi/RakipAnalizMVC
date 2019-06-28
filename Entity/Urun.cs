using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Urun : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string UrunAdi { get; set; }
        [MaxLength(100)]
        public string SN { get; set; }
        [MaxLength(50)]
        public string ModelKodu { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual List<UrunGrubu> UrunGruplari { get; set; }

        public virtual List<Kayit> Kayitlar { get; set; }
    }
}
