using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    //classların default access modifierı: internal
    public class Marka : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string MarkaAdi { get; set; }

        public virtual List<Urun> Urunler { get; set; }
    }
}
