using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UrunGrubu : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string GrupAdi { get; set; }
        [ForeignKey("UstUrunGrubu")]
        public int? UstGrupId { get; set; }

        public virtual UrunGrubu UstUrunGrubu { get; set; }
        public virtual List<UrunGrubu> AltGruplar { get; set; }
        public virtual List<Urun> Urunler { get; set; }
    }
}
