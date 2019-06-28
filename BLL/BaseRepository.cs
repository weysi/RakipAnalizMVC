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
    public class BaseRepository<T> where T : class
    {
        RakipContext db;

        public BaseRepository(RakipContext gelendb)
        {
            db = gelendb;
        }

        public List<T> HepsiniGetir()
        {
            return db.Set<T>().ToList();
        }

        public List<T> Ara(Func<T,bool> sartlar)
        {
            return db.Set<T>().Where(sartlar).ToList();
                //db.Set<T>() => db.Urunler
        }

        public T BirTaneGetir(int id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual void Ekle(T yeni)
        {
            //if(T is Urun)
            db.Set<T>().Add(yeni);
            db.SaveChanges();
        }

        public virtual void Sil(int id)
        {
            var silinecek = BirTaneGetir(id);
            db.Set<T>().Remove(silinecek);
            db.SaveChanges();
        }

        public virtual void Guncelle(IEntity yeni)
        {
            var eski = BirTaneGetir(yeni.Id);
            //navigation propertyleri güncellemez
            db.Entry(eski).CurrentValues.SetValues(yeni);
            db.Entry(eski).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
