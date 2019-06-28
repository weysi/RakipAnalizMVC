using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Entity - Domain - Business Domain
namespace Entity
{
    public class Kayit : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int SatisAdedi { get; set; }
        public DateTime Tarih { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual RakipAnaliz RakipAnaliz { get; set; }

        public Kayit()
        {
            Tarih = DateTime.Now;
        }
    }
}
