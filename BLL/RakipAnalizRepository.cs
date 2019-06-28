using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RakipAnalizRepository : BaseRepository<RakipAnaliz>
    {
        RakipContext _db;
        public RakipAnalizRepository(RakipContext db) : base(db)
        {
            _db = db;
        }

        public override void Guncelle(IEntity yeni)
        {
            var y = yeni as RakipAnaliz;
            var eski = _db.RakipAnalizleri.Find(yeni.Id);
            eski.Kayitlar = y.Kayitlar;
            _db.Entry(eski).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
