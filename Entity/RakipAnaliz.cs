using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RakipAnaliz : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public virtual List<Kayit> Kayitlar { get; set; }
    }
}
